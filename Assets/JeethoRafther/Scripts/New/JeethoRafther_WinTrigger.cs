using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeethoRafther_WinTrigger : MonoBehaviour
{

   public bool winUpdated = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(" Wins");
        if(!winUpdated)
        {
            if (collision.CompareTag("Toofan"))
            {
                Debug.Log("Toofan Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[0] * 9;
               JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[0]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[0];
            }
            else if (collision.CompareTag("Rangeela"))
            {
                Debug.Log("Rangeela Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[1] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[1]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[1];

            }
            else if (collision.CompareTag("Arjun"))
            {
                Debug.Log("Arjun Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[2] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[2]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[2];
            }
            else if (collision.CompareTag("Royal"))
            {
                Debug.Log("Royal Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[3] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[3]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[3];
            }
            else if (collision.CompareTag("Tarzen"))
            {
                Debug.Log("Tarzen Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[4] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[4]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[4];
            }
            else if (collision.CompareTag("Chetak"))
            {
                Debug.Log("Chetak Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[5] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[5]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[5];
            }
            else if (collision.CompareTag("Lucky"))
            {
                Debug.Log("Lucky Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[6] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[6]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[6];
            }
            else if (collision.CompareTag("Baazigar"))
            {
                Debug.Log("Baazigar Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[7] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[7]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[7];
            }
            else if (collision.CompareTag("Jeet"))
            {
                Debug.Log("Jeet Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[8] * 9;
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[8]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[8];
            }
            else if (collision.CompareTag("Tiger"))
            {
                Debug.Log("Tiger Wins");
                JeethoRafther_Gamemanager.instance.winReward = JeethoRafther_Gamemanager.instance.betTakenAmount[9] * 9;
               
                JeethoRafther_Gamemanager.instance.winHistory.Insert(0, JeethoRafther_Gamemanager.instance.horseSprites[9]);
                JeethoRafther_UIManager.instance.winningHorse.sprite = JeethoRafther_UIManager.instance.winningSprites[9];
            }
            StartCoroutine(Datas.instance.ClaimBet(16, Datas.instance.jeethoraftherPlayBetDatas.unique_id)) ;
            if(JeethoRafther_Gamemanager.instance.winHistory.Count >6)
            {
                JeethoRafther_Gamemanager.instance.winHistory.RemoveAt(6);

            }
            

            JeethoRafther_UIManager.instance.AddHistoryWithoutBackend();
            Debug.Log("Your reward is " + JeethoRafther_Gamemanager.instance.winReward);
            JeethoRafther_UIManager.instance.winText.text = JeethoRafther_Gamemanager.instance.winReward.ToString();

            JeethoRafther_Gamemanager.instance.AddBalanceFromBackendAutoClaimToVariables();
            JeethoRafther_UIManager.instance.TurnOnWinnerPanel();
            winUpdated = true;
            if(Datas.instance.jeethoRaftherDrawBetDatas.horserace_winAmount == 0)
            {
              
            }
           // JeethoRafther_Gamemanager.instance.repeatList = JeethoRafther_Gamemanager.instance.betAmount;
           // JeethoRafther_Gamemanager.instance.Clear();
            StartCoroutine(EnableTImer());
        }

       
    }

    public IEnumerator EnableTImer()
    {
        yield return new WaitForSeconds(5);
        ErrorHandler.Instance.InstantiateErrorHandlerUI("NO BETS WON ", "OOPS..BETTER LUCK NEXT TIME", "OKAY", true, 0);
        yield return new WaitForSeconds(10);
        JeethoRafther_Gamemanager.instance.totalBetAmount = 0;
        foreach (GameObject go in JeethoRafther_Gamemanager.instance.horses)
        {
            go.GetComponent<JeethoRafther_Horse>().enabled = false;
            go.transform.localPosition = go.GetComponent<JeethoRafther_Horse>().startingPosition;
            go.GetComponent<JeethoRafther_Horse>().acceleration = 0;
            go.GetComponent<JeethoRafther_Horse>().speed = 0;
            go.GetComponent<JeethoRafther_Horse>().minSPeed = 250;
            go.GetComponent<JeethoRafther_Horse>().maxSpeed = 350;
            go.GetComponent<JeethoRafther_Horse>().minAcceleration = 2;
            go.GetComponent<JeethoRafther_Horse>().maxAcceeleration = 5;
        }
        JeethoRafther_Gamemanager.instance.gameCount += 1;
        if (JeethoRafther_Gamemanager.instance.gameCount >= 5)
        {
            JeethoRafther_Gamemanager.instance.gameCount = 0;
        }

        for (int i = 0; i < 10; i++)
        {
            JeethoRafther_Gamemanager.instance.repeatList[i] = JeethoRafther_Gamemanager.instance.betTakenAmount[i];

            JeethoRafther_Gamemanager.instance.betTakenAmount[i] = 0;

        }
        JeethoRafther_UIManager.instance.totalBetAmountText.text = 0.ToString();

        JeethoRafther_Timer.Instance.enabled = true;
        winUpdated = false;
        JeethoRafther_UIManager.instance.runningHorsePanel.localPosition = JeethoRafther_UIManager.instance.runninghorserPanelosition;
        JeethoRafther_UIManager.instance.TurnOnBG();
        JeethoRafther_UIManager.instance.TurnOffPlayPanel();
        JeethoRafther_UIManager.instance.TurnOffWinnerPanel();

    }
}
