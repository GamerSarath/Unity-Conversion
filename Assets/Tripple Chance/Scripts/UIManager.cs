using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Array2DEditor;
using Unity.VisualScripting;
using TMPro;
using System;
//using UnityEditor.iOS.Extensions.Common;
using System.Runtime.InteropServices;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Transform[] doubleCells;
    public Transform[] trippleCells;
    public Transform[] trippleCells2;
    public Transform[] trippleCells3;
    public Transform[] trippleCells4;
    public Transform[] trippleCells5;
    public Transform[] trippleCells6;
    public Transform[] trippleCells7;
    public Transform[] trippleCells8;
    public Transform[] trippleCells9;
    public Transform[] trippleCells10;
    public Transform[] singleCells;
    public int coloumnLength;
    public int rowLength;
    public GameObject[] rowRemoveButtons;
    public GameObject[] rowSelectButtons;

    public GameObject[] colRemoveButtons;
    public GameObject[] colSelectButtons;
    public delegate void OnRightlickDown();
    public event OnRightlickDown OnLeftClickDown;
    public delegate void OnRightlickUp();
    public event OnRightlickUp OnRightClickDownEvent;
    public GameObject[] tripplerowRemoveButtons;
    public GameObject[] tripplerowSelectButtons;

    public GameObject[] tripplecolRemoveButtons;
    public GameObject[] tripplecolSelectButtons;
    public GameObject blockPanel;
    public int rowsSelected;
    public int colsSelected;
    [SerializeField] Array2DBool[,] cellOccupied;
    public TMP_Text timerText;
    public TMP_Text currentTimeText;
    public TMP_Text[] timeListTexts;
    public TMP_Text[] trippleTexts;
    public TMP_Text[] doublesTexts;
    public TMP_Text[] singleTexts;
    public TMP_Text resultText;
    public TMP_Text totalBetAmountText;
    public TMP_Text balanceAmount;
    public TMP_Text gameIdText;
    public Transform[] resultImages;
    public TMP_Text winAmountText;
    public TMP_Text betIDText;
    public GameObject placeyourbetLabel;
    public TMP_Text usernameText;
    
    public bool readInput;
    
    private void Awake()
    {
        Instance = this;
       
    }
    void Start()
    {
        coloumnLength = 10;
        rowLength = 10;
        blockPanel.SetActive(false);

    }
    private void Update()
    {
        if (GameManager.Instance.gameEnds)
        {
            Invoke(nameof(ClearAllCells),5);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (OnLeftClickDown != null)
            {
                OnLeftClickDown();
            }

        }
        else if(Input.GetMouseButtonUp(1))
        {
            if (OnRightClickDownEvent != null)
            {
                if(readInput)
                {
                    OnRightClickDownEvent();
                    readInput = false;
                }
            }
        }
        
        currentTimeText.text = DateTime.Now.ToString("HH:mm:ss");
    }

    public void UpdateTimeListTexts()
    {
        if(Datas.instance.tripplechancestartGameData.tripple_history_draw_time.Count >0)
        {
            timeListTexts[0].text = Datas.instance.tripplechancestartGameData.tripple_history_draw_time[0];
            trippleTexts[0].text = Datas.instance.tripplechancestartGameData.tripple_history_tripples[0].ToString();
            doublesTexts[0].text = Datas.instance.tripplechancestartGameData.tripple_history_doubles[0].ToString();
            singleTexts[0].text = Datas.instance.tripplechancestartGameData.tripple_history_singles[0].ToString();

        }
        if (Datas.instance.tripplechancestartGameData.tripple_history_draw_time.Count > 1)
        {
            timeListTexts[1].text = Datas.instance.tripplechancestartGameData.tripple_history_draw_time[1];
            trippleTexts[1].text = Datas.instance.tripplechancestartGameData.tripple_history_tripples[1].ToString();
            doublesTexts[1].text = Datas.instance.tripplechancestartGameData.tripple_history_doubles[1].ToString();
            singleTexts[1].text = Datas.instance.tripplechancestartGameData.tripple_history_singles[1].ToString();

        }
        if (Datas.instance.tripplechancestartGameData.tripple_history_draw_time.Count > 2)
        {
            timeListTexts[2].text = Datas.instance.tripplechancestartGameData.tripple_history_draw_time[2];
            trippleTexts[2].text = Datas.instance.tripplechancestartGameData.tripple_history_tripples[2].ToString();
            doublesTexts[2].text = Datas.instance.tripplechancestartGameData.tripple_history_doubles[2].ToString();
            singleTexts[2].text = Datas.instance.tripplechancestartGameData.tripple_history_singles[2].ToString();

        }
        if (Datas.instance.tripplechancestartGameData.tripple_history_draw_time.Count > 3)
        {
            timeListTexts[3].text = Datas.instance.tripplechancestartGameData.tripple_history_draw_time[3];
            trippleTexts[3].text = Datas.instance.tripplechancestartGameData.tripple_history_tripples[3].ToString();
            doublesTexts[3].text = Datas.instance.tripplechancestartGameData.tripple_history_doubles[3].ToString();
            singleTexts[3].text = Datas.instance.tripplechancestartGameData.tripple_history_singles[3].ToString();


        }
        if (Datas.instance.tripplechancestartGameData.tripple_history_draw_time.Count > 4)
        {
            timeListTexts[4].text = Datas.instance.tripplechancestartGameData.tripple_history_draw_time[4];
            trippleTexts[4].text = Datas.instance.tripplechancestartGameData.tripple_history_tripples[4].ToString();
            doublesTexts[4].text = Datas.instance.tripplechancestartGameData.tripple_history_doubles[4].ToString();
            singleTexts[4].text = Datas.instance.tripplechancestartGameData.tripple_history_singles[4].ToString();

        }
        if (Datas.instance.tripplechancestartGameData.tripple_history_draw_time.Count > 5)
        {
            timeListTexts[5].text = Datas.instance.tripplechancestartGameData.tripple_history_draw_time[5];
            trippleTexts[5].text = Datas.instance.tripplechancestartGameData.tripple_history_tripples[5].ToString();
            doublesTexts[5].text = Datas.instance.tripplechancestartGameData.tripple_history_doubles[5].ToString();
            singleTexts[5].text = Datas.instance.tripplechancestartGameData.tripple_history_singles[5].ToString();


        }
    }
    public void SelectDoubleRow(int rowNumber)
    {
        foreach (var cell in doubleCells)
        {

            if (cell.GetComponent<SingleValue>().rowNumber  == rowNumber)
            {
                if(!GameManager.Instance.selectedDoubleCells.Contains(cell.GetComponent<SingleValue>().value ))
                {
                    RemoveAllCellSfromDoubleRow(cell);
                    cell.GetComponent<SingleValue>().OnSelectionCell();
                    rowsSelected++;
                    GridManager.instance.UpdateGrid(GridManager.instance.GetBools());
                    GridManager.instance.UpdateRowButtons();
                    GridManager.instance.UpdateColoumnButtons();

                }

            }

            


        }


    }

    public void SelectTrippleRow(int rowNumber)
    {
        switch (GameManager.Instance.currentTrippleMultiplyValue / 100)
        {
            case 0:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();

                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue/100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateColoumnButtons();


                        }

                    }


                }
                break;

            case 1:
                foreach (var cell in trippleCells2)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            Debug.Log("cell is " + cell.name);
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                             GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue/100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }

                }
                break;

            case 2:
                foreach (var cell in trippleCells3)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

            case 3:
                foreach (var cell in trippleCells4)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

            case 4:
                foreach (var cell in trippleCells5)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

            case 5:
                foreach (var cell in trippleCells6)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

            case 6:
                foreach (var cell in trippleCells7)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

            case 7:
                foreach (var cell in trippleCells8)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

            case 8:
                foreach (var cell in trippleCells9)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

            case 9:
                foreach (var cell in trippleCells9)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            rowsSelected++;
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                        }

                    }


                }
                break;

        }

       


    }

    public void RemoveDoubleRow(int rowNumber)
    {
        foreach (var cell in doubleCells)
        {

            if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
            {
                if (GameManager.Instance.selectedDoubleCells.Contains(cell.GetComponent<SingleValue>().value))
                {
                    int currentBalance = 0;
                    currentBalance += GameManager.Instance.currentBetAmount;
                    GameManager.Instance.SetCurrentBalance(currentBalance);
                    RemoveAllCellSfromDoubleRow(cell);
                    GridManager.instance.UpdateGrid(GridManager.instance.GetBools());
                    GridManager.instance.UpdateRowButtons();
                    GridManager.instance.UpdateColoumnButtons();

                    //   cell.GetComponent<SingleValue>().OnSelectionCell();
                }

            }




        }


    }

    public void RemoveTrippleRow(int rowNumber)
    {
        switch(GameManager.Instance.currentTrippleMultiplyValue/100)
        {
            case 0:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 1:
                foreach (var cell in trippleCells2)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 2:
                foreach (var cell in trippleCells3)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 3:
                foreach (var cell in trippleCells4)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 4:
                foreach (var cell in trippleCells5)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 5:
                foreach (var cell in trippleCells6)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 6:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 7:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 8:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;

            case 9:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().rowNumber == rowNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            RemoveAllCellSfromTrippleRow(cell);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(GameManager.Instance.currentTrippleMultiplyValue / 100));
                            GridManager.instance.UpdateTrippleRowButtons();
                            GridManager.instance.UpdateTrippleColoumnButtons();

                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                        }

                    }

                }
                break;
        }


    }

    public void SelectDoubleColoumn(int coloumnnumber)
    {
        foreach (var cell in doubleCells)
        {

            if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
            {
                if (!GameManager.Instance.selectedDoubleCells.Contains(cell.GetComponent<SingleValue>().value))
                {
                    RemoveAllCellSfromDoubleRow(cell);
                    cell.GetComponent<SingleValue>().OnSelectionCell();
                    GridManager.instance.UpdateGrid(GridManager.instance.GetBools());
                    colsSelected++;
                    GridManager.instance.UpdateColoumnButtons();
                    GridManager.instance.UpdateRowButtons();

                }

            }




        }


    }
    public void SelectTrippleColoumn(int coloumnnumber)
    {
        Debug.Log("Clicked select tripple coloumn " + coloumnnumber);
        switch(GameManager.Instance.currentTrippleMultiplyValue/100)
        {
            case 0:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        Debug.Log("Clicked select tripple coloumn - Inside if coloumn passsed");
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            Debug.Log("Clicked select tripple coloumn - cell contain check passed");
                            //RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }
                    
                }
                break;

            case 1:
                foreach (var cell in trippleCells2)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        Debug.Log("Clicked select tripple coloumn - Inside if coloumn passsed");

                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            Debug.Log("Clicked select tripple coloumn - cell contain check passed");

                            //RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(1));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 2:
                foreach (var cell in trippleCells3)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {

                           // RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(2));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 3:
                foreach (var cell in trippleCells4)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {

                            //RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(3));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 4:
                foreach (var cell in trippleCells5)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {

                           // RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(4));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 5:
                foreach (var cell in trippleCells6)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(5));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 6:
                foreach (var cell in trippleCells7)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {

                           // RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(6));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 7:
                foreach (var cell in trippleCells8)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {

                           // RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(7));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 8:
                foreach (var cell in trippleCells9)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        { 

                           // RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(8));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;

            case 9:
                foreach (var cell in trippleCells10)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnnumber)
                    {
                        if (!GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {

                           // RemoveAllCellSfromTrippleRow(cell);
                            cell.GetComponent<SingleValue>().OnSelectionCell();
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(9));
                            colsSelected++;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();

                        }

                    }

                }
                break;
        }
        


    }
    public void RemoveDoubleColoumn(int coloumnNumber)
    {
        foreach (var cell in doubleCells)
        {

            if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
            {
                if (GameManager.Instance.selectedDoubleCells.Contains(cell.GetComponent<SingleValue>().value))
                {
                    RemoveAllCellSfromDoubleRow(cell);
                    int currentBalance = 0;
                    currentBalance += GameManager.Instance.currentBetAmount;
                    GameManager.Instance.SetCurrentBalance(currentBalance);
                    GridManager.instance.UpdateGrid(GridManager.instance.GetBools());
                    //   cell.GetComponent<SingleValue>().OnSelectionCell();
                    colsSelected--;
                    GridManager.instance.UpdateColoumnButtons();
                    GridManager.instance.UpdateRowButtons();
                }

            }




        }


    }

    public void RemoveTrippleColoumn(int coloumnNumber)
    {
      //  Debug.Log("Clicked Remove Tripple Coloumn " + coloumnNumber);
        switch(GameManager.Instance.currentTrippleMultiplyValue/100)
        {
            case 0:
                foreach (var cell in trippleCells)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                      //  Debug.Log("Clicked Remove Tripple Coloumn - Coloumn check passed");

                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            Debug.Log("Clicked Remove Tripple Coloumn - Inside last if");

                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 1:
                foreach (var cell in trippleCells2)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        Debug.Log("Clicked Remove Tripple Coloumn - inside coloumn check");

                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            Debug.Log("Clicked Remove Tripple Coloumn - inside last if");

                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(1));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 2:
                foreach (var cell in trippleCells3)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(2));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 3:
                foreach (var cell in trippleCells4)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(3));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 4:
                foreach (var cell in trippleCells5)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(4));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 5:
                foreach (var cell in trippleCells6)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(5));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 6:
                foreach (var cell in trippleCells7)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(6));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 7:
                foreach (var cell in trippleCells8)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(7));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 8:
                foreach (var cell in trippleCells9)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(8));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;

            case 9:
                foreach (var cell in trippleCells10)
                {

                    if (cell.GetComponent<SingleValue>().coloumnNumber == coloumnNumber)
                    {
                        if (GameManager.Instance.selectedTrippleCells.Contains(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue))
                        {
                            RemoveAllCellSfromTrippleRow(cell);
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                            GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(9));
                            //   cell.GetComponent<SingleValue>().OnSelectionCell();
                            colsSelected--;
                            GridManager.instance.UpdateTrippleColoumnButtons();
                            GridManager.instance.UpdateTrippleRowButtons();
                        }

                    }

                }
                break;
        }

        

    }
    public void ClearAllCells()
    {
        foreach(Transform cell in singleCells)
        {

            RemoveAllCellSfromSingleRow(cell);
            
        }

        foreach(Transform cell in trippleCells)
        {
            RemoveAllCellSfromTrippleRow(cell);
        }
        foreach (Transform cell in doubleCells)
        {
            RemoveAllCellSfromDoubleRow(cell);
        }

        for (int i = 0; i < 10; i++)
        {
            RemoveTrippleColoumn(i);
        }

        for (int i = 0; i < 10; i++)
        {
            RemoveDoubleColoumn(i);
        }
        GridManager.instance.UpdateGrid(GridManager.instance.GetBools());
      //      GridManager.instance.UpdateGrid(GridManager.instance.GetTrippleBools());
        GridManager.instance.UpdateRowButtons();
        GridManager.instance.UpdateColoumnButtons();
        GridManager.instance.UpdateTrippleRowButtons();
        GridManager.instance.UpdateTrippleColoumnButtons();
        GameManager.Instance.gameEnds = false; 
        GameManager.Instance.spinMark.SetActive(false);
        //GameManager.Instance.spinDelay = 125 - Datas.instance.tripplechancestartGameData.tripple_gametime;
        GameManager.Instance.spinWheelOne.GetComponent<SpinManager>().Torque = 500;
        GameManager.Instance.spinWheelTwo.GetComponent<SpinManagerTwo>().Torque = 500;
        GameManager.Instance.spinWheelThree.GetComponent<SpinManagerThree>().Torque = 500;
        GameManager.Instance.spinWheelOne.GetComponent<Rigidbody2D>().angularDrag = 0;
        GameManager.Instance.spinWheelTwo.GetComponent<Rigidbody2D>().angularDrag = 0; ;
        GameManager.Instance.spinWheelThree.GetComponent<Rigidbody2D>().angularDrag = 0;
     
        GameManager.Instance.spinWheelOne.GetComponent<SpinManager>().spinWheel = false;
        GameManager.Instance.spinWheelTwo.GetComponent<SpinManagerTwo>().spinWheel = false;
        GameManager.Instance.spinWheelThree.GetComponent<SpinManagerThree>().spinWheel = false;
        GameManager.Instance.OnClickClear();

        CancelInvoke();
        GameManager.Instance.StartGame();

    }
    public void ClearDoubleRowSelection(Transform cell)
    {
        Debug.Log("Inside clear row selection if statement");
        GameManager.Instance.selectedDoubleCells.Remove(cell.GetComponent<SingleValue>().value);
        GridManager.instance.doubecellOccupied.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
        cell.GetComponent<SingleValue>().RemoveFromDoubleSelection(cell); 
    }

    public void RemoveAllCellSfromDoubleRow(Transform cell)
    {
        for(int i = 0; i < rowLength; i++)
        {
            Debug.Log("Calling remove");
            GameManager.Instance.selectedDoubleCells.Remove(cell.GetComponent<SingleValue>().value);
            GridManager.instance.doubecellOccupied.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
            cell.GetComponent<SingleValue>().RemoveFromDoubleSelection(cell);
        }
     
    }

    void RemoveFromParentCell(Transform cell)
    {
        foreach(Transform child in cell)
        {
            if(child.childCount > 0)
            {
                Destroy(child.GetChild(0));
            }
        }
    }
    public void RemoveAllCellSfromTrippleRow(Transform cell)
    {
        switch(GameManager.Instance.currentTrippleMultiplyValue/100)
        {
            case 0:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 1:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied1.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                  
                }
                break;

            case 2:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied2.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 3:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied3.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 4:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied4.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 5:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied5.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 6:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied6.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 7 :
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied7.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 8:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied8.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;

            case 9:
                for (int i = 0; i < rowLength; i++)
                {
                    Debug.Log("Calling remove");
                    GameManager.Instance.selectedTrippleCells.Remove(cell.GetComponent<SingleValue>().value + GameManager.Instance.currentTrippleMultiplyValue);
                    GridManager.instance.tripplecellOccupied9.SetCell(cell.GetComponent<SingleValue>().coloumnNumber, cell.GetComponent<SingleValue>().rowNumber, false);
                    cell.GetComponent<SingleValue>().RemoveFromTrippleSelection(cell);
                }
                break;
        }
       

    }
    public void RemoveAllCellSfromSingleRow(Transform cell)
    {
        for (int i = 0; i < rowLength; i++)
        {
            //Debug.Log("Calling remove");
            GameManager.Instance.selectedSingleCells.Remove(cell.GetComponent<SingleValue>().value);
            cell.GetComponent<SingleValue>().RemoveFromSingleSelection(cell);
        }

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
