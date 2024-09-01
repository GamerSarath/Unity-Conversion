using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun_Target_Game_Manager : MonoBehaviour
{
    public static Fun_Target_Game_Manager instance;
    public int currentBetamount = 5;
    public List<int> betAmount;
    public List<int> betTakenAmount;
    public List<int> repeatList;
    public Fun_Target_SpinManager spinManager;

    public int totalBetAmount;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }

    public void AddBet(int index)
    {
        switch (index)
        {
            case 0:
                betAmount[0] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[0].text = betAmount[0].ToString();

                break;
            case 1:
                betAmount[1] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[1].text = betAmount[1].ToString();

                break;
            case 2:
                betAmount[2] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[2].text = betAmount[2].ToString();

                break;
            case 3:
                betAmount[3] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[3].text = betAmount[3].ToString();

                break;
            case 4:
                betAmount[4] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[4].text = betAmount[4].ToString();

                break;
            case 5:
                betAmount[5] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[5].text = betAmount[5].ToString();

                break;
            case 6:
                betAmount[6] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[6].text = betAmount[6].ToString();

                break;
            case 7:
                betAmount[7] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[7].text = betAmount[7].ToString();

                break;
            case 8:
                betAmount[8] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[8].text = betAmount[8].ToString();

                break;
            case 9:
                betAmount[9] += currentBetamount;
                Fun_Target_Ui_Manager.instance.betAmountsText[9].text = betAmount[9].ToString();
                break;
        }
    }
    public void Doubles()
    {
        for (int i = 0; i < betAmount.Count; i++)
        {
            betAmount[i] *= 2;
            Fun_Target_Ui_Manager.instance.betAmountsText[i].text = betAmount[i].ToString();
        }
    }
    public void Clear()
    {
        for (int i = 0; i < betAmount.Count; i++)
        {
            betTakenAmount[i] += betAmount[i];
            betAmount[i] = 0;
            Fun_Target_Ui_Manager.instance.betAmountsText[i].text = betAmount[i].ToString();
        }
    }
    public void Repeat()
    {
        for (int i = 0; i < betAmount.Count; i++)
        {
            betAmount[i] = betTakenAmount[i];
            Debug.Log("repeat");
            Fun_Target_Ui_Manager.instance.betAmountsText[i].text = betAmount[i].ToString();
        }
    }
    public void Bet()
    {
        Clear();
        for (int i = 0; i < betTakenAmount.Count; i++)
        {
            totalBetAmount += betTakenAmount[i];
        }
        Debug.Log("total bet is" + totalBetAmount);
        // Dus_Ka_Dum_UImanager.instance.TotalbetAmountsText.text= totalBetAmount.ToString();
    }
    IEnumerator ClearBets()
    {
        yield return new WaitForSeconds(2);
        Clear();
    }
    //public void InfoOpen()
    //{
    //    Dus_Ka_Dum_UImanager.instance.settingsPanel.SetActive(false);
    //    Dus_Ka_Dum_UImanager.instance.salesReportPanel.SetActive(false);
    //    Dus_Ka_Dum_UImanager.instance.infoPanel.SetActive(true);
    //}
    //public void SettingsOpen()
    //{
    //    Dus_Ka_Dum_UImanager.instance.settingsPanel.SetActive(true);
    //    Dus_Ka_Dum_UImanager.instance.salesReportPanel.SetActive(false);
    //    Dus_Ka_Dum_UImanager.instance.infoPanel.SetActive(false);
    //}
    //public void SalesReportOpen()
    //{
    //    Dus_Ka_Dum_UImanager.instance.settingsPanel.SetActive(false);
    //    Dus_Ka_Dum_UImanager.instance.salesReportPanel.SetActive(true);
    //    Dus_Ka_Dum_UImanager.instance.infoPanel.SetActive(false);
    //}
    //public void Close()
    //{
    //    Dus_Ka_Dum_UImanager.instance.settingsPanel.SetActive(false);
    //    Dus_Ka_Dum_UImanager.instance.salesReportPanel.SetActive(false);
    //    Dus_Ka_Dum_UImanager.instance.infoPanel.SetActive(false);
    //}
}
