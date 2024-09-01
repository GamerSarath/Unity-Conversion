using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun_Target_Time_Manager : MonoBehaviour
{
    public static Fun_Target_Time_Manager Instance;
    public float timeLeft;
    public float maxTime;

    bool gameStarted = false;

    private void OnEnable()
    {
        Debug.Log("On enable called");
        StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 23));
        maxTime = 97;// 120 - Datas.instance.funtargetStartGameData.gametime;
        timeLeft = maxTime;

        InvokeRepeating(nameof(UpdateTimer), 1, 1);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        maxTime = 120 - Datas.instance.funtargetStartGameData.gametime;
        timeLeft = maxTime;
        if (!gameStarted)
        {
            InvokeRepeating(nameof(UpdateTimer), 1, 1);
            gameStarted = true;
        }


    }

    private void UpdateTimer()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= 1;
            Fun_Target_Ui_Manager.instance.timeText.text = timeLeft.ToString();

            // Debug.Log("Time left is " + timeLeft);
        }
        if (timeLeft <= 0)
        {
            timeLeft = maxTime;
            this.enabled = false;
            Fun_Target_Game_Manager.instance.spinManager.enabled = true;
        }
        if (timeLeft < 10)
        {
            Debug.Log(" No MORE BETS PLEASE!!" + timeLeft);
        }


    }
}
