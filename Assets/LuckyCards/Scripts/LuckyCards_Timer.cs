using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuckyCards_Timer : MonoBehaviour
{
    public static LuckyCards_Timer Instance;
    public float timeLeft;
    public float maxTime;
    public bool isDrawingBet;
    public GameObject blockPanel;
    public int waitTime;
    private void OnEnable()
    {
        StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 14));
        /* maxTime = 120 - Datas.instance.luckycardsstartGameData.gametime;
         timeLeft = maxTime;
 */
        isDrawingBet = false;
        blockPanel.SetActive(false);
        LuckyCards_GameController.instance.countDownTime.color = Color.green;

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
        maxTime = 116 - Datas.instance.luckycardsstartGameData.gametime;
        waitTime = 14;
        
        //StartCoroutine(Datas.instance.GetSummary(14));
        isDrawingBet = false;
        timeLeft = maxTime;
        LuckyCards_GameController.instance.SetHistoryFromBackend();
        if (timeLeft <= 5)
        {
            Debug.Log("Time left is " + timeLeft);
            ErrorHandler.Instance.InstantiateErrorHandlerUI("WAITING", "WAIT FOR NEXT DRAW, CURRENT DRAW COMPLETED", "GO", true, 0);
        }
    }

    void InvokeLastTimer()
    {
        waitTime -= 1;
        if (ErrorHandler.Instance.errorhandlerinstance != null)
        {
            ErrorHandler.Instance.errorhandlerinstance.GetComponent<ErrorHandlerUI>().timeLeftText.text = waitTime.ToString();
        }
        if (waitTime <= 0)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Error Handler Prefab");
            if (go != null)
            {
                Destroy(go);
            }
            maxTime = 120 - Datas.instance.luckycardsstartGameData.gametime;
            timeLeft = maxTime;
            CancelInvoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateTimer()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= 1;
            LuckyCards_GameController.instance.countDownTime.text = timeLeft.ToString();
            // Debug.Log("Time left is " + timeLeft);
        }
         if (timeLeft < 10)
        {
              blockPanel.SetActive(true);Debug.Log(" No MORE BETS PLEASE!!");
            LuckyCards_GameController.instance.ResetChipValues();
            LuckyCards_GameController.instance.KillingChips();
            LuckyCards_GameController.instance.totalBetValue = 0;
            LuckyCards_GameController.instance.totalBetText.text = LuckyCards_GameController.instance.totalBetValue.ToString();
            LuckyCards_GameController.instance.countDownTime.color = Color.red;
            LuckyCards_GameController.instance.ChangeSlotColor();
        }
        if(timeLeft <= 2)
        {
            /*if(!isDrawingBet)
            {
                isDrawingBet = true;
            }*/
            StartCoroutine(Datas.instance.DrawBet(14));

        }
        if (timeLeft <= 0)
        {
         //   StartCoroutine(Datas.instance.GetSummary(14));

            timeLeft = 0;
            LuckyCards_GameController.instance.winnerDisplay.enabled = false;
            Debug.Log(" !!!SPIN MOMENT!!!");
            foreach (LuckyCards_SpinManager spin in LuckyCards_GameController.instance.spinManagers)
            {
                spin.spinWheel = true;
                spin.transform.rotation = Quaternion.Euler(0, 0, 0);
                spin.enabled = true;
            }
            LuckyCards_GameController.instance.SelectWinner();
            //LuckyCards_GameController.instance.WinnerSelection();
            LuckyCards_GameController.instance.SetAllFlase();
            LuckyCards_GameController.instance.TotalValueOfBetStored();
            LuckyCards_GameController.instance.ResetTotalValueOnEveryCards();
            LuckyCards_GameController.instance.InvokeFunctions();
            CancelInvoke();
            this.enabled = false;
           
        }

    }
}
