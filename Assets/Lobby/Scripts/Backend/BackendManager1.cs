using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
public class BackendManager1 : MonoBehaviour
{

    public static BackendManager1 Instance;
    public string url = "https://emezonez.in/unitydemo/game/gamelogin";
    public string startgameurl = "https://emezonez.in/unitydemo/game/startgame";
    public TMP_InputField email;
    public TMP_InputField password;
    public DataClass data;
    public LoginData loginDatas;

    private void Awake()
    {
        Instance = this;
    }

    
    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest url = UnityWebRequest.Get(uri);
        yield return url.SendWebRequest();

        if (url.isNetworkError)
        {
            Debug.Log("Error While Sending: " + url.error);
        }
        else
        {
            Debug.Log("Received: " + url.downloadHandler.text);
        }
    }


    public void OnClickGameStart(int gameId)
    {
        StartCoroutine(StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, gameId));
    }
    IEnumerator StartGame(int uid, string apitoken, int gameid)
    {
        try
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
                ErrorHandler.Instance.InstantiateErrorHandlerUI("RESULTING ERROR",www.error + " Try Restarting The Game","OKAY", true, 0);
            }
            else
            {

                Debug.Log("Response is " + www.downloadHandler.text);
                if (gameid == 1)
                {
                    Datas.instance.tripplechancestartGameData = JsonUtility.FromJson<TrippleChanceStartGameData>(www.downloadHandler.text);

                }
                else if (gameid == 14)
                {
                    Datas.instance.luckycardsstartGameData = JsonUtility.FromJson<LuckyCardsStartGameData>(www.downloadHandler.text);

                }
                else if (gameid == 18)
                {
                    Datas.instance.fiftyTwoCardsstartGameData = JsonUtility.FromJson<FiftyTwoCardsStartGameData>(www.downloadHandler.text);

                }
                else if (gameid == 16)
                {
                    Datas.instance.jeethoRaftherStartGameData = JsonUtility.FromJson<JeethoRaftherStartGameData>(www.downloadHandler.text);
                }
                else if (gameid == 23)
                {
                    Datas.instance.funtargetStartGameData = JsonUtility.FromJson<FunTargetStartGameData>(www.downloadHandler.text);
                }

                if (Datas.instance.tripplechancestartGameData.status)
                {
                    SceneManager.LoadScene(2);
                    yield return new WaitForSeconds(3);
                    GameManager.Instance.maxSpinDelay = Datas.instance.tripplechancestartGameData.tripple_gametime;
                }
                else if (Datas.instance.fiftyTwoCardsstartGameData.status)
                {
                    SceneManager.LoadScene(4);
                }
                /*  else if(Datas.instance.luckycardsstartGameData.status)
                  {
                      SceneManager.LoadScene(3);
                      yield return new WaitForSeconds(3);
                       = Datas.instance.tripplechancestartGameData.tripple_gametime;
                  }*/
                else if (Datas.instance.jeethoRaftherStartGameData.status)
                {
                    SceneManager.LoadScene(5);
                    yield return new WaitForSeconds(3);
                }
                else if (Datas.instance.luckycardsstartGameData.status)
                {
                    SceneManager.LoadScene(3);
                    yield return new WaitForSeconds(3);
                }
                else if(Datas.instance.funtargetStartGameData.status)
                {
                    SceneManager.LoadScene(6);
                    yield return new WaitForSeconds(3);
                }


            }
        }
        finally
        {
            ErrorHandler.Instance.InstantiateErrorHandlerUI("UNKNOWN ERROR", "SOMETHING WRONG HAPPEND, TRY AGAIN", "OKAY", true, 0);
        }
        
    }
}
