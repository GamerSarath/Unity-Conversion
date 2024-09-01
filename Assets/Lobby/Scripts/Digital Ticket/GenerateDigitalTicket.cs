using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GenerateDigitalTicket : MonoBehaviour
{
    public static GenerateDigitalTicket Instance;
    private Camera ticketCamera;
    public string currentTicket;
    bool takeScreenShotOnNextFrame;

    [SerializeField] Text username;
    [SerializeField] Text gameid;
    [SerializeField] Text drawTime;
    [SerializeField] Text ticketTime;
    [SerializeField] Text totalPoints;
    [SerializeField] RawImage barcodeImage;
    private void Awake()
    {
        Instance = this;
        ticketCamera = GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if(takeScreenShotOnNextFrame)
        {

            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = ticketCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0,0, renderTexture.width,renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Resources/" + currentTicket + ".png", byteArray);
            Debug.Log("Saved Ticket in " + Application.dataPath + "/Resources/" + currentTicket + ".png");

            RenderTexture.ReleaseTemporary(renderTexture);
            ticketCamera.targetTexture = null; 
        }
    }
    void TakeScreenShot(int width, int height, string ticketid,int gameid)
    {
        currentTicket = ticketid;
        if(gameid == 16)
        {
            FillLuckyCardsDetails();
        }
        else if(gameid == 14)
        {
            FillJeethoRaftherDetails();

        }

        ticketCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShotOnNextFrame = true;
    }

    public static void TakeScreenShotStaticMethod(int width, int height, string ticketid,int gameid)
    {
        Instance.TakeScreenShot(width, height, ticketid, gameid);
    }

    void FillLuckyCardsDetails()
    {
        username.text = "Agent ID :" + Datas.instance.loginDatas.username;
        gameid.text = "Game ID : " + Datas.instance.luckycardsstartGameData.gameplay.ToString();
        drawTime.text = "Draw Time : " + Datas.instance.luckyCardsPlayBetData.drawtime;
        ticketTime.text ="Ticket Time : " + Datas.instance.luckyCardsPlayBetData.bettime;
        totalPoints.text = "Total Points : " + Datas.instance.luckyCardsPlayBetData.totalbet;
        barcodeImage.texture = QRCodeGenerator.instance.barcodeImage;
    }

    void FillJeethoRaftherDetails()
    {
        username.text = "Agent ID :" + Datas.instance.loginDatas.username;
        gameid.text = "Game ID : " + Datas.instance.jeethoraftherPlayBetDatas.gameplay.ToString();
        drawTime.text = "Draw Time : " + Datas.instance.jeethoraftherPlayBetDatas.drawtime;
        ticketTime.text = "Ticket Time : " + Datas.instance.jeethoraftherPlayBetDatas.bettime;
        totalPoints.text = "Total Points : " + Datas.instance.jeethoraftherPlayBetDatas.totalbet;
        barcodeImage.texture = QRCodeGenerator.instance.barcodeImage;
    }
}
