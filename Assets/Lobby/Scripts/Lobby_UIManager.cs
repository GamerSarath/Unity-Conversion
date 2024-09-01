using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class Lobby_UIManager : MonoBehaviour
{
    public Image drawgamesBG;
    public Image cardgamesBG;
    public Image slotgamesBG;
    public Image horseganesBG;
    public Image roulettegamesBG;

    public GameObject drawgamesPanel;
    public GameObject cardgamesPanel;
    public GameObject slotgamesPanel;
    public GameObject horsegamesPanel;
    public GameObject roullettegamesPanel;
    public Text balanceText;

    public Text usernametext;

    private void Start()
    {
        balanceText.text = Datas.instance.loginDatas.usercredit;
        usernametext.text = Datas.instance.loginDatas.username;
    }
    public void OnClickDrawGames()
    {
        ClearScreen();
        drawgamesBG.gameObject.SetActive(true);
        drawgamesPanel.SetActive(true);
    }

    public void OnClickCardGames()
    {
        ClearScreen();
        cardgamesBG.gameObject.SetActive(true);
        cardgamesPanel.SetActive(true);
    }

    public void OnClickSlotGames()
    {
        ClearScreen();
        slotgamesBG.gameObject.SetActive(true);
        slotgamesPanel.SetActive(true);
    }

    public void OnClickRoulletteGames()
    {
        ClearScreen();
        roulettegamesBG.gameObject.SetActive(true);
        roullettegamesPanel.SetActive(true);
    }

    public void OnClickHorseGames()
    {
        ClearScreen();
        horseganesBG.gameObject.SetActive(true);
        horsegamesPanel.SetActive(true);
    }

    void ClearScreen()
    {
        Debug.Log("Clear Screen");
        cardgamesPanel.SetActive(false);
        slotgamesPanel.SetActive(false);
        drawgamesPanel.SetActive(false);
        horsegamesPanel.SetActive(false);
        roullettegamesPanel.SetActive(false);
        slotgamesBG.gameObject.SetActive(false);
        drawgamesBG.gameObject.SetActive(false);
        cardgamesBG.gameObject.SetActive(false);
        roulettegamesBG.gameObject .SetActive(false);
        horseganesBG.gameObject .SetActive(false);


    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public void OnWIndowMinimizeButtonClick()
    {
        ShowWindow(GetActiveWindow(), 2);
    }
}
