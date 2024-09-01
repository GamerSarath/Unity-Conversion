using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using System;
public class BackendManager : MonoBehaviour
{

    public static BackendManager Instance;
    public string url = "https://emezonez.in/unitydemo/game/gamelogin";
    public string startgameurl = "https://emezonez.in/unitydemo/game/startgame";
    public TMP_InputField email;
    public TMP_InputField password;
    public DataClass data;
    public LoginData loginDatas;
    public int inputSelected;
    bool isConnected;
    private void Awake()
    {
        Instance = this;
        loginDatas = new LoginData();
        isConnected = false;
        // DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        data = new DataClass();
        data.username = email.GetComponent<TMP_InputField>().text;

        data.password = password.GetComponent<TMP_InputField>().text;
        data.store_id = SystemInfo.deviceUniqueIdentifier;
        data.dev = 1;


    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Tab)))
        {
            inputSelected++;
            if (inputSelected > 1)
            {
                inputSelected = 0;
            }
            SelectInputField();
        }

        if ((Input.GetKeyDown(KeyCode.Return)))
        {
            if (email.text != null && password.text != null)
            {
                StartCoroutine(CallLogin(email.GetComponent<TMP_InputField>().text, password.GetComponent<TMP_InputField>().text, data.store_id));
            }
        }
    }

    void SelectInputField()
    {
        switch (inputSelected)
        {
            case 0:
                email.Select();
                break;

            case 1:
                password.Select();
                break;

        }

    }

    public void UsernameSelected() => inputSelected = 0;
    public void PasswordSelected() => inputSelected = 1;
    public void OnCLickLoginButton()
    {
        StartCoroutine(CallLogin(email.GetComponent<TMP_InputField>().text, password.GetComponent<TMP_InputField>().text, data.store_id));
    }

    IEnumerator CallLogin(string email, string password, string stroreid)
    {
        UnityWebRequest www = null;
        /*try
        {*/
        WWWForm form = new WWWForm();
        form.AddField("username", email);
        form.AddField("password", password);
        form.AddField("store_id", stroreid);
        form.AddField("dev", 1);
        www = UnityWebRequest.Post(url, form);
        yield return www.Send();


        if (www.error != null)
        {
            Debug.Log(www.error);
            if (www.error == "Request timeout")
            {
                ErrorHandler.Instance.InstantiateErrorHandlerUI("REQUEST TIMEOUT", "Request Timed Out. Please Try Again", "OKAY", true, 0);

            }
            else
            {
                ErrorHandler.Instance.InstantiateErrorHandlerUI("RESULTING ERROR", www.error, "OKAY", true, 0);

            }

        }
        else
        {
            try
            {
                Debug.Log("Response is " + www.downloadHandler.text);
                string response = www.downloadHandler.text;
                string[] responseArray = response.Substring(29).Split('"');
                response = responseArray[0];
                Debug.Log("Substring is " + responseArray[0]);
                if (responseArray[0] == "Admin Approval Needed")
                {
                    ErrorHandler.Instance.InstantiateErrorHandlerUI("ADMIN APPROVAL NEEDED", "Get Approval To Login", "OKAY", true, 0);

                }
                if (response == "Username or Password Incorrect")
                {
                    ErrorHandler.Instance.InstantiateErrorHandlerUI("LOGIN FAILED", "PASSWORD AND USERNAME NOT MATCHING", "OKAY", true, 0);
                }
                else
                {
                    Debug.LogWarning("Password Matched");
                }

                Datas.instance.loginDatas = JsonUtility.FromJson<LoginData>(www.downloadHandler.text);
                if (Datas.instance.loginDatas.status)
                {
                    SceneManager.LoadScene(1);
                }
            }
            catch (Exception e)
            {
                {
                    ErrorHandler.Instance.InstantiateErrorHandlerUI("UNKNOWN ERROR", "Something Went Wrong. Please Try Again", "OKAY", true, 0);



                }
            }
            /* finally
             {
                 ErrorHandler.Instance.InstantiateErrorHandlerUI("UNKOWN", " SOMETHING IS NOT WORKING PROPERLY, KINDLY TRY AGAIN ", "OKAY", true, 0);
             }*/

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


        void OnClickGameStart()
        {

        }
        IEnumerator StartGame(string uid, string apitoken, int gameid)
        {
            WWWForm form = new WWWForm();
            form.AddField("uid", uid);
            form.AddField("api_token", apitoken);
            form.AddField("game_id", gameid);

            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.Send();

            if (www.error != null)
            {
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log("Response is " + www.downloadHandler.text);
                JsonUtility.FromJson<LoginData>(www.downloadHandler.text);
                if (BackendManager.Instance.loginDatas.status)
                {
                    SceneManager.LoadScene(2);

                }
            }
        }
    }
}
