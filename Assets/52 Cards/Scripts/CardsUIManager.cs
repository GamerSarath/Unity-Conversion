using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class CardsUIManager : MonoBehaviour
{

    public static CardsUIManager instance;
    [SerializeField] TMP_Text timellefetText;
    [SerializeField] TMP_Text nextdrawTimeText;
    public Image[] historyIconImages;
    public Image[] historyNumberImages;
    public TMP_Text totalbetamountText;
    public TMP_Text winamountText;
    public GameObject[] coloumnAndRowSelectionButtons;
    public GameObject[] coloumnAndRowRemovalButtons;

    private void Awake()
    {
        instance = this;
    }
    public void UpdateTimeLeftTextMethod(float timeleft)
    {
        timellefetText.text = ((int)timeleft).ToString();

    }

    public void UpdateDrawTimeMethod()
    {
        nextdrawTimeText.text = (DateTime.Now.AddSeconds(Timer.Instance.maxTime + CardsGameManager.instance.timeOffset)).ToString("hh:mm:ss");

    }

    public void UpdateTotalBetAmount(int amount)
    {
        totalbetamountText.text = amount.ToString();
    }

    public void UpdateWinAmount(int amount)
    {
        winamountText.text = amount.ToString();
    }

    public void ClearRowAndColoumnButtons()
    {
        foreach(GameObject go in coloumnAndRowSelectionButtons)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in coloumnAndRowRemovalButtons)
        {
            go.SetActive(false);
        }
    }
}
