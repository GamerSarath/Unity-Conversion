using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JeethoRafther_Gamemanager : MonoBehaviour
{

    public static JeethoRafther_Gamemanager instance;
    public float totalUserCredit;
    public List<GameObject> horses;
    public int currentBetamount = 5;
    public List<int> betAmount;
    public List<int> betTakenAmount;
    public JeethoRafther_Horse selectedHorse;
    public List<int> repeatList;
    public List<Sprite> winHistory;
    public Sprite[] horseSprites;
    public int gameCount;
    public int winReward;
    public int totalBetAmount;
    public float timeOffset;
    public int currentWinner;
    public string currentticketID;
    public string claimableTicket;
    public int claimedBalance;
    public int unclaimedBalance;
    public InputField claimField;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SaveAndRetrieveBalance();
    }
    public void ChangeBetAmount(int amount)
    {
        currentBetamount = amount;
    }

    public void AddHorseBet(int index)
    {
        
        switch (index)
        {
            case 0:
                betAmount[0] += currentBetamount;
               
                JeethoRafther_UIManager.instance.betAmountsText[0].text = betAmount[0].ToString();
                Debug.Log("Bet amount is " + JeethoRafther_UIManager.instance.betAmountsText[0].text);

                break;

            case 1:
                betAmount[1] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[1].text = betAmount[1].ToString();
                break;

            case 2:
                betAmount[2] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[2].text = betAmount[2].ToString();
                break;

            case 3:
                betAmount[3] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[3].text = betAmount[3].ToString();
                break;

            case 4:
                betAmount[4] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[4].text = betAmount[4].ToString();
                break;

            case 5:
                betAmount[5] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[5].text = betAmount[5].ToString();
                break;

            case 6:
                betAmount[6] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[6].text = betAmount[6].ToString();
                break;

            case 7:
                betAmount[7] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[7].text = betAmount[7].ToString();
                break;

            case 8:
                betAmount[8] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[8].text = betAmount[8].ToString();
                break;

            case 9:
                betAmount[9] += currentBetamount;
                JeethoRafther_UIManager.instance.betAmountsText[9].text = betAmount[9].ToString();
                break;
        }
        /*for (int i = 0; i < betAmount.Count; i++)
        {

        }*/
       
    }

    public void Doubles()
    {
       for(int i = 0; i < 10; i++)
        {
            betAmount[i] *= 2;
            JeethoRafther_UIManager.instance.betAmountsText[i].text = betAmount[i].ToString();
        }
    }

    public void UpdateDrawTimeMethod()
    {
        string[] temp = Datas.instance.jeethoRaftherStartGameData.horserace_next_draw.Split(" ");
        JeethoRafther_UIManager.instance.nextdrawTimeText.text = temp[1];

    }

    public void Clear()
    {
        for (int i = 0; i < betAmount.Count; i++)
        {
            betTakenAmount[i] += betAmount[i];
            betAmount[i] = 0;
          
            JeethoRafther_UIManager.instance.betAmountsText[i].text = betAmount[i].ToString();
        }
    
        
            
    }

    public void Repeat()
    {
        for (int i = 0; i < 10; i++)
        {
            betTakenAmount[i] = repeatList[i];

            repeatList[i] = 0;
        }
    }

    public void Bet()
    {
        //  betTakenAmount = betAmount;
        Clear();
        totalBetAmount = betTakenAmount[0] + betTakenAmount[1] + betTakenAmount[2] + betTakenAmount[3] + betTakenAmount[4] + betTakenAmount[5] + betTakenAmount[6] + betTakenAmount[7] + betTakenAmount[8] + betTakenAmount[9];
        // StartCoroutine(ClearBets());
        JeethoRafther_UIManager.instance.totalBetAmountText.text = totalBetAmount.ToString();
       JeethoRafther_Gamemanager.instance.totalUserCredit -= totalBetAmount; 
        JeethoRafther_UIManager.instance.balanceText.text = totalUserCredit.ToString();
        //StartCoroutine(Datas.instance.DrawBet(16));
       StartCoroutine(CallPlayBet());
    }

    IEnumerator ClearBets()
    {
        yield return new WaitForSeconds(2);
        Clear();
    }

    public IEnumerator CallPlayBet()
    {
        if((JeethoRafther_Timer.Instance.timeLeft) <= 10)
        {
            ErrorHandler.Instance.InstantiateErrorHandlerUI("SORRY!!", "NO MORE BETS PLEASE", "OKAY", true, 0);
        }
        StartCoroutine(Datas.instance.PlayBet(totalBetAmount,(int)JeethoRafther_Gamemanager.instance.totalUserCredit, Datas.instance.jeethoRaftherStartGameData.gameplay, betTakenAmount,16));
        totalBetAmount = 0;
        Debug.Log(betTakenAmount.Count);
        for(int i = betTakenAmount.Count - 1 ;i>= 0; i--)
        {
           // Debug.Log("i is " + i);
            betTakenAmount[i] = 0;

        }
        yield return new WaitForSeconds(3);
        QRCodeGenerator.instance.GenerateBarcode(Datas.instance.jeethoraftherPlayBetDatas.unique_id);
        // GenerateTextFile.instance.PrinterContentFOrLuckyCards(Datas.instance.luckyCardsPlayBetData.unique_id);
        GenerateDigitalTicket.TakeScreenShotStaticMethod(1024, 1024, Datas.instance.jeethoraftherPlayBetDatas.unique_id, 14);
        yield return new WaitForSeconds(3);
        Debug.Log("Printing path is " + Application.persistentDataPath + Datas.instance.jeethoraftherPlayBetDatas.unique_id + ".png");
        //PrintingManager.instance.PrintFiles(Application.persistentDataPath + Datas.instance.luckyCardsPlayBetData.unique_id + ".png");//Datas.instance.luckyCardsPlayBetData.unique_id + ".png"
        string filepath = Application.dataPath + "/Resources/" + Datas.instance.jeethoraftherPlayBetDatas.unique_id + ".png";
        PrintingManager.instance.PrintFiles(filepath);
    }
    public void SaveAndRetrieveBalance()
    {
        if (!PlayerPrefs.HasKey("UnclaimedBalance_JeethoRafther"))
        {
            PlayerPrefs.SetInt("UnclaimedBalance_JeethoRafther", 0);
        }
        else
        {
            unclaimedBalance = PlayerPrefs.GetInt("UnclaimedBalance_JeethoRafther");
        }

        if (!PlayerPrefs.HasKey("ClaimedBalance_JeethoRafther"))
        {
            PlayerPrefs.SetInt("ClaimedBalance_JeethoRafther", 0);
        }
        else
        {
            claimedBalance = PlayerPrefs.GetInt("ClaimedBalance_JeethoRafther");

        }
    }
    public void AddBalanceFromBackendAutoClaimToVariables()
    {
        Debug.LogWarning("Adding Balance From Backend Auto Claim");
        if (JeethoRafther_UIManager.instance.autoClaimToggle.isOn)
        {
            claimableTicket = Datas.instance.jeethoraftherPlayBetDatas.unique_id;
            Debug.LogWarning("Inside AuotClaim");
            StartCoroutine(Datas.instance.ClaimBet(16, claimableTicket));
            claimedBalance += Datas.instance.jeethoRaftherDrawBetDatas.horserace_winAmount;
            totalUserCredit += claimedBalance;
            totalUserCredit = (float)Datas.instance.jeethoraftherClaimBetDatas.credit;
            JeethoRafther_UIManager.instance.balanceText.text = totalUserCredit.ToString();
            PlayerPrefs.SetInt("ClaimedBalance", claimedBalance);
        }
        else
        {
            Debug.LogWarning("Outside AutoClaim");
            unclaimedBalance += Datas.instance.jeethoRaftherDrawBetDatas.horserace_winAmount;
            PlayerPrefs.SetInt("UnclaimedBalance", unclaimedBalance);

        }
    }

    public void OnCLickClaimBUtton()
    {
        Debug.Log("Calling unClaimed Button");
        StartCoroutine(Datas.instance.GetSummary(16, DateTime.Now, DateTime.Today.AddDays(-7), 1, 2));
        foreach (string claimTicket in Datas.instance.jeethoRaftherGameSummaryDatas.game_id)
        {
            Debug.Log("Unclaimed Ticket Id is " + claimTicket);
            if (currentticketID == claimTicket)
            {
                StartCoroutine(Datas.instance.ClaimBet(16, claimTicket));
                totalUserCredit = (float)Datas.instance.jeethoraftherClaimBetDatas.credit;
                unclaimedBalance = 0;
            }
        }
        
        JeethoRafther_UIManager.instance.balanceText.text = totalUserCredit.ToString();
    }

    public void OnTicketValueChanged()
    {
        currentticketID = claimField.text;

    }


}
