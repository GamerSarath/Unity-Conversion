using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Test_PrintingTool : MonoBehaviour {

    public string filePath = "";

    public PrintingTool printingTool;

    void Start()
    {
        if(File.Exists(filePath))
        {
            printingTool.CmdPrintThreaded(filePath);
            printingTool.StartCheckIsPrintingDone();
        }
        else
        {
            
            Debug.LogWarning("No Document Found in " + filePath);
        }
       
    }

}
