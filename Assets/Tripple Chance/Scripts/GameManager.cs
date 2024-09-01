using Array2DEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<int> selectedDoubleCells = new List<int>();
    public List<int> selectedTrippleCells = new List<int>();
    public List<int> selectedSingleCells = new List<int>();

    public List<int> betTakenSingleNumbers = new List<int>();
    public List<int> betTakenDoubleNumbers = new List<int>();
    public List<int> betTakenTrippleNumbers = new List<int>();

    public List<int> betTakenTrippleNumbers1 = new List<int>();
    public List<int> betTakenTrippleNumbers2 = new List<int>();
    public List<int> betTakenTrippleNumbers3 = new List<int>();
    public List<int> betTakenTrippleNumbers4 = new List<int>();
    public List<int> betTakenTrippleNumbers5 = new List<int>();
    public List<int> betTakenTrippleNumbers6 = new List<int>();
    public List<int> betTakenTrippleNumbers7 = new List<int>();
    public List<int> betTakenTrippleNumbers8 = new List<int>();
    public List<int> betTakenTrippleNumbers9 = new List<int>();
    public List<int> betTakenTrippleNumbers10 = new List<int>();
    public Guid UniqueId { get; set; }

    public List<int> betTakenSingleAmount = new List<int>();
    public List<int> betTakenDoubleAmount = new List<int>();
    public List<int> betTakenTrippleAmount= new List<int>();


    public bool[] doublerowsSelected = new bool[10];
    public bool[] doublecolsSelected = new bool[10];

    public bool[] tripplerowsSelected = new bool[10];
    public bool[] tripplecolsSelected = new bool[10];
    public int currentTrippleMultiplyValue = 1;

    public int currentBetAmount = 10;
    public List<int> selectedRandomNumbers = new List<int>();

    public float[] trippleSpins;
    public float[] doubleSpins;
    public float[] singleSpins;
    public int spinDelay = 120;
    public int maxSpinDelay;
    public GameObject spinWheelOne;
    public GameObject spinWheelTwo;
    public GameObject spinWheelThree;
    public int trippleWheelRandomNum;
    public int doubleWheelRandomNum;

    public int singleWheelRandomNum;
    public GameObject spinMark;
    public bool isRandomNumGenerated = false;

    public int singlewinNumber;
    public int doublewinNumber;
    public int trippleWinNumber;
    public int randomTrippleMax = 99;
    public int randomTrippleMin = 0;
    public bool gameEnds;
    public Transform[] tabsBar;
    public int[] initialValues;
    public GameObject victoryImage;

    public List<String> timeList = new List<String>();
    public int trippleResult;
    public int doubleResult;
    public int singleResult;
    public int DoubleValue;
    public int trippleValue;
    public int singleValue;
    public String trippleString;
    public String doubleString;

    public List<String> trippleList = new List<String>();
    public List<String> doubleList = new List<String>();
    public List<String> singleList = new List<String>();

    public int totalBetAmount;
    public int currentBalance;
    public bool isBetTaken;
   public bool singleResultShown = false;
    public bool doubleResultShown = false;
   public bool trippleResultShown = false;
    public bool isUsingRandomPick = false;
    public bool[] randomPickBools;
    public bool[] randomTripplePickBools;
    public int[] prefferedBalance;
    public int[] prefferedTrippleBalance;
    public bool pickingRandomNumber = false;
    public Animator winAnimator;
    public int winAmount;
    public bool[] tempSavingArray;
    public GameObject[] trippleTabs;
    bool isTimeOver;
    public bool timeUpdated = false;
    bool gamestarted = false;
    private void Awake()
    {
        Instance = this;

        isBetTaken = false;
        for(int i = 0; i < randomPickBools.Length; i++)
        {
            randomPickBools[i] = false;
            randomTripplePickBools[i] = false;

        }

    }
    private void Start()
    {
        /* if(PlayerPrefs.HasKey("CurrentBalance"))
         {
             currentBalance = PlayerPrefs.GetInt("CurrentBalance");
             UIManager.Instance.balanceAmount.text = currentBalance.ToString();
         }
         else
         {
             currentBalance = 10000;
             PlayerPrefs.SetInt("CurrentBalance", currentBalance);
             UIManager.Instance.balanceAmount.text = currentBalance.ToString();

         }*/
        UIManager.Instance.gameIdText.text = Datas.instance.tripplechancestartGameData.tripple_gameplay.ToString();
        UIManager.Instance.balanceAmount.text = Datas.instance.tripplechancestartGameData.usercredit.ToString();
        UIManager.Instance.usernameText.text = Datas.instance.loginDatas.username;

        timeUpdated = false;
        StartGame();
       
    }

    private void Update()
    {
        if(!timeUpdated)
        {
           if(!gamestarted)
            {
                spinDelay = 120 - Datas.instance.tripplechancestartGameData.tripple_gametime;
                gamestarted = true;
            }
            else
            {
                spinDelay = 120 - Datas.instance.tripplechancestartGameData.tripple_gametime;
                spinDelay -= 5;
            }
            timeUpdated = true;
        }
    }
    public void SetCurrentBalance(int balance)
    {
        Debug.Log("Setting current balance + balance is " + balance) ;
        currentBalance += balance;
        UIManager.Instance.balanceAmount.text = currentBalance.ToString();
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
    }
    public void SettingUpWinNumbers()
    {
        singleValue = int.Parse(singleResult.ToString());
        DoubleValue = int.Parse( doubleResult.ToString() +int.Parse(singleResult.ToString()));
        trippleValue = int.Parse(trippleResult.ToString() + doubleResult.ToString() + singleResult.ToString());
        if (trippleResult == 0)
        {
            trippleValue = int.Parse(0.ToString() + doubleResult.ToString() + singleResult.ToString());
            trippleString = 0.ToString() + doubleResult.ToString() + singleResult.ToString();
        }
        else
        {
            trippleValue = int.Parse(trippleResult.ToString() + doubleResult.ToString() + singleResult.ToString());
            trippleString = trippleValue.ToString();
        }
        if (doubleResult == 0)
        {
            DoubleValue = int.Parse(0.ToString() + singleResult.ToString());
            doubleString = 0.ToString() + singleResult.ToString();

        }
        else
        {
            DoubleValue = int.Parse(doubleResult.ToString() + singleResult.ToString());
            doubleString =DoubleValue.ToString();
        }
        UIManager.Instance.resultText.text = GameManager.Instance.trippleString;

        if (singleList.Count <= 5)
        {
            singleList.Insert(0, singleValue.ToString());
            doubleList.Insert(0, doubleString);
            trippleList.Insert(0, trippleString);

        }

        CalculateBetWin();
        OnBetWon();
    }
    public void ClearAllTabs()
    {
        foreach(GameObject go in trippleTabs)
        {
            go.SetActive(false);
        }

    }
    public void StartGame()
    {
        ClearAllTabs();
        isTimeOver = false;
        trippleTabs[0].SetActive(true);
        winAnimator.ResetTrigger("WinPopUp");
        winAmount = 0;
        UIManager.Instance.winAmountText.text = "";
        winAnimator.SetTrigger("WinPopDown");
        winAnimator.gameObject.SetActive(false);
        UIManager.Instance.placeyourbetLabel.SetActive(true);
        UIManager.Instance.betIDText.text = "";
        for (int i = 0; i < randomPickBools.Length; i++)
        {
            randomPickBools[i] = false;
            randomTripplePickBools[i] = false;  
        }
        pickingRandomNumber = false;
        isBetTaken = false;
        totalBetAmount = 0;
        singleResultShown = false;
        doubleResultShown = false;
        trippleResultShown = false;
        UIManager.Instance.blockPanel.SetActive(false);
        foreach(Transform t in UIManager.Instance.trippleCells)
        {
            t.GetComponent<SingleValue>().valueText.text = t.GetComponent<SingleValue>().value.ToString();
        }
        foreach(Transform t in UIManager.Instance.resultImages)
        {
            if(t != null)
            {
                Destroy(t.gameObject);

            }
           
        }
        currentTrippleMultiplyValue = 0;

        InvokeRepeating(nameof(SpinTimer), 1, 1);

       // TrippleChance.instance.enabled = true;
       // StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 1));
    }
   
    public void ClearTabBarScale()
    {
        foreach(Transform t in tabsBar)
        {
            t.localScale = Vector3.one;
        }
    }
    public void SetCurrentBetAmount(int value)
    {
        Debug.Log("Current bet amoount is " + value);
        currentBetAmount = value;
    }

    public static List<int> GenerateRandomNumbers(int count, int minValue, int maxValue)
    {
        List<int> possibleNumbers = new List<int>();
        List<int> chosenNumbers = new List<int>();

        for (int index = minValue; index < maxValue; index++)
            possibleNumbers.Add(index);

        while (chosenNumbers.Count < count)
        {
            int position = Random.Range(0, possibleNumbers.Count);
            chosenNumbers.Add(possibleNumbers[position]);
            possibleNumbers.RemoveAt(position);
        }
        return chosenNumbers;
    }
        
    public void ClearAllDoubleCells()
    {
        foreach (Transform t in UIManager.Instance.doubleCells)
        {
            GameManager.Instance.selectedDoubleCells.Remove(t.GetComponent<SingleValue>().value);

            GridManager.instance.doubecellOccupied.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromDoubleSelection(t);

        }
    }
    public void ClearAllTrippleCells()
    {
        foreach (Transform t in UIManager.Instance.trippleCells)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells2)
        {
            GameManager.Instance.selectedTrippleCells.Clear();

            //Debug.Log("Setting false");
            GridManager.instance.tripplecellOccupied1.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells3)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied2.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells4)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied3.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells5)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied4.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells6)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied5.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells7)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied6.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells8)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied7.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells9)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied8.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }

        foreach (Transform t in UIManager.Instance.trippleCells10)
        {
            GameManager.Instance.selectedTrippleCells.Clear();


            GridManager.instance.tripplecellOccupied9.SetCell(t.GetComponent<SingleValue>().rowNumber, t.GetComponent<SingleValue>().coloumnNumber, false);
            t.GetComponent<SingleValue>().RemoveFromTrippleSelection(t);

        }
    }

    public void ClearAllSingleCells()
    {
        foreach (Transform t in UIManager.Instance.singleCells)
        {
            GameManager.Instance.selectedSingleCells.Remove(t.GetComponent<SingleValue>().value);

            t.GetComponent<SingleValue>().RemoveFromSingleSelection(t);

        }

    }
    public void PickRandomNumberDoubles(int count)
    {
         
        pickingRandomNumber = true;
        ClearAllDoubleCells();
        selectedRandomNumbers = GenerateRandomNumbers(count, 0, 100);
        switch(count)
        {
            case 5:
                if (!randomPickBools[0])
                {
                    Debug.Log(" inside 5");
                    
                   int  currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedBalance[0] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 *currentbalance);

                    randomPickBools[0] = true;
                }
                else
                {
                    if (prefferedBalance[0] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedBalance[0]);


                    }
                }
               
                break;
            case 10:
                if (!randomPickBools[1])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);

                    prefferedBalance[1] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);

                    //GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomPickBools[1] = true;
                }
                else
                {
                    if (prefferedBalance[1] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedBalance[1]);

                    }
                }
                break;
            case 15:
                if (!randomPickBools[2])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);

                    prefferedBalance[2] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);

                    GameManager.Instance.SetCurrentBalance(-1 * currentbalance);
                    randomPickBools[2] = true;
                }
                else
                {
                    if (prefferedBalance[2] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedBalance[2]);

                    }
                }
                break;
            case 20:
                if (!randomPickBools[3])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedBalance[3] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);


                    currentbalance = currentBalance - prefferedBalance[3];
                  //  GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomPickBools[3] = true;
                }
                else
                {
                    if (prefferedBalance[3] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedBalance[3]);

                    }
                }
                break;
            case 25:
                if (!randomPickBools[4])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedBalance[4] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);


                    //  GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomPickBools[4] = true   ;
                }
                else
                {
                    if (prefferedBalance[4] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedBalance[4]);

                    }
                }
                break;
            case 50:
                if (!randomPickBools[5])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedBalance[5] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);


                    //  currentbalance = currentBalance - prefferedBalance[5];
                    // GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomPickBools[5] = true;
                }
                else
                {
                    if (prefferedBalance[0] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedBalance[5]);
                    }
                }
                break;
            case 100:
                if (!randomPickBools[6])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedBalance[6] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);


                    currentbalance = currentBalance - prefferedBalance[6];
                    //GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomPickBools[6] = true;
                }
                else
                {
                    if (prefferedBalance[6] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedBalance[6]);
                    }
                }
                break;
        }
      
        foreach (int number in selectedRandomNumbers)
        {
            foreach(Transform cells in UIManager.Instance.doubleCells)
            {

                if(cells.GetComponent<SingleValue>().value == number)
                {
                    cells.GetComponent<SingleValue>().OnClickButton();
                }
            }
        }
        pickingRandomNumber = false;
    }

    public void PickRandomNumberTripples(int count)
    {
        pickingRandomNumber = true;
        Debug.Log("clicked tripple random " + randomTrippleMin + " " + randomTrippleMax);
        // selectedRandomNumbers = GenerateRandomNumbers(count, 0, 99);
        ClearAllTrippleCells();
        selectedRandomNumbers = GenerateRandomNumbers(count, randomTrippleMin, randomTrippleMax);
        switch (count)
        {
            case 5:
                if (!randomTripplePickBools[0])
                {
                    Debug.Log(" inside 5");

                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedTrippleBalance[0] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);

                    randomTripplePickBools[0] = true;
                }
                else
                {
                    if (prefferedTrippleBalance[0] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedTrippleBalance[0]);


                    }
                }

                break;
            case 10:
                if (!randomTripplePickBools[1])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);

                    prefferedTrippleBalance[1] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);

                    //GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomTripplePickBools[1] = true;
                }
                else
                {
                    if (prefferedTrippleBalance[1] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedTrippleBalance[1]);

                    }
                }
                break;
            case 15:
                if (!randomTripplePickBools[2])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);

                    prefferedTrippleBalance[2] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);

                    GameManager.Instance.SetCurrentBalance(-1 * currentbalance);
                    randomTripplePickBools[2] = true;
                }
                else
                {
                    if (prefferedTrippleBalance[2] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedTrippleBalance[2]);

                    }
                }
                break;
            case 20:
                if (!randomTripplePickBools[3])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedTrippleBalance[3] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);

                    //  GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomTripplePickBools[3] = true;
                }
                else
                {
                    if (prefferedTrippleBalance[3] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedTrippleBalance[3]);

                    }
                }
                break;
            case 25:
                if (!randomTripplePickBools[4])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedTrippleBalance[4] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);


                    //  GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomTripplePickBools[4] = true;
                }
                else
                {
                    if (prefferedTrippleBalance[4] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedTrippleBalance[4]);

                    }
                }
                break;
            case 50:
                if (!randomTripplePickBools[5])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedTrippleBalance[5] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);


                    //  currentbalance = currentBalance - prefferedBalance[5];
                    // GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomTripplePickBools[5] = true;
                }
                else
                {
                    if (prefferedTrippleBalance[0] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedTrippleBalance[5]);
                    }
                }
                break;
            case 100:
                if (!randomTripplePickBools[6])
                {
                    int currentbalance = (currentBetAmount * count);
                    Debug.Log("current value is " + currentbalance);
                    prefferedTrippleBalance[6] = currentBalance - currentbalance;
                    SetCurrentBalance(-1 * currentbalance);


                    currentbalance = currentBalance - prefferedBalance[6];
                    //GameManager.Instance.SetCurrentBalance(currentbalance);
                    randomTripplePickBools[6] = true;
                }
                else
                {
                    if (prefferedTrippleBalance[6] != 0)
                    {
                        currentBalance = 0;
                        SetCurrentBalance(prefferedTrippleBalance[6]);
                    }
                }
                break;
        }

        
        switch (currentTrippleMultiplyValue / 100)
        {
            case 0:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 1:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells2)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 2:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells3)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 3:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells4)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 4:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells5)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 5:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells6)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 6:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells7)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 7:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells8)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 8:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells9)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 9:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;

            case 10:
                foreach (int number in selectedRandomNumbers)
                {
                    foreach (Transform cells in UIManager.Instance.trippleCells10)
                    {

                        if (GameManager.Instance.currentTrippleMultiplyValue + cells.GetComponent<SingleValue>().value == number)
                        {
                            cells.GetComponent<SingleValue>().OnClickButton();
                        }
                    }
                }
                break;
        }


        pickingRandomNumber = false;    
    }

    public void SpinTimer()
    {
        spinWheelOne.GetComponent<SpinManager>().canUpdateTimeList = false;
       
        UIManager.Instance.totalBetAmountText.text = totalBetAmount.ToString();
        spinDelay -= 1;
        UIManager.Instance.timerText.text = spinDelay.ToString();
        if(spinDelay <= 10)
        {
            UIManager.Instance.blockPanel.SetActive(true);
            if(!isTimeOver)
            {
                OnClickBetButton();
                isTimeOver = true;
            }
        }
        if(spinDelay <= 5)
        {
            StartCoroutine(Datas.instance.DrawBet(1));

        }
        if (spinDelay <= 0)   
        {
            GameManager.Instance.spinWheelOne.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
            GameManager.Instance.spinWheelTwo.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
            GameManager.Instance.spinWheelThree.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
            if (!isRandomNumGenerated)
            {
                singleWheelRandomNum = Random.Range(0, 10);
                doubleWheelRandomNum = Random.Range(0, 10);
                trippleWheelRandomNum = Random.Range(0, 10);
                isRandomNumGenerated = false;
            }
            UIManager.Instance.timerText.text = 0.ToString(); 

             spinWheelOne.GetComponent<SpinManager>().spinWheel = true;
            spinWheelTwo.GetComponent<SpinManagerTwo>().spinWheel = true;
            spinWheelThree.GetComponent<SpinManagerThree>().spinWheel = true;

      
           // Debug.Log("Angular torque of wheel 3 is " + trippleSpins[trippleWheelRandomNum]);
            CancelInvoke();
        }
    }

    public void UpdateCurrentMultiplyValue(int number)
    {
        //Debug.Log("Called Update Multiplier With value " + number);
        currentTrippleMultiplyValue = number;
        randomTrippleMax = number + 100;
        randomTrippleMin = number;
        ClearAllTabs();
       // ClearAllTrippleCells();
        trippleTabs[number/100].SetActive(true);
        switch (number / 100)
        {
            case 0:
                foreach (Transform t in UIManager.Instance.trippleCells)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 1:
                foreach (Transform t in UIManager.Instance.trippleCells2)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 2:
                foreach (Transform t in UIManager.Instance.trippleCells3)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 3:
                foreach (Transform t in UIManager.Instance.trippleCells4)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 4:
                foreach (Transform t in UIManager.Instance.trippleCells5)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 5:
                foreach (Transform t in UIManager.Instance.trippleCells6)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 6:
                foreach (Transform t in UIManager.Instance.trippleCells7)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 7:
                foreach (Transform t in UIManager.Instance.trippleCells8)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 8:
                foreach (Transform t in UIManager.Instance.trippleCells9)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;

            case 9:
                foreach (Transform t in UIManager.Instance.trippleCells10)
                {
                    if (t.childCount > 0)
                    {
                        Debug.Log("Child Name is " + t.GetChild(0).name);
                        Destroy(t.GetChild(0).gameObject);
                    }
                    t.GetComponent<SingleValue>().UpdateSingleValue();

                    for (int i = 0; i < selectedTrippleCells.Count; i++)
                    {
                        if (t.GetComponent<SingleValue>().value + currentTrippleMultiplyValue == selectedTrippleCells[i])
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            GameObject go = Instantiate(t.GetComponent<SingleValue>().selectedImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                            go.transform.SetParent(t, false);
                        }
                    }
                }
                break;
        }

        
    }

    public void OnCLickDOubleUp()
    {
        totalBetAmount *= 2;
        UIManager.Instance.totalBetAmountText.text = totalBetAmount.ToString();
        foreach (Transform t in UIManager.Instance.trippleCells)
        {
            for(int i = 0; i < selectedTrippleCells.Count;i++)
            {
                if(t.GetComponent<SingleValue>().value == selectedTrippleCells[i])
                {
                    t.GetChild(0).GetComponent<SelectedButton>().betAmount *= 2;
                    t.GetChild(0).GetComponent<SelectedButton>().betText.text = t.GetChild(0).GetComponent<SelectedButton>().betAmount.ToString();


                }
            }
        }

        foreach (Transform t in UIManager.Instance.doubleCells)
        {
            for (int i = 0; i < selectedDoubleCells.Count; i++)
            {
                if (t.GetComponent<SingleValue>().value == selectedDoubleCells[i])
                {
                    t.GetChild(0).GetComponent<SelectedButton>().betAmount *= 2;
                    t.GetChild(0).GetComponent<SelectedButton>().betText.text = t.GetChild(0).GetComponent<SelectedButton>().betAmount.ToString();
                }
            }
        }

        foreach (Transform t in UIManager.Instance.singleCells)
        {
            for (int i = 0; i <= selectedSingleCells.Count - 1; i++)
            {
                Debug.Log("Int i is " + i);

                if (t.GetComponent<SingleValue>().value == selectedSingleCells[i])  
                {
                    Debug.Log("Selected single cell");

                    t.GetChild(0).GetComponent<SelectedButton>().betAmount *= 2;
                    t.GetChild(0).GetComponent<SelectedButton>().betText.text = t.GetChild(0).GetComponent<SelectedButton>().betAmount.ToString();
                }
            }
        }

    }

    public void OnClickClear()
    {
        ClearAllDoubleCells();
        ClearAllTrippleCells();
        GameManager.Instance.selectedTrippleCells.Clear();
         totalBetAmount = 0;
        UIManager.Instance.totalBetAmountText.text = totalBetAmount.ToString();
    }

    public void CalculateBetWin()
    {
        Debug.Log("Calculating Bet Win");

        for (int i = 0; i <= betTakenSingleNumbers.Count - 1; i++)
        {
            if (singleResult == betTakenSingleNumbers[i])
            {
                Debug.Log("Win bet for " + betTakenSingleNumbers[i]);
                Debug.Log("Win Amount is " + betTakenSingleAmount[i]);
                SetCurrentBalance(betTakenSingleAmount[i] *= 9);
                int value = betTakenSingleAmount[i] * 9;
                winAmount += value / 9;
            }
        }

        for (int i = 0; i <= betTakenDoubleNumbers.Count - 1; i++)
        {
            if (doubleString == betTakenDoubleNumbers[i].ToString())
            {
                Debug.Log("Win bet for " + betTakenDoubleNumbers[i]);
                Debug.Log("Win Amount is " + betTakenDoubleAmount[i]);
                SetCurrentBalance(betTakenDoubleAmount[i] *= 90);
                int value = betTakenDoubleAmount[i] * 90;
                winAmount += value / 90;
            }
        }

        for (int i = 0; i <= betTakenTrippleNumbers.Count - 1; i++)
        {
            if (trippleString == betTakenTrippleNumbers[i].ToString())
            {
                Debug.Log("Win bet for " + betTakenTrippleNumbers[i]);
                Debug.Log("Win Amount is " + betTakenTrippleAmount[i]);
                SetCurrentBalance(betTakenTrippleAmount[i] *= 900);
                int value = betTakenTrippleAmount[i] * 900;
                winAmount += value / 900;
            }
        }
        /* foreach(int i in betTakenDoubleNumbers)
         {
             if(doubleString == i.ToString())
             {
                 Debug.Log("Bet Won FOr " + doubleString);
                 foreach(int t in betTakenDoubleAmount)
                 {
                     Debug.Log("i  is " + t + " bet amount is " + betTakenDoubleAmount[t].ToString());
                     SetCurrentBalance(betTakenDoubleAmount[t] *= 90);
                     Debug.Log("Amount won is " + betTakenDoubleAmount[t].ToString());
                     int value = betTakenDoubleAmount[t] * 90;
                     winAmount += value / 90;
                 }

             }
         }

       *//*  foreach (Transform i in UIManager.Instance.doubleCells)
         {
             if (DoubleValue == i.GetComponent<SingleValue>().value)
             {
                 Debug.Log("Bet Won FOr " + i.GetComponent<SingleValue>().value);
                 Debug.Log("Bet Won FOr value " + i.GetComponent<SingleValue>().value);
                 SetCurrentBalance(i.GetComponent<SingleValue>().value *= 90);
                 int value = i.GetComponent<SingleValue>().value * 90;
                 winAmount += value / 90;



             }
         }*//*
         foreach (Transform i in UIManager.Instance.singleCells)
         {
             if (singleValue == i.GetComponent<SingleValue>().value)
             {
                 Debug.Log("Bet Won FOr " + i.GetComponent<SingleValue>().value);
                 Debug.Log("Bet Won FOr value " + i.GetComponent<SingleValue>().value);
                 SetCurrentBalance(i.GetComponent<SingleValue>().value *= 90);
                 int value = i.GetComponent<SingleValue>().value * 90;
                 winAmount += value / 90;




             }
         }*/
        UIManager.Instance.winAmountText.text = winAmount.ToString();
    }

 
    public void OnClickBetButton()
    {
        if(betTakenSingleNumbers.Count > 0 || betTakenDoubleNumbers.Count > 0 || betTakenTrippleNumbers.Count > 0)
        {
            isBetTaken = false;

        }
        if (!isBetTaken)
        {
            UniqueId = Guid.NewGuid();
            UIManager.Instance.placeyourbetLabel.SetActive(false);
            UIManager.Instance.betIDText.text = "Bet Accepted As " + UniqueId;
           // Debug.Log("New id is " + UniqueId);
            isBetTaken = true;
            
        }

        for (int i = 0; i < UIManager.Instance.singleCells.Length; i++)
        {
            if (UIManager.Instance.singleCells[i].transform.childCount > 0)
            {

                //Debug.Log("i is " + i + "Dictionary of " + UIManager.Instance.singleCells[i].GetComponent<SingleValue>().value );
               
                 betTakenSingleNumbers.Add(UIManager.Instance.singleCells[i].GetComponent<SingleValue>().value);
                 betTakenSingleAmount.Add(currentBetAmount);
            }

        }
        for (int i = 0; i < UIManager.Instance.doubleCells.Length; i++)
        {
            if (UIManager.Instance.doubleCells[i].transform.childCount > 0)
            {
                

                 betTakenDoubleNumbers.Add(UIManager.Instance.doubleCells[i].GetComponent<SingleValue>().value);
                betTakenDoubleAmount.Add(currentBetAmount);
                //betTakenAmount.Add(UIManager.Instance.singleCells[i].GetChild(0).GetComponent<SelectedButton>().betAmount);
            }

        }

        for (int i = 0; i < UIManager.Instance.trippleCells.Length; i++)
        {
            if (UIManager.Instance.trippleCells[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers1.Add(UIManager.Instance.trippleCells[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells2.Length; i++)
        {
            if (UIManager.Instance.trippleCells2[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers2.Add(UIManager.Instance.trippleCells2[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells10.Length; i++)
        {
            if (UIManager.Instance.trippleCells10[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers10.Add(UIManager.Instance.trippleCells10[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells3.Length; i++)
        {
            if (UIManager.Instance.trippleCells3[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers3.Add(UIManager.Instance.trippleCells3[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells4.Length; i++)
        {
            if (UIManager.Instance.trippleCells4[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers4.Add(UIManager.Instance.trippleCells4[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells5.Length; i++)
        {
            if (UIManager.Instance.trippleCells5[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers5.Add(UIManager.Instance.trippleCells5[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells6.Length; i++)
        {
            if (UIManager.Instance.trippleCells6[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers6.Add(UIManager.Instance.trippleCells6[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells7.Length; i++)
        {
            if (UIManager.Instance.trippleCells7[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers7.Add(selectedTrippleCells[i]);
                betTakenTrippleAmount.Add(UIManager.Instance.trippleCells7[i].GetComponent<SingleValue>().value);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells8.Length; i++)
        {
            if (UIManager.Instance.trippleCells8[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers8.Add(UIManager.Instance.trippleCells8[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }

        for (int i = 100; i < UIManager.Instance.trippleCells9.Length; i++)
        {
            if (UIManager.Instance.trippleCells9[i].transform.childCount > 0)
            {
                betTakenTrippleNumbers9.Add(UIManager.Instance.trippleCells9[i].GetComponent<SingleValue>().value);
                betTakenTrippleAmount.Add(currentBetAmount);
            }
        }
        //Datas.instance.PlayBet(Datas.instance.tripplechancestartGameData.tripple_uniqid,Datas.instance.tripplechancestartGameData.tripple_gameplay,1,betTakenSingleNumbers.ToArray(),betTakenDoubleNumbers.ToArray(),betTakenTrippleNumbers1.ToArray(),betTakenTrippleNumbers2.ToArray(),betTakenTrippleNumbers3.ToArray(),betTakenTrippleNumbers4.ToArray(),betTakenTrippleNumbers5.ToArray(),betTakenTrippleNumbers6.ToArray(),betTakenTrippleNumbers7.ToArray(),betTakenTrippleNumbers8.ToArray(),betTakenTrippleNumbers9.ToArray(),betTakenTrippleNumbers10.ToArray(),float.Parse(Datas.instance.tripplechancestartGameData.usercredit),totalBetAmount,1,1, Datas.instance.loginDatas.api_token);
        /* if(i >= 0 && i < 100)
             UIManager.Instance.trippleCells[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 100 && i < 200)

             UIManager.Instance.trippleCells2[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 200 && i < 300)

             UIManager.Instance.trippleCells3[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 300 && i < 400)

             UIManager.Instance.trippleCells4[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 400 && i < 500)

             UIManager.Instance.trippleCells5[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 500 && i < 600)

             UIManager.Instance.trippleCells6[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 600 && i < 700)

             UIManager.Instance.trippleCells7[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 700 && i < 800)

             UIManager.Instance.trippleCells8[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 800 && i < 900)

             UIManager.Instance.trippleCells9[i].GetComponent<SingleValue>().OnButtonUp();
         if (i >= 900 && i < 1000)

             UIManager.Instance.trippleCells10[i].GetComponent<SingleValue>().OnButtonUp();*/
        ClearAllDoubleCells();
            ClearAllSingleCells();
            ClearAllTrippleCells();
        


    }

    public void OnBetWon()
    {
        winAnimator.gameObject.SetActive(true);
        winAnimator.ResetTrigger("WinPopDown");

        winAnimator.SetTrigger("WinPopUp");
        int value = trippleValue / 100;
        Debug.Log("Calling on BEt WOn With " + value);
        UpdateCurrentMultiplyValue(value * 100);
        SettingVictoryImage();
        StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 1));
    }

    public void SettingVictoryImage()
    {
        Debug.Log("Called Setting Victory Image Method");
        if(!trippleResultShown)
        {
            switch(currentTrippleMultiplyValue/100)
            {
                case 0:
                    foreach (Transform t in UIManager.Instance.trippleCells)
                    {
                        if (GameManager.Instance.trippleValue == t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                                Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 1:
                    foreach (Transform t in UIManager.Instance.trippleCells2)
                    {
                        if (GameManager.Instance.trippleValue == 100 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 2:
                    foreach (Transform t in UIManager.Instance.trippleCells3)
                    {
                        if (GameManager.Instance.trippleValue == 200 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (200 + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 3:
                    foreach (Transform t in UIManager.Instance.trippleCells4)
                    {
                        if (GameManager.Instance.trippleValue == 300 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (300 + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 4:
                    foreach (Transform t in UIManager.Instance.trippleCells5)
                    {
                        if (GameManager.Instance.trippleValue == 400 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<VictoryImage>().text.text = (400  + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 5:
                    foreach (Transform t in UIManager.Instance.trippleCells6)
                    {
                        if (GameManager.Instance.trippleValue == 500 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (500  + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 6:
                    foreach (Transform t in UIManager.Instance.trippleCells7)
                    {
                        if (GameManager.Instance.trippleValue == 600 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (600+ t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 7:
                    foreach (Transform t in UIManager.Instance.trippleCells7)
                    {
                        if (GameManager.Instance.trippleValue == 700 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (700 + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 8:
                    foreach (Transform t in UIManager.Instance.trippleCells8)
                    {
                        if (GameManager.Instance.trippleValue == 800+ t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                           
                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            Debug.Log("go name is " + go.name);
                            go.GetComponent<VictoryImage>().text.text = (800 + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
                case 9:
                    foreach (Transform t in UIManager.Instance.trippleCells8)
                    {
                        if (GameManager.Instance.trippleValue == 900 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<VictoryImage>().text.text = (GameManager.Instance.currentTrippleMultiplyValue + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;

                case 10:
                    foreach (Transform t in UIManager.Instance.trippleCells9)
                    {
                        if (GameManager.Instance.trippleValue == 900 + t.GetComponent<SingleValue>().value)
                        {
                            Vector3 spawnLocation = Vector3.zero;
                            RectTransform rectTransform = t.GetComponent<RectTransform>();

                            GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                            go.GetComponent<VictoryImage>().text.text = (900 + t.GetComponent<SingleValue>().value).ToString();
                            go.transform.SetParent(rectTransform, false);
                            UIManager.Instance.resultImages[0] = go.transform;
                            trippleResultShown = true;
                        }
                    }
                    break;
            }
          
        }
       if(!doubleResultShown)
        {
            foreach (Transform t in UIManager.Instance.doubleCells)
            {
                if (GameManager.Instance.DoubleValue == t.GetComponent<SingleValue>().value)
                {
                    Vector3 spawnLocation = Vector3.zero;
                    RectTransform rectTransform = t.GetComponent<RectTransform>();

                    GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                    go.GetComponent<VictoryImage>().text.text = t.GetComponent<SingleValue>().value.ToString();
                    Debug.Log("Image is " + go.name);
                    go.transform.SetParent(rectTransform, false);
                    UIManager.Instance.resultImages[1] = go.transform;
                    doubleResultShown = true;
                }
            }
        }
      if(!singleResultShown)
        {
            foreach (Transform t in UIManager.Instance.singleCells)
            {
                if (GameManager.Instance.singleResult == t.GetComponent<SingleValue>().value)
                {
                    Vector3 spawnLocation = Vector3.zero;
                    RectTransform rectTransform = t.GetComponent<RectTransform>();

                    GameObject go = Instantiate(victoryImage, spawnLocation, Quaternion.identity);
                    go.GetComponent<VictoryImage>().text.text = t.GetComponent<SingleValue>().value.ToString();
                    go.transform.SetParent(rectTransform, false);
                    UIManager.Instance.resultImages[2] = go.transform;
                    singleResultShown = true;
                }
            }
        }

    }

   /*  public IEnumerator CallPlayBet()
    {
        StartCoroutine(Datas.instance.PlayBet((int)totalBetValue, (int)totalBalance, Datas.instance.luckycardsstartGameData.gameplay, betTakenAmount, 14));
        totalBetValue = 0;
        Debug.Log(betTakenAmount.Count);
        for (int i = betTakenAmount.Count - 1; i >= 0; i--)
        {
            // Debug.Log("i is " + i);
            betTakenAmount[i] = 0;

        }
        yield return new WaitForSeconds(3);
        QRCodeGenerator.instance.GenerateBarcode(Datas.instance.luckyCardsPlayBetData.unique_id);
       // GenerateTextFile.instance.PrinterContentFOrLuckyCards(Datas.instance.luckyCardsPlayBetData.unique_id);
        GenerateDigitalTicket.TakeScreenShotStaticMethod(1024, 1024, Datas.instance.luckyCardsPlayBetData.unique_id, 16);
        yield return new WaitForSeconds(3);
        Debug.Log("Printing path is " + Application.persistentDataPath + Datas.instance.luckyCardsPlayBetData.unique_id + ".png");
        //PrintingManager.instance.PrintFiles(Application.persistentDataPath + Datas.instance.luckyCardsPlayBetData.unique_id + ".png");//Datas.instance.luckyCardsPlayBetData.unique_id + ".png"
        string filepath = Application.dataPath + "/Resources/" + Datas.instance.luckyCardsPlayBetData.unique_id + ".png";
        PrintingManager.instance.PrintFiles(filepath);
    
    }*/
}






