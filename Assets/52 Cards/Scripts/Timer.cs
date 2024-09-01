using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public  float timeLeft;
    public float maxTime;

    private void OnEnable()
    {
        StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 18));
        foreach(LuckyCards_SpinManager spin in LuckyCards_GameController.instance.spinManagers)
        {
            spin.isClaiming = false;
        }
        maxTime = 120 -  Datas.instance.fiftyTwoCardsstartGameData.gametime;
        timeLeft = maxTime;
        CardsGameManager.instance.SetHistroyFromBackend();
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
        maxTime = 120 - Datas.instance.fiftyTwoCardsstartGameData.gametime;

        timeLeft = maxTime;
    }
    private void UpdateTimer()
    {
        if(timeLeft >= 0)
        {
            timeLeft -= 1;
            CardsUIManager.instance.UpdateTimeLeftTextMethod(timeLeft);
           // Debug.Log("Time left is " + timeLeft);
        }
        else if ( timeLeft < 10)
        {
            Debug.Log(" No MORE BETS PLEASE!!");                
        }
        if(timeLeft <= 0)
        {
            Debug.Log(" !!!SPIN MOMENT!!!");
            foreach (CardsSpinManager spin in CardsGameManager.instance.spinManager)
            {
                spin.spinWheel = true;
                spin.transform.rotation = Quaternion.Euler(0, 0, 0);
                spin.enabled = true;
            }

            this.enabled = false;
            timeLeft = 0;
            CancelInvoke();
        }
       
    }
}
