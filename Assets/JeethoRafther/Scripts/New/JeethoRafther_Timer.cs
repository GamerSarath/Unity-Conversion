using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class JeethoRafther_Timer : MonoBehaviour
{
    public static JeethoRafther_Timer Instance;
    public float timeLeft;
    public float maxTime;
    public bool timeUpdated = false;
    public bool gameStarted = false;
    public GameObject blockPanel;
    int waitTime;
    private void OnEnable()
    {
        waitTime = 8;
        CancelInvoke();
        if(!timeUpdated)
        {
            if(!gameStarted)
            {
                StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 16));
                maxTime = 120 - Datas.instance.jeethoRaftherStartGameData.gametime;
              
                gameStarted = true;
            }
            else
            {
                StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 16));
                maxTime = 94;
                
            }
            JeethoRafther_UIManager.instance.winText.text = Datas.instance.jeethoRaftherDrawBetDatas.horserace_winAmount.ToString();
            Debug.Log("Timer starts at " + maxTime);        
            timeLeft = maxTime;
            blockPanel.SetActive(false);
            timeUpdated = true;
        }
      

        JeethoRafther_UIManager.instance.UpdateHeaderaPanel();
        JeethoRafther_UIManager.instance.HistoryWithBackend();
        JeethoRafther_Gamemanager.instance.UpdateDrawTimeMethod();
        /*  if (Datas.instance.jeethoRaftherStartGameData.gametime < 45)
          {
              maxTime = 120;
              timeLeft = maxTime;

          }
          else
          {

          }*/
        if (timeLeft >= 0)
        {
            timeLeft -= 1;
            JeethoRafther_UIManager.instance.UpdateTimeLeftText(timeLeft);
        }
        if(timeLeft < 5)
        {
            
           
            if(Datas.instance.jeethoRaftherDrawBetDatas.status)
            {
                StartCoroutine(Datas.instance.DrawBet(16));
               
            }
        }
        if (timeLeft >= 0)
        {
            timeLeft -= 1;

            JeethoRafther_UIManager.instance.UpdateTimeLeftText(timeLeft);
            Debug.Log(" No MORE BETS PLEASE!!");
        }

        
        if (timeLeft <= 0)
        {
            Debug.Log(" !!!SPIN MOMENT!!!");
            
            JeethoRafther_UIManager.instance.TurnOffBG();
            JeethoRafther_UIManager.instance.TurnOnPlayPanel();
          

            //this.enabled = false;
            //timeLeft = 0;
            CancelInvoke();
        }
       

        InvokeRepeating(nameof(UpdateTimer), 1, 1);
    }

    private void OnDisable()
    {   
        timeUpdated = false;
        Debug.Log("Winnumber is " + JeethoRafther_Gamemanager.instance.currentWinner);
        JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().minSPeed = 350;
        JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().maxSpeed = 360;
        JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().minAcceleration = 5;
        JeethoRafther_Gamemanager.instance.horses[JeethoRafther_Gamemanager.instance.currentWinner].GetComponent<JeethoRafther_Horse>().maxAcceeleration = 7;
        CancelInvoke();
    }

    private void Awake()
    {
        Instance = this;
        waitTime = 14;

    }
    private void Start()
    {
        if(timeLeft <= 5)
        {
            ErrorHandler.Instance.InstantiateErrorHandlerUI("WAITING", "WAIT FOR NEXT DRAW, CURRENT DRAW COMPLETED", "GO", true, 0);
        }
    }
    void InvokeLastTimer()
    {
        waitTime -= 1;
       if( ErrorHandler.Instance.errorhandlerinstance != null)
        {
            ErrorHandler.Instance.errorhandlerinstance.GetComponent<ErrorHandlerUI>().timeLeftText.text = waitTime.ToString();
        }
        if(waitTime <= 0)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Error Handler Prefab");
            if(go != null)
            {
                Destroy(go);
            }   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            maxTime = 120 - Datas.instance.jeethoRaftherStartGameData.gametime;
            timeLeft = maxTime;
        }
    }

    private void UpdateTimer()
    {
        /*if(!timeUpdated)
        {
            if (Datas.instance.jeethoRaftherStartGameData.gametime < 45)
            {
                maxTime = 120;

            }
            else
            {
                maxTime= 165 - Datas.instance.jeethoRaftherStartGameData.gametime;

            }
            timeUpdated = true;
        }*/
        if (timeLeft >= 0)
        {
            timeLeft -= 1;
            JeethoRafther_UIManager.instance.UpdateTimeLeftText(timeLeft);
            Debug.Log(" No MORE BETS PLEASE!!");
        }
        if (timeLeft < 10)
        {
            blockPanel.SetActive(true);
        }
        if (timeLeft <= 5)
        {
            for (int i = 0; i < JeethoRafther_Gamemanager.instance.betAmount.Count; i++)
            {
                JeethoRafther_Gamemanager.instance.betAmount[i] = 0;
                JeethoRafther_UIManager.instance.betAmountsText[i].text = 0.ToString();
            }
            StartCoroutine(Datas.instance.DrawBet(16));
        }
        if (timeLeft <= 0)
        {
            Debug.Log(" !!!SPIN MOMENT!!!");
            JeethoRafther_UIManager.instance.TurnOffBG();
            JeethoRafther_UIManager.instance.TurnOnPlayPanel();
            foreach (GameObject go in JeethoRafther_Gamemanager.instance.horses)
            {
                go.GetComponent<JeethoRafther_Horse>().enabled = true;

            }
            this.enabled = false;
            timeLeft = 0;
            CancelInvoke();
        }

    }
}