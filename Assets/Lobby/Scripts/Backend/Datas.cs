using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


[System.Serializable]
public class SerializableList<T>
{
    public List<T> list;
}

public class Datas : MonoBehaviour
{
    public static Datas instance;
    public DataClass data;
    public LoginData loginDatas;
    public TrippleChanceStartGameData tripplechancestartGameData;
    public LuckyCardsStartGameData luckycardsstartGameData;
    public JeethoRaftherStartGameData jeethoRaftherStartGameData;
    public FiftyTwoCardsStartGameData fiftyTwoCardsstartGameData;
    public FunTargetStartGameData funtargetStartGameData;
    public JeethoRaftherDrawBetDatas jeethoRaftherDrawBetDatas;
    public JeethoRaftherGameSummary jeethoRaftherGameSummaryDatas;
    public JeethoRaftherPlayBet jeethoraftherPlayBetDatas;
    public JeethoRaftherClaimBet jeethoraftherClaimBetDatas;
    public TrippleChanceDrawBetData trippleChanceDrawBetDatas;
    public LuckyCardsDrawBetDatas luckyCardsDrawBetDatas;
    public LuckyCardsGameSummary luckyCardsGameSummaryData;
    public LuckyCardsPlayBet luckyCardsPlayBetData;
    public LuckyCardsClaimBet luckyCardsClaimBetData;
    public bool gameStarted;
    public string startgameurl = "https://emezonez.in/unityconversion/game/startgame";
    public string drawbeturl = "https://emezonez.in/unityconversion/game/drawbet";
    public string playbeturl = "https://emezonez.in/unityconversion/game/playbet";
    public string summaryurl = "https://emezonez.in/unityconversion/game/gamesummary";
    public string claimbeturl = "https://emezonez.in/unityconversion/game/claimbet";
    SerializableList<int> betValues;
    public string jsonBetValues;
    public List<char> winDigits = new List<char>();
    public string symbolName;
    public string numberValue;
    public bool isClaimed;
    private void Awake()
    {
        instance = this;
        gameStarted = false;
        isClaimed = false;
        DontDestroyOnLoad(gameObject);
    }

    public void AddBetToList(List<int> intList)
    {
        betValues = new SerializableList<int>();
        betValues.list = new List<int>();
        for (int i = 0; i < intList.Count; i++)
        {
            betValues.list.Add(intList[i]);
        }
        jsonBetValues = JsonUtility.ToJson(betValues);
        string[] splitArray = jsonBetValues.Split('"');
        Debug.Log(splitArray[0] + " " + splitArray.Length);
        Debug.Log(splitArray[1] + " " + splitArray.Length);
        Debug.Log(splitArray[2]);
        splitArray = splitArray[2].Split(":");
        Debug.Log(splitArray[1]);
        splitArray = splitArray[1].Split("}");
        Debug.Log(splitArray[0]);
        jsonBetValues = splitArray[0];
    }
    public IEnumerator StartGame(int uid, string apitoken, int gameid)
    {
        
            WWWForm form = new WWWForm();
            form.AddField("uid", uid);
            form.AddField("api_token", apitoken);
            form.AddField("game_id", gameid);

            UnityWebRequest www = UnityWebRequest.Post(startgameurl, form);
            yield return www.Send();

            if (www.error != null)
            {
                Debug.Log(www.error);
                ErrorHandler.Instance.InstantiateErrorHandlerUI("RESULTING ERROR", www.error + " Try Restarting The Game", "OKAY", true, 0);

            }
            else
            {
                try
                {
                Debug.Log("Response is " + www.downloadHandler.text);


                if (tripplechancestartGameData.status)
                {
                    tripplechancestartGameData = JsonUtility.FromJson<TrippleChanceStartGameData>(www.downloadHandler.text);
                    UIManager.Instance.UpdateTimeListTexts();
                    UIManager.Instance.gameIdText.text = tripplechancestartGameData.tripple_gameplay.ToString();
                    UIManager.Instance.balanceAmount.text = tripplechancestartGameData.usercredit.ToString();
                    UIManager.Instance.usernameText.text = loginDatas.username;
                    if (tripplechancestartGameData.tripple_gametime >= 0)
                    {
                        Debug.Log("tRIPPLE cHANCE gAMEtIME uPDATED!!");
                        GameManager.Instance.timeUpdated = false;

                    }

                }
                if (jeethoRaftherStartGameData.status)
                {
                    Debug.Log("Jeetho Rafther calling");
                    jeethoRaftherStartGameData = JsonUtility.FromJson<JeethoRaftherStartGameData>(www.downloadHandler.text);
                    JeethoRafther_UIManager.instance.UpdateHeaderaPanel();
                    JeethoRafther_UIManager.instance.HistoryWithBackend();
                    JeethoRafther_Gamemanager.instance.UpdateDrawTimeMethod();

                }
                if (fiftyTwoCardsstartGameData.status)
                {
                    Debug.Log("52 Cards Calling");
                    fiftyTwoCardsstartGameData = JsonUtility.FromJson<FiftyTwoCardsStartGameData>(www.downloadHandler.text);
                    CardsGameManager.instance.SetHistroyFromBackend();


                }
                if (luckycardsstartGameData.status)
                {
                    luckycardsstartGameData = JsonUtility.FromJson<LuckyCardsStartGameData>(www.downloadHandler.text);
                    StartCoroutine(Datas.instance.GetSummary(14, DateTime.Now, DateTime.Today.AddDays(-7), 1, 1));

                    LuckyCards_GameController.instance.userCredit = float.Parse(luckycardsstartGameData.usercredit);

                    LuckyCards_GameController.instance.SetHistoryFromBackend();
                    if (LuckyCards_GameController.instance.autoClaim.isOn && luckyCardsClaimBetData.status)
                    {
                        Debug.LogWarning("AutoCalim Is On " + luckyCardsClaimBetData.credit);
                        LuckyCards_GameController.instance.userCredit = (float)luckyCardsClaimBetData.credit;
                        LuckyCards_GameController.instance.balanceAmountText.text = "Balance              " + LuckyCards_GameController.instance.userCredit.ToString();
                    }

                }
                if(funtargetStartGameData.status)
                {
                    Fun_Target_Ui_Manager.instance.balanceamountText.text = funtargetStartGameData.usercredit.ToString();
                    Fun_Target_Ui_Manager.instance.usernameText.text = loginDatas.username;
                    Fun_Target_Ui_Manager.instance.gameidText.text = funtargetStartGameData.gameplay.ToString();

                }
            }
                catch (Exception e)
                {
                ErrorHandler.Instance.InstantiateErrorHandlerUI("UNKNOWN ERROR", "SOMETHING WRONG HAPPEND, TRY AGAIN", "OKAY", true, 0);


                }
           
            }
       
    }
     
    public IEnumerator DrawBet(int gameId)
    {
        WWWForm form = new WWWForm();
            form.AddField("game_id", gameId);
            form.AddField("api_token", loginDatas.api_token);
            UnityWebRequest www = UnityWebRequest.Post(drawbeturl, form);
            yield return www.Send();
        Debug.Log("Response is " + www.downloadHandler.text);
        if (www.error != null)
        {
            Debug.Log(www.error);
            ErrorHandler.Instance.InstantiateErrorHandlerUI("RESULTING ERROR", www.error + " Try Restarting The Game", "OKAY", true, 0);

        }
        else
        {
/*
            try
            {*/
                if (gameId == 16)
                {
                    jeethoRaftherDrawBetDatas = JsonUtility.FromJson<JeethoRaftherDrawBetDatas>(www.downloadHandler.text);

                    JeethoRafther_Gamemanager.instance.currentWinner = System.Int32.Parse(Datas.instance.jeethoRaftherDrawBetDatas.win_number);
                    Debug.Log("Winnumber is " + JeethoRafther_Gamemanager.instance.currentWinner);
                    JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().minSPeed = 350;
                    JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().maxSpeed = 360;
                    JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().minAcceleration = 5;
                    JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().maxAcceeleration = 7;
                }
                else if (gameId == 1)
                {
                    trippleChanceDrawBetDatas = JsonUtility.FromJson<TrippleChanceDrawBetData>(www.downloadHandler.text);
             //   yield return new WaitForSeconds(3);
                    winDigits = IntToList(trippleChanceDrawBetDatas.tripple_winnumber);

                }
                else if (gameId == 14)
                {
                    luckyCardsDrawBetDatas = JsonUtility.FromJson<LuckyCardsDrawBetDatas>(www.downloadHandler.text);
                    switch (System.Int32.Parse(Datas.instance.luckyCardsDrawBetDatas.win_number))
                    {

                        case 0:
                            symbolName = "Heart";
                            numberValue = "Jack";
                            break;
                        case 1:
                            symbolName = "Spade";
                            numberValue = "Jack";
                            break;
                        case 2:
                            symbolName = "Diamond";
                            numberValue = "Jack";
                            break;
                        case 3:
                            symbolName = "Club";
                            numberValue = "Jack";
                            break;
                        case 4:
                            symbolName = "Heart";
                            numberValue = "Queen";
                            break;
                        case 5:
                            symbolName = "Spade";
                            numberValue = "Queen";
                            break;
                        case 6:
                            symbolName = "Diamond";
                            numberValue = "Queen";
                            break;
                        case 7:
                            symbolName = "Club";
                            numberValue = "Queen";
                            break;
                        case 8:
                            symbolName = "Heart";
                            numberValue = "King";
                            break;
                        case 9:
                            symbolName = "Spade";
                            numberValue = "King";
                            break;
                        case 10:
                            symbolName = "Diamond";
                            numberValue = "King";
                            break;
                        case 11:
                            symbolName = "Club";
                            numberValue = "King";
                            break;
                    }


                }
           /* }
            catch (Exception e)
            {
                ErrorHandler.Instance.InstantiateErrorHandlerUI("UNKNOWN ERROR", e.Message + "Kindly Restart The Game", "OKAY", true, 0);
 
                 Debug.Log("Response is " + www.downloadHandler.text);

            }*/
        }
        
        
       
    }

    public static List<char> IntToList(string value)
    {
        List<char> list = new List<char>();
        for (int i = 0; i < value.Length; i++)
        {
            list.Add(value[i]);
        }
        return list;
    }
    public IEnumerator PlayBet(int totalbet, int currentbalance, int gameplay, List<int> betvalues, int gameid)
    {
        AddBetToList(betvalues);
        WWWForm form = new WWWForm();
        form.AddField("api_token", loginDatas.api_token);
        form.AddField("game_id", gameid);
        form.AddField("total_bet", totalbet);
        form.AddField("current_balance", currentbalance);
        form.AddField("dev", 0);
        form.AddField("print_stat", 1);
        form.AddField("house", 0);
        form.AddField("game_play", gameplay);
        form.AddField("bet_values", jsonBetValues);
        Debug.Log("current balance is  " + currentbalance);
        UnityWebRequest www = UnityWebRequest.Post(playbeturl, form);
        yield return www.Send();

        if (www.error != null)
        {
            Debug.Log(www.error);
            ErrorHandler.Instance.InstantiateErrorHandlerUI("INVALID PARSING FOUND", "EMPTY CONTENT FOUND< KINDLY RETRY", "OKAY", true, 0);
        }
        else
        {
            try
            {
                if (gameid == 14)
                {
                    Debug.Log("Response is " + www.downloadHandler.text);
                    string resopnse = www.downloadHandler.text;
                    resopnse = resopnse.Substring(25);
                    string[] responsearray = resopnse.Split('"');
                    Debug.Log("Bet error is " + responsearray[0]);
                    if (responsearray[0] == "bet error")
                    {
                        ErrorHandler.Instance.InstantiateErrorHandlerUI("BET ERROR", "NO BETS PLACED", "OKAY", true, 0);
                    }
                    luckyCardsPlayBetData= JsonUtility.FromJson<LuckyCardsPlayBet>(www.downloadHandler.text);//
                    jsonBetValues = null;
                }
                else if (gameid == 16)
                {
                    Debug.Log("Response is " + www.downloadHandler.text);
                    string resopnse = www.downloadHandler.text;
                    resopnse = resopnse.Substring(25);
                    string[] responsearray = resopnse.Split('"');
                    Debug.Log("Bet error is " + responsearray[0]);
                    if (responsearray[0] == "bet error")
                    {
                        ErrorHandler.Instance.InstantiateErrorHandlerUI("BET ERROR", "NO BETS PLACED", "OKAY", true, 0);
                    }
                    jeethoraftherPlayBetDatas = JsonUtility.FromJson<JeethoRaftherPlayBet>(www.downloadHandler.text);//
                    jsonBetValues = null;
                }
            }
            catch(Exception ex)
            {
                ErrorHandler.Instance.InstantiateErrorHandlerUI("ERROR", ex.Message, "OKAY", true, 0);
            }
           
           
        }
    }

   /* public IENumerator PlayBet(int uniqueid, int gameid, int dev, int[] betsingle, int[]betdouble, int[] bettripple1, int[] bettripple2, int[] bettripple3, int[] bettripple4, int[] bettripple5, int[] bettripple6, int[] bettripple7, int[] bettripple8, int[] bettripple9, int[] bettripple10, float currentbalance, int toaltbet, int house, int printstat, string apitoken)
    {

        AddBetToList(betvalues);
        WWWForm form = new WWWForm();
        form.AddField("api_token", loginDatas.api_token);
        form.Ad0adField("game_id", gameid);
        form.AddField("total_bet", totalbet);
        form.AddField("current_balance", currentbalance);
        form.AddField("dev", 0);
        form.AddField("print_stat", 1);
        form.AddField("house", 0);
        form.AddField("game_play", gameplay);
        form.AddField("bet_values", jsonBetValues);
        Debug.Log("current balance is  " + currentbalance);
        UnityWebRequest www = UnityWebRequest.Post(playbeturl, form);
        yield return www.Send();aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        if (www.error != null)
        {
            Debug.Log(www.error);
            ErrorHandler.Instance.InstantiateErrorHandlerUI("INVALID PARSING FOUND", "EMPTY CONTENT FOUND< KINDLY RETRY", "OKAY", true, 0);
        }
    }*/
    public IEnumerator GetSummary(int gameId, DateTime startDate, DateTime endDate, int unclaimed, int all)
    {
        string startdate = startDate.ToString("yyyy-MM-dd");
        string enddate = endDate.ToString("yyyy-MM-dd");
        Debug.Log("Start Date is " + enddate);
        Debug.Log("End Date is " + startdate);
        WWWForm form = new WWWForm();
        form.AddField("game_id", gameId);
        form.AddField("api_token", loginDatas.api_token);
        form.AddField("dt1", enddate);
        form.AddField("dt2", startdate);
        form.AddField("unclaimed", unclaimed);
        form.AddField("all", all);
        UnityWebRequest www = UnityWebRequest.Post(summaryurl, form);
        yield return www.Send();

        if (www.error != null)
        {
            Debug.Log(www.error);
           // ErrorHandler.Instance.InstantiateErrorHandlerUI("RESULTING ERROR", www.error + " Try Restarting The Game", "OKAY", true, 0);

        }
        else
        {
            try
            {
                if (gameId == 14)
                {
                    Debug.Log("Download Handler Response is " + www.downloadHandler.text);
                    luckyCardsGameSummaryData = JsonUtility.FromJson<LuckyCardsGameSummary>(www.downloadHandler.text);
                }
                if (gameId == 16)
                {
                    Debug.Log("Download Handler Response is " + www.downloadHandler.text);
                    string resopnse = www.downloadHandler.text;
                    resopnse = resopnse.Substring(9);
                    string[] responsearray = resopnse.Split(':');
                    Debug.Log("Bet error is " + responsearray[1]);
                    if (responsearray[1] == "false}")
                    {
                        ErrorHandler.Instance.InstantiateErrorHandlerUI("DATA ERROR", "NO DATAS FETCHED, TRY AGAIN LATER", "OKAY", true, 0);
                    }
                    else
                    {

                    }

                }
            }
            catch(Exception ex)
            {
                ErrorHandler.Instance.InstantiateErrorHandlerUI("UNKOWN ERROR", ex.Message + " Try Restarting The Game", "OKAY", true, 0);

            }


        }


    }

    public IEnumerator ClaimBet(int gameId, string uniqueid)   
    {
        isClaimed = false;
        Debug.Log("Unique id is " + uniqueid);
        WWWForm form = new WWWForm();
        form.AddField("game_id", gameId);
        form.AddField("unique_id", uniqueid);
        form.AddField("api_token", loginDatas.api_token);
      
        UnityWebRequest www = UnityWebRequest.Post(claimbeturl, form);
        yield return www.Send();

        if (www.error != null)
        {
            Debug.Log(www.error);
            //ErrorHandler.Instance.InstantiateErrorHandlerUI("RESULTING ERROR", www.error + " Try Restarting The Game", "OKAY", true, 0);

        }
        else
        {
            try
            {
                Debug.Log("ClaimBet Handler Response is " + www.downloadHandler.text);
                if (gameId == 14)
                {
                    if (!isClaimed)
                    {

                        Debug.Log("Not is claimed");
                        luckyCardsClaimBetData = JsonUtility.FromJson<LuckyCardsClaimBet>(www.downloadHandler.text);
                        string response = www.downloadHandler.text;
                        string[] responseArray = response.Substring(24).Split('"');
                        Debug.Log("response is " + responseArray[1]);
                        response = responseArray[1];
                        if (response == "Already Claimed")
                        {
                            ErrorHandler.Instance.InstantiateErrorHandlerUI("ALREADY CLAIMED", www.error + " Already Claimed The Ticket", "OKAY", true, 0);

                        }
                        response = responseArray[0];
                        if (LuckyCards_GameController.instance.autoClaim.isOn)
                        {
                            Debug.LogWarning("AutoCalim Is On " + luckyCardsClaimBetData.credit);
                            /*LuckyCards_GameController.instance.userCredit = (float)luckyCardsClaimBetData.credit;
                            LuckyCards_GameController.instance.balanceAmountText.text = luckyCardsClaimBetData.credit.ToString(); */
                            isClaimed = true;
                        }



                    }
                    else
                    {

                    }
                }
                if (gameId == 16)
                {
                    jeethoraftherClaimBetDatas = JsonUtility.FromJson<JeethoRaftherClaimBet>(www.downloadHandler.text);
                    if (JeethoRafther_UIManager.instance.autoClaimToggle.isOn)
                    {
                        JeethoRafther_Gamemanager.instance.totalUserCredit = (float)jeethoraftherClaimBetDatas.credit;
                        JeethoRafther_UIManager.instance.balanceText.text = jeethoraftherClaimBetDatas.credit.ToString();
                    }
                    else
                    {


                    }



                }
            }
            catch(Exception ex)
            {
                ErrorHandler.Instance.InstantiateErrorHandlerUI("UNKOWN ERROR", ex.Message + " Try Restarting The Game", "OKAY", true, 0);

            }



            // luckyCardsGameSummary = JsonUtility.FromJson<LuckyCardsGameSummary>(www.downloadHandler.text);
        }


    }
}
