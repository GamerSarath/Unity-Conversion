using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fun_Target_Ui_Manager : MonoBehaviour
{
    public static Fun_Target_Ui_Manager instance;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI[] betAmountsText;
    public TMP_Text balanceamountText;
    public TMP_Text usernameText;
    public TMP_Text gameidText;
    public TMP_Text timeleftText;
    //public GameObject infoPanel;
    //public GameObject settingsPanel;
    //public GameObject salesReportPanel;
    // public TextMeshProUGUI TotalbetAmountsText;
    void Start()
    {
        instance = this;
    }
}
