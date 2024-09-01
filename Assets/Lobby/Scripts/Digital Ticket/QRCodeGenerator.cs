using UnityEngine;
using ZXing;
using ZXing.QrCode;
using System.IO;
using System.Collections.Generic;
using System;
public class QRCodeGenerator : MonoBehaviour {

    public static QRCodeGenerator instance;
    [SerializeField]
    private string currentTicket;
    [SerializeField]
    private Texture2D encoded;

    private Color32[] generatedColorData;
    private int width, height;
    private Rect screenRect;
    public Texture2D barcodeImage;
    public byte[] barcodeByteArray;
    private void Awake()
    {
        instance = this;
    }
    // create a reader with a custom luminance source
    private BarcodeReader barcodeReader = new BarcodeReader {
        AutoRotate = false,
        Options = new ZXing.Common.DecodingOptions {
            TryHarder = false
        }
    };

    private BarcodeWriter writer;
    private Result result;

    public void GenerateBarcode(string ticketid) {

        currentTicket = ticketid;

        screenRect = new Rect(0, 0, Screen.width, Screen.height);

        encoded = new Texture2D(512, 128);
        generatedColorData = new Color32[512 * 128];

        writer = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_39,
            Options = new QrCodeEncodingOptions
            {
                Height = encoded.height,
                Width = encoded.width
            }
        };
        SaveBarcode();

    }

     private void SaveBarcode() {

        generatedColorData = writer.Write(currentTicket); // -> performance heavy method
        encoded.SetPixels32(generatedColorData); // -> performance heavy method
        encoded.Apply();
        barcodeByteArray = encoded.EncodeToPNG();
        var dirPath = Application.persistentDataPath;

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + currentTicket + ".png", barcodeByteArray);
        barcodeImage = encoded;

    }

   

  

    

   
}
