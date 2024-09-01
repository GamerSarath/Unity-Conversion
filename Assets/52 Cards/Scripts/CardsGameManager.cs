using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsGameManager : MonoBehaviour
{
    public static CardsGameManager instance;
    public Sprite[] coinSprite;
    public bool startRolling;
    public CardsSpinManager[] spinManager;

    public int timeOffset;
    public int currentBetAmount = 5;
    public int totalBetTaken = 0;
   
    public bool gameEnds;
    bool fresh = true;
    public string winString;
    public List<string> historyIconList = new List<string>();
    public List<string> historyNumberList = new List<string>();
    public Sprite[] historyList;
    public Image[] historyPositions;
    public GameObject historyParent;
    public Sprite[] IconSprites;
    public Sprite[] numberSprites;
    public int winAMount;
   public bool advanceUpdated = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameStarts();
    }

    private void Update()
    {
        if(gameEnds)
        {
            Invoke(nameof(GameStarts), 15);
        }
    }
  
    public void GameStarts()
    {

        Debug.Log("!!!!!NEW GAME STARTS HERE!!!!");
        
        if (fresh)
        {

            advanceUpdated = false;

            CardsUIManager.instance.UpdateDrawTimeMethod();
            fresh = false;

        }
        else
        {
                
            CardsUIManager.instance.UpdateTotalBetAmount(0);

            advanceUpdated = false;
            Timer.Instance.enabled = true;
            Debug.Log("!!NOT FRESH!!");
            //  yield return new WaitForSeconds(5);
            Timer.Instance.timeLeft = Timer.Instance.maxTime;
            CardsUIManager.instance.UpdateDrawTimeMethod();
            CardsUIManager.instance.ClearRowAndColoumnButtons();    
            gameEnds = false;
        }
       
    }
    
    public void SetHistroyFromBackend()
    {
        Debug.Log("Setting History From Backend");
        historyPositions[0].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[0])];
        historyPositions[1].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[1])];
        historyPositions[2].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[2])];
        historyPositions[3].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[3])];
        historyPositions[4].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[4])];
        historyPositions[5].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[5])];
        historyPositions[6].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[6])];
        historyPositions[7].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[7])];
        historyPositions[8].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[8])];
       /* historyPositions[9].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[9])];
        historyPositions[10].sprite = historyList[System.Int32.Parse(Datas.instance.fiftyTwoCardsstartGameData.card52_history[10])];*/




    }
    public void DecideVictory()
    {
        Debug.Log("Calling Decide Victory");
        for(int i = 0; i < spinManager.Length; i++)
        {
            winString = spinManager[1].iconString + "" + spinManager[0].numberString;
        }
        Debug.Log("win string is " + winString);
       // yield return new WaitForSeconds(5);
        DecideWinString(winString);
    }

    public void DecideWinString(string winstring)
    {
        Debug.Log("Calling Decide Win String . winstring is " + winstring );
     
        foreach (Cards card in this.GetComponent<CardFunctions>().repeatList)
        {
           // Debug.Log("Card is " + card.cardString);
            if (card.cardString == winstring)
            {
                Debug.Log("Card bet is " + card.betAmount);
                Debug.Log("Calling Decide Victory. card string is " + card.cardString + " win string is " + winstring + "Card is " + card.betAmount);
                winAMount = card.BetAmount * 10;
                CardsUIManager.instance.UpdateWinAmount(winAMount);
                totalBetTaken = 0;
                Debug.Log("Win AMount is " + winAMount);
             //   advanceUpdated =     false;
            }
        }
        /*for(int i = this.GetComponent<CardFunctions>().selectedCards.Count - 1; i >= 0; i-- )
        {
            this.GetComponent<CardFunctions>().selectedCards[i].OnDeSelectCard();

        }*/
       
       

    }

    public void OnClickRepeatButton()
    {
        foreach(Cards card in  this.GetComponent<CardFunctions>().listedCards)
        {
            foreach(Card cards in this.GetComponent<CardFunctions>().repeatList)
            {
                if(cards.indexNumber == card.indexNumber)
                {
                    cards.OnSelectCard();
                }
            }
        }
       

    }

    public void OnClickDoubles()
    {
        foreach(Cards card in this.GetComponent<CardFunctions>().selectedCards)
        {
            card.betAmount = card.betAmount * 2;
            totalBetTaken += card.betAmount;
            CardsUIManager.instance.    UpdateTotalBetAmount(totalBetTaken);
            card.currentSprite.GetComponent<Image>().sprite = card.SelectCoinSprite();
        }
    }

    public void OnClickClear()
    {
        for(int i = this.GetComponent<CardFunctions>().selectedCards.Count - 1; i >= 0; i--)
        {

            this.GetComponent<CardFunctions>().selectedCards[i].OnDeSelectCard();
        }
        totalBetTaken = 0;
        CardsUIManager.instance.UpdateTotalBetAmount(CardsGameManager.instance.totalBetTaken);
    }

    public void OnClickBet()
    {
        int tempInteger = 0;

        for (int i = this.GetComponent<CardFunctions>().selectedCards.Count - 1;i >= 0;  i--)
        {
            tempInteger = this.GetComponent<CardFunctions>().selectedCards[i].betAmount;
            this.GetComponent<CardFunctions>().selectedCards[i].clearBet = true;
            this.GetComponent<CardFunctions>().bettakenList.Add(this.GetComponent<CardFunctions>().selectedCards[i]);
            this.GetComponent<CardFunctions>().bettakenList[(this.GetComponent<CardFunctions>().selectedCards.Count - 1) - i].betAmount = tempInteger;

            this.GetComponent<CardFunctions>().selectedCards[i].OnDeSelectCard();
        }
        foreach (Cards card in this.GetComponent<CardFunctions>().bettakenList)
        {
            card.BetAmount = card.betAmount;
        }
    }

    public void UpdateBetAmount()
    {
        foreach (Cards card in this.GetComponent<CardFunctions>().bettakenList)
        {
            card.BetAmount =0;

        }
        CardsUIManager.instance.UpdateTotalBetAmount(0);

    }
    public void OnClickAdvance()
    {
        int tempInteger = 0;
        for (int i = this.GetComponent<CardFunctions>().selectedCards.Count - 1; i >= 0; i--)
        {
            tempInteger = this.GetComponent<CardFunctions>().selectedCards[i].betAmount;
            Debug.Log("trmp is " + tempInteger);
            this.GetComponent<CardFunctions>().selectedCards[i].clearBet = true;
            this.GetComponent<CardFunctions>().advanceList.Add(this.GetComponent<CardFunctions>().selectedCards[i]);
            this.GetComponent<CardFunctions>().advanceList[( this.GetComponent<CardFunctions>().selectedCards.Count - 1) - i].betAmount = tempInteger;
            Debug.Log("temp int is " + tempInteger + " bet is " + this.GetComponent<CardFunctions>().advanceList[(this.GetComponent<CardFunctions>().selectedCards.Count - 1) - i].betAmount);
            this.GetComponent<CardFunctions>().selectedCards[i].OnDeSelectCard();
            foreach (Cards card in this.GetComponent<CardFunctions>().advanceList)
            {
                card.BetAmount = card.betAmount;
            }
        }
    }
}
