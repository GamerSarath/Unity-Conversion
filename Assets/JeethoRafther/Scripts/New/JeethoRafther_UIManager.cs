using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//using static UnityEditor.ShaderData;
using System.Globalization;
using UI.Dates;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
public class JeethoRafther_UIManager : MonoBehaviour
{

    public static JeethoRafther_UIManager instance;
    [SerializeField] TMP_Text timeLeftText;
    [SerializeField] GameObject bgPanel;
    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject winnerPanel;
    public Sprite[] winningSprites;
    public Image winningHorse;
    public RectTransform runningHorsePanel;
    public Vector4 runninghorserPanelosition;
    public TMP_Text[] betAmountsText;
    public List<Image> historySlots;
    public List<Text> historyTime;
    public TMP_Text winText;
    public TMP_Text nextdrawTimeText;
    public TMP_Text totalBetAmountText;

    [Header("Header Panel")]
    public TMP_Text gameIdText;
    public TMP_Text balanceText;
    public Toggle autoClaimToggle;

    public GameObject infoPanelObject;

    public GameObject rulesPanelObject;
    public GameObject reportPanelObject;
    public GameObject resultPanelObject;
    public GameObject gamehistoryPanelObject;
    public GameObject unclaimedPanelObject;

    public GameObject infofresultItemObect;

    public Transform inforesultItemParent;
    public GameObject inforeportItemObect;

    public Transform infounclaimedticketstemParent;
    public GameObject infounclaimedticketsItemObject;
    public Transform infohistoryItemParent;
    public GameObject infohistoryItemObject;

    public Transform inforeportItemParent;

    public int unclaimedBalance;
    public int claimedBalance;
    public string currentTicket;
    public string claimableTicket;
    string claimTicket;
    public DatePicker todatePicker;
    public DatePicker fromdatePicker;

    public DatePicker historytodatePicker;
    public DatePicker historyfromdatePicker;
    public bool isInsidetheRange;
    public string startDate;
    public string endDate;
    public void Start()
    {
        runninghorserPanelosition = runningHorsePanel.localPosition;
    }
    public void UpdateTimeLeftText(float timeLeft)
    {
        timeLeftText.text = timeLeft.ToString();
    }

    public void TurnOffBG()
    {
        bgPanel.SetActive(false);
    }

    public void TurnOnBG()
    {
        bgPanel.SetActive(true);
    }

    public void UpdateHeaderaPanel()
    {
        gameIdText.text = Datas.instance.jeethoRaftherStartGameData.gameplay.ToString();
        balanceText.text = Datas.instance.jeethoRaftherStartGameData.usercredit.ToString();
        JeethoRafther_Gamemanager.instance.totalUserCredit = float.Parse(Datas.instance.jeethoRaftherStartGameData.usercredit, CultureInfo.InvariantCulture);
    }
    public void AddHistoryWithoutBackend()
    {
        Debug.Log("Callling Add History");
        if (JeethoRafther_Gamemanager.instance.winHistory.Count >= 0)
        {
            historySlots[0].sprite = JeethoRafther_Gamemanager.instance.winHistory[0];
            historySlots[0].enabled = true;
        }
        if (JeethoRafther_Gamemanager.instance.gameCount == 1)
        {
            historySlots[0].sprite = JeethoRafther_Gamemanager.instance.winHistory[0];

            historySlots[1].sprite = JeethoRafther_Gamemanager.instance.winHistory[1];
            historySlots[1].enabled = true;
        }
        if (JeethoRafther_Gamemanager.instance.gameCount == 2)
        {

            historySlots[0].sprite = JeethoRafther_Gamemanager.instance.winHistory[0];

            historySlots[1].sprite = JeethoRafther_Gamemanager.instance.winHistory[1];
            historySlots[2].sprite = JeethoRafther_Gamemanager.instance.winHistory[2];
            historySlots[2].enabled = true;
        }
        if (JeethoRafther_Gamemanager.instance.gameCount == 3)
        {
            historySlots[0].sprite = JeethoRafther_Gamemanager.instance.winHistory[0];

            historySlots[1].sprite = JeethoRafther_Gamemanager.instance.winHistory[1];
            historySlots[2].sprite = JeethoRafther_Gamemanager.instance.winHistory[2];
            historySlots[3].sprite = JeethoRafther_Gamemanager.instance.winHistory[3];
            historySlots[3].enabled = true;
        }
        if (JeethoRafther_Gamemanager.instance.gameCount == 4)
        {
            historySlots[0].sprite = JeethoRafther_Gamemanager.instance.winHistory[0];

            historySlots[1].sprite = JeethoRafther_Gamemanager.instance.winHistory[1];
            historySlots[2].sprite = JeethoRafther_Gamemanager.instance.winHistory[2];
            historySlots[3].sprite = JeethoRafther_Gamemanager.instance.winHistory[3];
            historySlots[4].sprite = JeethoRafther_Gamemanager.instance.winHistory[4];
            historySlots[4].enabled = true;
        }
        if (JeethoRafther_Gamemanager.instance.gameCount == 5)
        {
            historySlots[0].sprite = JeethoRafther_Gamemanager.instance.winHistory[0];

            historySlots[1].sprite = JeethoRafther_Gamemanager.instance.winHistory[1];
            historySlots[2].sprite = JeethoRafther_Gamemanager.instance.winHistory[2];
            historySlots[3].sprite = JeethoRafther_Gamemanager.instance.winHistory[3];
            historySlots[4].sprite = JeethoRafther_Gamemanager.instance.winHistory[4];
            historySlots[5].sprite = JeethoRafther_Gamemanager.instance.winHistory[5];
            historySlots[5].enabled = true;
        }

    }

    public void HistoryWithBackend()
    {
        Debug.Log(" Count is " + Datas.instance.jeethoRaftherStartGameData.horserace_history.Count);
        if (Datas.instance.jeethoRaftherStartGameData.horserace_history.Count > 0)
        {
            historySlots[0].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[0]))];
            historyTime[0].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[0];
            historySlots[1].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[1]))];
            historyTime[1].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[1];

            historySlots[2].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[2]))];
            historyTime[2].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[2];

            historySlots[3].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[3]))];
            historyTime[3].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[3];

            historySlots[4].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[4]))];
            historyTime[4].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[4];

            historySlots[5].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[5]))];
            historyTime[5].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[5];

            historySlots[6].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[6]))];
            historyTime[6].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[6];

            historySlots[7].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[7]))];
            historyTime[7].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[7];

            historySlots[8].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[8]))];
            historyTime[8].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[8];

            historySlots[9].sprite = JeethoRafther_Gamemanager.instance.horseSprites[(System.Int32.Parse(Datas.instance.jeethoRaftherStartGameData.horserace_history[9]))];
            historyTime[9].text = Datas.instance.jeethoRaftherStartGameData.horserace_history_time[9];


        }
    }
    public void TurnOnPlayPanel()
    {
        playPanel.SetActive(true);
    }

    public void TurnOffPlayPanel()
    {
        playPanel.SetActive(false);
    }

    public void TurnOnWinnerPanel()
    {
        winnerPanel.SetActive(true);
    }
    public void TurnOffWinnerPanel()
    {
        winnerPanel.SetActive(false);
    }
    private void Awake()
    {
        instance = this;
    }


    public void OnClickInfoButton()
    {
        infoPanelObject.SetActive(true);
        rulesPanelObject.SetActive(true);
        resultPanelObject.SetActive(false);
        gamehistoryPanelObject.SetActive(false);
        unclaimedPanelObject.SetActive(false);
        reportPanelObject.SetActive(false);

    }

    public void OnCLickCloseInfoPanel()
    {
        infoPanelObject.SetActive(false);
        rulesPanelObject.SetActive(false);
        resultPanelObject.SetActive(false);
        gamehistoryPanelObject.SetActive(false);
        unclaimedPanelObject.SetActive(false);
        reportPanelObject.SetActive(false);
    }

    public void OnClickRulesPanel()
    {
        rulesPanelObject.SetActive(true);
        resultPanelObject.SetActive(false);
        gamehistoryPanelObject.SetActive(false);
        unclaimedPanelObject.SetActive(false);
        reportPanelObject.SetActive(false);
    }

    public void OnClickReportPanel()
    {
        StartCoroutine(OnClickInfoReport());
        rulesPanelObject.SetActive(false);
        resultPanelObject.SetActive(false);
        gamehistoryPanelObject.SetActive(false);
        unclaimedPanelObject.SetActive(false);
        reportPanelObject.SetActive(true);
    }
    public void OnClickHistoryPanel()
    {
        rulesPanelObject.SetActive(false);
        resultPanelObject.SetActive(false);
        gamehistoryPanelObject.SetActive(true);
        unclaimedPanelObject.SetActive(false);
        reportPanelObject.SetActive(false);
        OnClickJeethoRaftherHistoryPanel();

    }
    public void OnClickResultPanel()
    {
        rulesPanelObject.SetActive(false);
        resultPanelObject.SetActive(true);
        gamehistoryPanelObject.SetActive(false);
        unclaimedPanelObject.SetActive(false);
        reportPanelObject.SetActive(false);
        StartCoroutine(GetRsultPopUp());    }

    IEnumerator GetRsultPopUp()
    {
        StartCoroutine(Datas.instance.GetSummary(16, DateTime.Now, DateTime.Today.AddDays(-7), 1, 2));

        Debug.Log("Called Reslt Popup Coroutine");
        yield return new WaitForSeconds(3);
        Debug.LogWarning("Waiting Finished");
        foreach (Transform t in inforesultItemParent)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < Datas.instance.jeethoRaftherGameSummaryDatas.result.Count; i++)
        {
            if (Datas.instance.jeethoRaftherGameSummaryDatas.result[i] < 10)
            {
                Debug.Log("I is " + Datas.instance.jeethoRaftherGameSummaryDatas.result[i]);
                GameObject go = Instantiate(infofresultItemObect, inforesultItemParent);
                go.GetComponent<JeethoRafther_ResultItemPopup>().drawTimeText.enabled = true;
                go.GetComponent<JeethoRafther_ResultItemPopup>().resultImage.enabled = true;
                go.GetComponent<JeethoRafther_ResultItemPopup>().drawTimeText.text = Datas.instance.jeethoRaftherGameSummaryDatas.draw_time[i];
                go.GetComponent<JeethoRafther_ResultItemPopup>().resultImage.sprite = JeethoRafther_Gamemanager.instance.horseSprites[Datas.instance.jeethoRaftherGameSummaryDatas.result[i]];
            }
          
           
        }

    }
    public void OnClickUnclaimedTickets()
    {
        StartCoroutine(Datas.instance.GetSummary(16, DateTime.Now, DateTime.Today.AddDays(-7), 1, 2));

        rulesPanelObject.SetActive(false);
        resultPanelObject.SetActive(false);
        gamehistoryPanelObject.SetActive(false);
        unclaimedPanelObject.SetActive(true);
        reportPanelObject.SetActive(false);
        foreach (Transform t in infounclaimedticketstemParent)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < Datas.instance.jeethoRaftherGameSummaryDatas.game_id.Count; i++)
        {
            Debug.Log("value is " + OnClickJeethoRaftherViewUnclaimedTickets(Datas.instance.jeethoRaftherGameSummaryDatas.draw_time[i]));
            if (OnClickJeethoRaftherViewUnclaimedTickets(Datas.instance.jeethoRaftherGameSummaryDatas.draw_time[i]))
            {
                GameObject go = Instantiate(infounclaimedticketsItemObject, infounclaimedticketstemParent);
                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().ticketIDText.text = Datas.instance.jeethoRaftherGameSummaryDatas.game_id[i];
                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().gameIDText.text = Datas.instance.jeethoRaftherGameSummaryDatas.game_play[i].ToString();
                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().startpointText.text = Datas.instance.jeethoRaftherGameSummaryDatas.start_point[i].ToString();

                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().playedText.text = Datas.instance.jeethoRaftherGameSummaryDatas.play[i].ToString();

                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().wonText.text = Datas.instance.jeethoRaftherGameSummaryDatas.win[i].ToString();

                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().endpointText.text = Datas.instance.jeethoRaftherGameSummaryDatas.end_point[i].ToString();
                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().endText.text = Datas.instance.jeethoRaftherGameSummaryDatas.end[i].ToString();
                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().statusText.text = Datas.instance.jeethoRaftherGameSummaryDatas.play_status[i];

                //go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().resultImage.sprite = Datas.instance.luckyCardsGameSummaryData.

                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().drawtimeText.text = Datas.instance.jeethoRaftherGameSummaryDatas.draw_time[i].ToString();

                go.GetComponent<JeethoRafther_unclaimedPanelItemList>().tickettimeText.text = Datas.instance.jeethoRaftherGameSummaryDatas.ticket_time[i].ToString();
            }

        }


    

    }
    public bool OnClickJeethoRaftherViewUnclaimedTickets(string currentdate)
    {

        /* Debug.Log(" To Date Check Befor " + (System.DateTime.Parse(fromdatePicker.Ref_InputField.text)));
         Debug.Log(" From Date Check Befor " + System.DateTime.Parse(todatePicker.Ref_InputField.text));*/

        DateRange range = new DateRange((System.DateTime.Parse(startDate)), System.DateTime.Parse(endDate));
        isInsidetheRange = range.Includes(System.DateTime.Parse(currentdate));
        Debug.Log(range.Includes(System.DateTime.Parse(currentdate)));
        return isInsidetheRange;
    }
    public void OnValuceChangedInDatePicker(string startdate, string enddate)
    {
        startDate = startdate;
        endDate = enddate;
    }

    public void OnValueChangedCall()
    {
        OnValuceChangedInDatePicker(fromdatePicker.Ref_InputField.text, todatePicker.Ref_InputField.text);
    }

    public void OnValueChangedCallHistory()
    {
        OnValuceChangedInDatePicker(historyfromdatePicker.Ref_InputField.text, historytodatePicker.Ref_InputField.text);
    }

    public void OnClickJeethoRaftherHistoryPanel()
    {

        foreach (Transform t in infohistoryItemParent)
        {
            Destroy(t.gameObject);
        }
        StartCoroutine(Datas.instance.GetSummary(16, DateTime.Now, DateTime.Today.AddDays(-7), 1, 2));
        for (int i = 0; i < Datas.instance.jeethoRaftherGameSummaryDatas.game_id.Count; i++)
        {
            if (OnClickJeethoRaftherViewUnclaimedTickets(Datas.instance.jeethoRaftherGameSummaryDatas.ticket_time[i]))
            {
                GameObject go = Instantiate(infohistoryItemObject, infohistoryItemParent);
                go.GetComponent<JeethoRafther_HistoryPanelListItem>().ticketIDText.text = Datas.instance.jeethoRaftherGameSummaryDatas.game_id[i];
                go.GetComponent<JeethoRafther_HistoryPanelListItem>().gameIDText.text = Datas.instance.jeethoRaftherGameSummaryDatas.game_play[i].ToString();
                go.GetComponent<JeethoRafther_HistoryPanelListItem>().startpointText.text = Datas.instance.jeethoRaftherGameSummaryDatas.start_point[i].ToString();

                go.GetComponent<JeethoRafther_HistoryPanelListItem>().playedText.text = Datas.instance.jeethoRaftherGameSummaryDatas.play[i].ToString();

                go.GetComponent<JeethoRafther_HistoryPanelListItem>().wonText.text = Datas.instance.jeethoRaftherGameSummaryDatas.win[i].ToString();

                go.GetComponent<JeethoRafther_HistoryPanelListItem>().endpointText.text = Datas.instance.jeethoRaftherGameSummaryDatas.end_point[i].ToString();
                go.GetComponent<JeethoRafther_HistoryPanelListItem>().endText.text = Datas.instance.jeethoRaftherGameSummaryDatas.end[i].ToString();
                go.GetComponent<JeethoRafther_HistoryPanelListItem>().statusText.text = Datas.instance.jeethoRaftherGameSummaryDatas.play_status[i];

             //   go.GetComponent<JeethoRafther_HistoryPanelListItem>().resultImage.sprite = JeethoRafther_UIManager.instance.winnerSprites[Datas.instance.jeethoRaftherGameSummaryDatas.result[i]];

                go.GetComponent<JeethoRafther_HistoryPanelListItem>().drawtimeText.text = Datas.instance.jeethoRaftherGameSummaryDatas.draw_time[i].ToString();

                go.GetComponent<JeethoRafther_HistoryPanelListItem>().tickettimeText.text = Datas.instance.jeethoRaftherGameSummaryDatas.ticket_time[i].ToString();
            }
        }


    }

    public IEnumerator OnClickInfoReport()
    {

        foreach (Transform t in inforeportItemParent)
        {
            Destroy(t.gameObject);
        }
        StartCoroutine(Datas.instance.GetSummary(16, DateTime.Now, DateTime.Today.AddDays(-7), 1, 2));
        yield return new WaitForSeconds(2);
        GameObject go = Instantiate(inforeportItemObect, inforeportItemParent);
        go.GetComponent<JeethoRafther_ReportPanelListItem>().nameText.text = Datas.instance.loginDatas.username;
        go.GetComponent<JeethoRafther_ReportPanelListItem>().playText.text = Datas.instance.jeethoRaftherGameSummaryDatas.play[0];
        go.GetComponent<JeethoRafther_ReportPanelListItem>().winText.text = Datas.instance.jeethoRaftherGameSummaryDatas.win[0];
        go.GetComponent<JeethoRafther_ReportPanelListItem>().claimText.text = JeethoRafther_Gamemanager.instance.claimedBalance.ToString();
        go.GetComponent<JeethoRafther_ReportPanelListItem>().unclaimText.text = JeethoRafther_Gamemanager.instance.unclaimedBalance.ToString();
        go.GetComponent<JeethoRafther_ReportPanelListItem>().endText.text = Datas.instance.jeethoRaftherGameSummaryDatas.end[0].ToString();
        go.GetComponent<JeethoRafther_ReportPanelListItem>().commText.text = 0.ToString();
        go.GetComponent<JeethoRafther_ReportPanelListItem>().ntpText.text = 0.ToString();
    }
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public void OnWIndowMinimizeButtonClick()
    {
        ShowWindow(GetActiveWindow(), 2);
    }

    public void QuitApplication()
    {
        ResetDatas();
        SceneManager.LoadScene(1);
    }

    public void ResetDatas()
    {
        Debug.Log("Calling Reset Datas");

        Datas.instance.jeethoRaftherStartGameData.status = false;
        Datas.instance.tripplechancestartGameData.status = false;
        Datas.instance.jeethoRaftherStartGameData.status = false;

    }
}