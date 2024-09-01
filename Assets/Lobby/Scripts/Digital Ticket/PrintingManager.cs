﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sfs2X.Entities.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
public class PrintingManager : MonoBehaviour
{
    public static PrintingManager instance;
    string path = null;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        path = Application.dataPath + "/Ticket.pdf";  
       
    }

   /* public void GenerateFile() {
        if (File.Exists(path))
            File.Delete(path);
        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            var writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            document.NewPage();

            var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
           Paragraph p = new Paragraph(string.Format("Ticket Id : {0}",12345 )); //iSFSObject.GetUtfString("TICKET_ID"
            p.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
          
                p = new Paragraph(string.Format("Bet Number : {0}     BetAmount : {1}", 1, 100));
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);
        

            document.Close();
            writer.Close();
        }



        //StreamWriter writer = new StreamWriter(path, false);
        //writer.WriteLine(string.Format("Ticket Id : {0}",iSFSObject.GetUtfString("TICKET_ID")));
        //var betting = iSFSObject.GetSFSArray("BET_DETAILS");
        //for (int i = 0; i< betting.Count;i++)
        //    writer.WriteLine(string.Format("Bet Number : {0}     BetAmount : {1}", betting.GetSFSObject(i).GetUtfString("BET_NUM"), betting.GetSFSObject(i).GetDouble("BET_AMOUNT")));
        //writer.Close();

        PrintFiles();
    }
*/
    public void PrintFiles(string filepath)
    {
        try
        {
            Debug.Log(filepath);
            if (path == null)
                return;

            if (File.Exists(filepath))
            {
                Debug.Log("file found");
                //var startInfo = new System.Diagnostics.ProcessStartInfo(path);
                //int i = 0;
                //foreach (string verb in startInfo.Verbs)
                //{
                //    // Display the possible verbs.
                //    Debug.Log(string.Format("  {0}. {1}", i.ToString(), verb));
                //    i++;
                //}
            }
            else
            {
                Debug.Log("file not found");
                return;
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = filepath;
            //process.StartInfo.Verb = "print";

            process.Start();

            ProcessStartInfo printInfo = new ProcessStartInfo(filepath);
            printInfo.Verb = "print";
            printInfo.CreateNoWindow = true;
            printInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = printInfo;
            p.Start();
            p.WaitForExit();
        }
        catch (Exception e)
        {
            ErrorHandler.Instance.InstantiateErrorHandlerUI("TICKET PRINT ERROR", "UNABLE TO PRINT TICKET. TRY AGAIN", "OKAY", true, 0);

        }

        //process.WaitForExit();

    }
}
