using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System;
using ZXing.Common;
using System.Text;
using Unity.VisualScripting;
public class GenerateTextFile : MonoBehaviour
{
    public static GenerateTextFile instance;
    public byte[] contentByteArray;
    public string currentTicket;
    string contentData;
    Texture2D barcodeImage;
    string path;
    void Awake()
    {
        instance = this;
        
    }
    public void PrinterContentFOrLuckyCards(string ticketid)
    {
        path = Application.persistentDataPath + "/" + ticketid;
        currentTicket = ticketid;
        string header = "CASINO GAMES";
        string label = "For Amusement Only";
        string agent = "Agent : " + Datas.instance.loginDatas.username;
        string gameid = "Game ID : " + Datas.instance.luckycardsstartGameData.gameplay;
        string drawtime = "Draw Time : " + Datas.instance.luckyCardsPlayBetData.drawtime;
        string Tickettime = "Ticket Time : " + Datas.instance.luckyCardsPlayBetData.bettime.ToString();
        string totalPoint = "Total Point : " + Datas.instance.luckyCardsPlayBetData.totalbet;
        if (!System.IO.File.Exists(path))
        {
            string content = "\n" + header + "\n" + label + "\n" + agent + "\n" + gameid + "\n" + drawtime + "\n" + Tickettime + "\n" + totalPoint + "\n";
            File.AppendAllText(path,content);
            contentByteArray = Encoding.Unicode.GetBytes(content);

            Debug.Log("Saved File " +  path);   
        }
        List<byte> byteList = new List<byte>(contentByteArray);
        byteList.AddRange(QRCodeGenerator.instance.barcodeByteArray);
        File.WriteAllBytes(path,byteList.ToArray());
        Ticket.Load(out contentData, out barcodeImage);

        /* File.AppendAllText(path, header + "\n");
         File.AppendAllText(path, label + "\n");
         File.AppendAllText(path, agent + "\n");
         File.AppendAllText(path, gameid + "\n");
         File.AppendAllText(path, drawtime + "\n");
         File.AppendAllText(path, Tickettime + "\n");
         File.AppendAllText(path, totalPoint + "\n");*/


    }

    /* void CreateFile()
     {
         Debug.Log("Creating a File");
         if(!File.Exists(path))
         {
             File.Create(path).Close();

         }
     }

     public void ReadFile()
     {
         using(StreamReader reader = new StreamReader(path))
         {
             while(!reader.EndOfStream)
             {
                 Debug.Log(reader.ReadLine());
             }
         }
     }

     public void WriteFile()
     {
         string header = "CASINO GAMES";
         string label = "For Amusement Only";
         string agent = "Agent : " + Datas.instance.loginDatas.username;
         string gameid = "Game ID : " + Datas.instance.luckycardsstartGameData.gameplay;
         string drawtime = "Draw Time : " + Datas.instance.luckyCardsPlayBetData.drawtime;
         string Tickettime = "Ticket Time : " + Datas.instance.luckyCardsPlayBetData.bettime.ToString();
         string totalPoint = "Total Point : " + Datas.instance.luckyCardsPlayBetData.totalbet;
         using (StreamWriter writer = new StreamWriter(path))
         {
             writer.WriteLine(header);
             writer.WriteLine(label);
             writer.WriteLine(agent);
             writer.WriteLine(gameid);   
             writer.WriteLine(drawtime);
             writer.WriteLine(Tickettime);
             writer.WriteLine(totalPoint);
         }
     }*/
}

public class Ticket
{
    public static string currentTicketID;
    [Serializable]
    public class Header
    {
        public int contentByteSize;

    
    }
    public static void Save(string content, Texture2D barcode,string ticketid)
    {
        currentTicketID = ticketid;
        byte[] contentByteArray = Encoding.Unicode.GetBytes(content);
        byte[] barcodeByteArray = barcode.EncodeToPNG();

        Header header = new Header { contentByteSize = contentByteArray.Length };
        string headerjson = JsonUtility.ToJson(header);
        byte[] hearderJsonByteArray = Encoding.Unicode.GetBytes(headerjson);
        ushort headerSize = (ushort)hearderJsonByteArray.Length;
        byte[] headersizeByteArray = BitConverter.GetBytes(headerSize);


        List<byte> byteList = new List<byte>();

        byteList.AddRange(headersizeByteArray);
        byteList.AddRange(hearderJsonByteArray);
        byteList.AddRange(contentByteArray);
        byteList.AddRange(barcodeByteArray);

        File.WriteAllBytes(Application.persistentDataPath + currentTicketID , byteList.ToArray());
    }

    public static void Load(out string contentdata, out Texture2D barcodeImage)
    {
        byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + "/" +  currentTicketID);
        List<byte> byteList = new List<byte>(byteArray); 
        ushort headerSize = BitConverter.ToUInt16(new byte[] { byteArray[0], byteArray[1] }, 0);
        List<byte> headerByteList = byteList.GetRange(2, headerSize);
        string headJson = Encoding.Unicode.GetString(headerByteList.ToArray());
        Debug.Log("headJson is " + headJson);
        Header header = JsonUtility.FromJson<Header> (headJson);


        List<byte> contentByteList = byteList.GetRange(2 + headerSize, header.contentByteSize);
        contentdata = Encoding.Unicode.GetString (contentByteList.ToArray());
        Debug.Log("Content is " + contentdata);

        int startIndex = 2 + headerSize + header.contentByteSize;

        int endIndex = byteArray.Length - startIndex;

        List<byte> barcodeByteArray = byteList.GetRange(startIndex, endIndex);
        barcodeImage = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        barcodeImage.LoadImage(barcodeByteArray.ToArray()) ;
    }
}
