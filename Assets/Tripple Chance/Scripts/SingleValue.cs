using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Array2DEditor;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
//using UnityEditor.Experimental.GraphView;
public class SingleValue : MonoBehaviour, IPointerClickHandler
{
    public Text Text;
    public Text valueText;
    public int tabNumber;
    public int value;
    public int rowNumber;
    public int coloumnNumber;
    public bool isTripple;
    public bool isSingle;
    public bool isDouble;
    public GameObject selectedImage;
    public bool readInput;
    public bool isSelected = false;
    GameObject go;

   

    public void Awake()
    {
        valueText = GetComponent<Text>();
       // Debug.Log("Text Name is " + valueText.name);

    }


    private void Start()
    {
        readInput = false;

        valueText.fontSize = 30;
        UpdateSingleValue();
       // this.GetComponent<Button>().onClick.AddListener(OnClickButton);
    }

    public void UpdateSingleValue()
    {
        if (isTripple)
        {
          //  Debug.Log("Value text is " + valueText.name);
            valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
           // value = (GameManager.Instance.currentTrippleMultiplyValue + value );
            GameManager.Instance.ClearTabBarScale();
            GameManager.Instance.tabsBar[GameManager.Instance.currentTrippleMultiplyValue/100].localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else
        {
            valueText.text = value.ToString();

        }
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnButtonUp();
        }
        else if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnClickButton();
        }
        // Do what you want
    }
    public void OnButtonUp()
    {
        Debug.Log("On Button Up");  
        if (isTripple)
        {
            Debug.Log("is tripple");
            switch(GameManager.Instance.currentTrippleMultiplyValue/100)
            {
                case 0:
                    Debug.Log("inside Switch");
                    if (GridManager.instance.tripplecellOccupied.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 1:
                    if (GridManager.instance.tripplecellOccupied1.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied1.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 2:
                    if (GridManager.instance.tripplecellOccupied2.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied2.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 3:
                    if (GridManager.instance.tripplecellOccupied3.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied3.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 4:
                    if (GridManager.instance.tripplecellOccupied4.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied4.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 5:
                    if (GridManager.instance.tripplecellOccupied5.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied5.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 6:
                    if (GridManager.instance.tripplecellOccupied6.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied6.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 7:
                    if (GridManager.instance.tripplecellOccupied7.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied7.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 8:
                    if (GridManager.instance.tripplecellOccupied8.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied8.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

                case 9:
                    if (GridManager.instance.tripplecellOccupied9.GetCell(coloumnNumber, rowNumber))
                    {

                        Debug.Log("tripple cell not exist " + coloumnNumber + " , " + rowNumber + " name is " + this.name);

                        Destroy(go.gameObject);
                        GameManager.Instance.selectedTrippleCells.Remove(GameManager.Instance.currentTrippleMultiplyValue + value);
                        GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                        isSelected = false;
                        if (!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance += GameManager.Instance.currentBetAmount;
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }


                        GridManager.instance.tripplecellOccupied9.SetCell(coloumnNumber, rowNumber, false);
                        GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                        GridManager.instance.UpdateTrippleColoumnButtons();
                        GridManager.instance.UpdateTrippleRowButtons();


                    }
                    break;

            }
           
        }
         else if(isDouble)
            {
                if(GameManager.Instance.selectedDoubleCells.Contains(value))
                {
                    Destroy(go.gameObject);
                    int currentBalance = 0;
                    currentBalance += GameManager.Instance.currentBetAmount;
                    GameManager.Instance.SetCurrentBalance(currentBalance);

                    GameManager.Instance.selectedDoubleCells.Remove(value);
                    GridManager.instance.doubecellOccupied.SetCell(coloumnNumber, rowNumber, false);
                    GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                    GridManager.instance.UpdateGrid(GridManager.instance.GetBools());
                    GridManager.instance.UpdateColoumnButtons();
                    GridManager.instance.UpdateRowButtons();

                }
         }
        else if (isSelected )
        {
                Destroy(go.gameObject);
                int currentBalance = 0;
                currentBalance += GameManager.Instance.currentBetAmount;
                GameManager.Instance.SetCurrentBalance(currentBalance);

                GameManager.Instance.selectedSingleCells.Remove(value);
                GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
                isSelected = false;

            }
    }
     public void OnClickButton()
    {
      //  Debug.Log("Called Onclick Button");
        /*if(!GameManager.Instance.isBetTaken)
        {*/
            if(GameManager.Instance.currentBalance >= GameManager.Instance.currentBetAmount && GameManager.Instance.currentBalance > 0)
            {
                if (isTripple)
                {
                    switch (GameManager.Instance.currentTrippleMultiplyValue / 100)
                    {
                        case 0:
                            if (!GridManager.instance.tripplecellOccupied.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }

                               // Debug.Log("tripple cell exist " + coloumnNumber +" , " + rowNumber + " this name is " + this.name);

                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools(0));

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                            
                            break;


                        case 1:
                            if (!GridManager.instance.tripplecellOccupied1.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied1.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                           
                            break;

                        case 2:
                            if (!GridManager.instance.tripplecellOccupied2.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied2.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                            
                            break;

                        case 3:
                            if (!GridManager.instance.tripplecellOccupied3.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied3.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                            
                            break;

                        case 4:
                            if (!GridManager.instance.tripplecellOccupied4.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied4.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                           
                            break;

                        case 5:
                            if (!GridManager.instance.tripplecellOccupied5.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied5.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                            
                            break;

                        case 6:
                            if (!GridManager.instance.tripplecellOccupied6.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied6.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                           
                            break;

                        case 7:
                            if (!GridManager.instance.tripplecellOccupied7.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied7.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                          
                            break;

                        case 8:
                            if (!GridManager.instance.tripplecellOccupied8.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied8.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                            
                            break;

                        case 9:
                            if (!GridManager.instance.tripplecellOccupied9.GetCell(coloumnNumber, rowNumber))
                            {
                                RectTransform rectTransform = GetComponent<RectTransform>();
                                //  Debug.Log("Button Represents the Number " + value);
                                Vector3 spawnLocation = Vector3.zero;
                                go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                                go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
                                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                                if (!GameManager.Instance.pickingRandomNumber)
                                {
                                    int currentBalance = 0;
                                    currentBalance -= GameManager.Instance.currentBetAmount;
                                    GameManager.Instance.SetCurrentBalance(currentBalance);
                                }


                                go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                                go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                                go.transform.SetParent(rectTransform, false);
                                isSelected = true;
                                GridManager.instance.tripplecellOccupied9.SetCell(coloumnNumber, rowNumber, true);
                                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                                // GridManager.instance.UpdateTrippleGrid(GridManager.instance.GetTrippleBools());

                                GridManager.instance.UpdateTrippleColoumnButtons();
                                GridManager.instance.UpdateTrippleRowButtons();
                            }
                          
                            break;
                    }


                   

                }
                else if (isSingle)
                {
                    if (!isSelected)
                    {
                        RectTransform rectTransform = GetComponent<RectTransform>();
                        Debug.Log("Button Represents the Number " + value);
                        Vector3 spawnLocation = Vector3.zero;
                        go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                        go.GetComponent<SelectedButton>().valueText.text = value.ToString();
                        GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                        int currentBalance = 0;
                        currentBalance -= GameManager.Instance.currentBetAmount;
                        GameManager.Instance.SetCurrentBalance(currentBalance);

                        go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                        go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                        go.transform.SetParent(rectTransform, false);
                        isSelected = true;
                        GameManager.Instance.selectedSingleCells.Add(value);
                    }
                   
                }
                else if (isDouble)
                {
                   // Debug.Log("Inside Double");
                    if (!GameManager.Instance.selectedDoubleCells.Contains(value))
                    {
                        // Debug.Log("Inside get cell if condition");
                        RectTransform rectTransform = GetComponent<RectTransform>();
                        //   Debug.Log("Button Represents the Number " + value);
                        Vector3 spawnLocation = Vector3.zero;
                        go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                        go.GetComponent<SelectedButton>().valueText.text = value.ToString();
                        go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
                        go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                        GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                        if(!GameManager.Instance.pickingRandomNumber)
                        {
                            int currentBalance = 0;
                            currentBalance -= GameManager.Instance.currentBetAmount;
                            Debug.Log("balance is  " + currentBalance);
                            GameManager.Instance.SetCurrentBalance(currentBalance);
                        }
                      

                        go.transform.SetParent(rectTransform, false);

                        GridManager.instance.doubecellOccupied.SetCell(coloumnNumber, rowNumber, true);
                        GameManager.Instance.selectedDoubleCells.Add(value);
                        GameManager.Instance.doublerowsSelected[rowNumber] = false;
                        GameManager.Instance.doublecolsSelected[coloumnNumber] = false;
                        GridManager.instance.UpdateGrid(GridManager.instance.GetBools());
                        GridManager.instance.UpdateColoumnButtons();
                        GridManager.instance.UpdateRowButtons();

                    }
                 
                }
            }
           
            UIManager.Instance.totalBetAmountText.text = GameManager.Instance.totalBetAmount.ToString();
           

    }


    
    public void OnSelectionCell()
    {
        /*if(!GameManager.Instance.isBetTaken)
        {*/
            if (isTripple)
           {
                Debug.Log("OnSelectionCell");
            RectTransform rectTransform = GetComponent<RectTransform>();
            //Debug.Log("Button Represents the Number " + value);
            Vector3 spawnLocation = Vector3.zero;
            go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
            go.GetComponent<SelectedButton>().valueText.text = (GameManager.Instance.currentTrippleMultiplyValue + value).ToString();
            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
                Debug.Log("OnSelectionCell Instantiated");
                int currentBalance = 0;
                currentBalance -= GameManager.Instance.currentBetAmount;
                GameManager.Instance.SetCurrentBalance(currentBalance);
                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
                go.transform.SetParent(rectTransform, false);
                tabNumber = GameManager.Instance.currentTrippleMultiplyValue / 100;
                SetCellOccupiedValue(tabNumber);
                GameManager.Instance.selectedTrippleCells.Add(GameManager.Instance.currentTrippleMultiplyValue + value);
                GameManager.Instance.tempSavingArray[value + GameManager.Instance.currentTrippleMultiplyValue] = true;
                PlayerPrefsExtension.SetBoolArray("ColoumnArray ", GameManager.Instance.tempSavingArray);
              

            }

        else if (isDouble)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            //Debug.Log("Button Represents the Number " + value);
            Vector3 spawnLocation = Vector3.zero;
            go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
            go.GetComponent<SelectedButton>().valueText.text = value.ToString();
                int currentBalance = 0;
                currentBalance -= GameManager.Instance.currentBetAmount;
                GameManager.Instance.SetCurrentBalance(currentBalance);
                GameManager.Instance.totalBetAmount += GameManager.Instance.currentBetAmount;
            go.GetComponent<SelectedButton>().betText.text = GameManager.Instance.currentBetAmount.ToString();
            go.GetComponent<SelectedButton>().betAmount = GameManager.Instance.currentBetAmount;
            go.transform.SetParent(rectTransform, false);
            GameManager.Instance.selectedDoubleCells.Add(value);
            GridManager.instance.doubecellOccupied.SetCell(coloumnNumber, rowNumber, true);
         

        
        UIManager.Instance.totalBetAmountText.text = GameManager.Instance.totalBetAmount.ToString();
        }
        
    }

    public void SetCellOccupiedValue(int tabnumber)
    {
        switch(tabnumber)
        {
            case 0 :Debug.Log("row is " + rowNumber + " coloumn is " + coloumnNumber);
                GridManager.instance.tripplecellOccupied.SetCell(coloumnNumber, rowNumber, true);
                     break;

            case 1:
                GridManager.instance.tripplecellOccupied1.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 2:
                GridManager.instance.tripplecellOccupied2.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 3:
                GridManager.instance.tripplecellOccupied3.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 4:
                GridManager.instance.tripplecellOccupied4.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 5:
                GridManager.instance.tripplecellOccupied5.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 6:
                GridManager.instance.tripplecellOccupied6.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 7:
                GridManager.instance.tripplecellOccupied7.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 8:
                GridManager.instance.tripplecellOccupied8.SetCell(coloumnNumber, rowNumber, true);
                break;

            case 9:
                GridManager.instance.tripplecellOccupied9.SetCell(coloumnNumber, rowNumber, true);
                break;

        }
}

    public void InstantiateSelectedCells(int tabnumber  )
    {
        Debug.Log("Calling Instatiate temp array " + tabnumber);
        Debug.Log("TabNumber is  " + tabNumber);
        
        if (tabnumber == tabNumber)
        {
            foreach (bool b in GameManager.Instance.tempSavingArray)
            {
                if(b)
                {
                    if (coloumnNumber == System.Array.IndexOf(GameManager.Instance.tempSavingArray, b))
                    {
                        GameManager.Instance.ClearAllTrippleCells();
                        RectTransform rectTransform = GetComponent<RectTransform>();
                        //Debug.Log("Button Represents the Number " + value);
                        Vector3 spawnLocation = Vector3.zero;
                        go = Instantiate(selectedImage, spawnLocation, Quaternion.identity);
                        go.GetComponent<SelectedButton>().valueText.text = value.ToString();
                        go.transform.SetParent(rectTransform, false);
                    }
                }
               

            }
        }
    }
    public void RemoveFromDoubleSelection(Transform go)
    {
        if (go.childCount > 0)
        {
            
            Destroy(go.GetChild(0).gameObject);
            GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
           
            UIManager.Instance.totalBetAmountText.text = GameManager.Instance.totalBetAmount.ToString();
        }

    }

    public void RemoveFromSingleSelection(Transform go)
    {
        if (go.childCount > 0)
        {
            GameManager.Instance.totalBetAmount -= GameManager.Instance.currentBetAmount;
            go.GetComponent<SingleValue>().isSelected = false;
            Destroy(go.GetChild(0).gameObject);
            UIManager.Instance.totalBetAmountText.text = GameManager.Instance.totalBetAmount.ToString();
        }

    }
    public void RemoveFromTrippleSelection(Transform go)
    {
     //   Debug.Log(go.name + go.name) ;
      //  Debug.Log("Parent is " + go.parent.name) ;
       if (go.childCount > 0)
            {
           
                Destroy(go.GetChild(0).gameObject);
                UIManager.Instance.totalBetAmountText.text = GameManager.Instance.totalBetAmount.ToString();
            }
       

    }

    
}
