using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;
using Random = UnityEngine.Random;
using UI.Dates;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class LuckyCards_GameController : MonoBehaviour
{
    public static LuckyCards_GameController instance;
    public bool gameStarted = false;

    public LuckyCard_CardType card;
    public string cardName;
    public List<LuckyCards_Cards> listedCards = new List<LuckyCards_Cards>();
    public List<LuckyCards_Cards> selectedCards = new List<LuckyCards_Cards>();
    public int selectedCard;
    public AudioMixer mixer;
    public UnityEngine.UI.Button timeBtn;
    string setTime = "LuckyCards12";
    [SerializeField] float startingTime = 10;
    [SerializeField] float currentTime;

    float deadLineTime = 10f;
    float warningTime = 15f;
    float resetingTime;
    float restartTime;
    string apiUrl = "https://suhail10.pythonanywhere.com/api/data";

    int maxSizeForList = 6;

    public GameObject chip;
    public GameObject jackHeartChip;
    GameObject jackSpadeChip;
    GameObject jackSDiamondChip;
    GameObject jackClubChip;
    GameObject queenHeartChip;
    GameObject queenSpadeChip;
    GameObject queenDiamondChip;
    GameObject queenClubChip;
    GameObject kingHeartChip;
    GameObject kingSpadeChip;
    GameObject kingDiamondChip;
    GameObject kingClubChip;

    public GameObject[] bonusDisplayer;
    public Sprite[] highlightedChips;
    public UnityEngine.UI.Button[] chippies;


    public GameObject coin2;
    public GameObject coin5;
    public GameObject coin10;
    public GameObject coin50;
    public GameObject coin100;
    public GameObject coin500;

    public float totalBalance;
    public float temp;

    // public RectTransform historyStorage;

    public GameObject prevCards;
    public Animator spinWheel;
    public Animator innerWheel;

    public TextMeshProUGUI balanceTexts;

    public TextMeshProUGUI countDownTime;
    public TextMeshProUGUI actualTimer;

    public TextMeshProUGUI betAcceptedText;
    public TextMeshProUGUI totalWinText;
    public TextMeshProUGUI totalBetText;

    public TextMeshProUGUI playerId;
    public TextMeshProUGUI gameId;

    public TextMeshProUGUI historyStoringPanelText;

    public LuckyCards_Cards[] cards;


    public bool jackOfHearts;
    public bool jackOfSpades;
    public bool jackOfDiamonds;
    public bool jackOfClubs;

    public bool queenOfHearts;
    public bool queenOfSpades;
    public bool queenOfDiamonds;
    public bool queenOfClubs;

    public bool kingOfHearts;
    public bool kingOfSpades;
    public bool kingOfDiamonds;
    public bool kingOfClubs;

    // public List<string> collection = new List<string> ();

    public Sprite winnerSprite;
    public Sprite[] cardSprites;

    public List<Sprite> winnerList = new List<Sprite>();

    int cardIndex;

    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;

    [SerializeField] float prevBalance;
    public float totalBetValue;
    [SerializeField] float halfBalance;
    [SerializeField] float value;
    [SerializeField] float subValue;
    [SerializeField] float previousBet;
    [SerializeField] float claimableBalance;
    String claimBalanceAmountStrg;
    [SerializeField] float claimBalanceAmount;
    [SerializeField] float winAmount;
    [SerializeField] float totalWinAmount;

    public UnityEngine.UI.Toggle autoClaim;
    [SerializeField] UnityEngine.UI.Toggle printTicket;

    public bool repeatBool = false;
    public float betOnJackHearts1;
    public float betOnJackSpades1;
    public float betOnJackDiamonds1;
    public float betOnJackClubs1;

    public float betOnQueenHearts1;
    public float betOnQueenSpades1;
    public float betOnQueenDiamonds1;
    public float betOnQueenClubs1;

    public float betOnKingHearts1;
    public float betOnKingSpades1;
    public float betOnKingDiamonds1;
    public float betOnKingClubs1;

    float betOnAllHearts;
    float betOnAllSpades;
    float betOnAllDiamonds;
    float betOnAllClubs;

    float betOnAllJacks;
    float betOnAllQueens;
    float betOnAllKings;


    float winningAmount = 10;
    int RandomWinner;
    LuckyCards_CardType winner;
    public int winnerNumber;

    public GameObject settingsPanel;

    public UnityEngine.UI.Button betButton;
    public UnityEngine.UI.Button repeatButton;
    public UnityEngine.UI.Button doubleUpButton;
    public UnityEngine.UI.Button settingsButton;

    public UnityEngine.UI.Button claimWinButton;
    public UnityEngine.UI.Button balanceClaimBtn;
    public TMP_InputField claimField;

    public GameObject rulesPanel;
    public UnityEngine.UI.Button rules;
    public GameObject reportPanel;
    public UnityEngine.UI.Button report;
    public GameObject resultsPanel;
    public UnityEngine.UI.Button results;
    public GameObject gameHistoryPanel;
    public UnityEngine.UI.Button gameHistory;
    public GameObject unclaimedPanel;
    public UnityEngine.UI.Button unclaimed;

    public float betOnJackHearts;
    public float betOnJackSpades;
    public float betOnJackDiamonds;
    public float betOnJackClubs;

    public float betOnQueenHearts;
    public float betOnQueenSpades;
    public float betOnQueenDiamonds;
    public float betOnQueenClubs;

    public float betOnKingHearts;
    public float betOnKingSpades;
    public float betOnKingDiamonds;
    public float betOnKingClubs;
    public float chipStorage;

    public float totalBetOnJackHearts;
    public float totalBetOnJackSpades;
    public float totalBetOnJackDiamonds;
    public float totalBetOnJackClubs;

    public float totalBetOnQueenHearts;
    public float totalBetOnQueenSpades;
    public float totalBetOnQueenDiamonds;
    public float totalBetOnQueenClubs;

    public float totalBetOnKingHearts;
    public float totalBetOnKingSpades;
    public float totalBetOnKingDiamonds;
    public float totalBetOnKingClubs;

    [SerializeField] GameObject jackHeartsCard;
    [SerializeField] GameObject jackSpadesCard;
    [SerializeField] GameObject jackDiamondsCard;
    [SerializeField] GameObject jackClubsCard;

    [SerializeField] GameObject queenHeartsCard;
    [SerializeField] GameObject queenSpadesCard;
    [SerializeField] GameObject queenDiamondsCard;
    [SerializeField] GameObject queenClubsCard;

    [SerializeField] GameObject kingHeartsCard;
    [SerializeField] GameObject kingSpadesCard;
    [SerializeField] GameObject kingDiamondsCard;
    [SerializeField] GameObject kingClubsCard;


    float chip2Value = 2;
    float chip5Value = 5;
    float chip10Value = 10;
    float chip50Value = 50;
    float chip100Value = 100;
    float chip500Value = 500;

    public LuckyCards_SpinManager[] spinManagers;
    public bool showingwinnerPanel = false;

    [SerializeField] LuckyCards_Cards winnerCard;
    public float[] dragValuesOfSymbolHeart;
    public float[] dragValuesOfSymbolSpade;
    public float[] dragValuesOfSymbolDiamond;
    public float[] dragValuesOfSymbolClub;

    public float[] dragValuesOfNumberJack;
    public float[] dragValuesOfNumberQueen;
    public float[] dragValuesOfNumberKing;

    public float[] dragValuesSymbol;
    public float[] dragValueNumber;
    public int randomSymbol;
    public int randomNumber;
    public bool timeUpdated = false;
    public Image[] historySlots;
    public bool mobileInput = false;
    public Image winnerDisplay;
    public Sprite[] winnerSprites;

    public float userCredit;
    public List<int> betTakenAmount;

    public TMP_Text[] infoPanelHistory;

    public GameObject infofresultItemObect;

    public Transform inforesultItemParent;
    public GameObject inforeportItemObect;

    public Transform infounclaimedticketstemParent;
    public GameObject infounclaimedticketsItemObject;
    public Transform infohistoryItemParent;
    public GameObject infohistoryItemObject;

    public Transform inforeportItemParent;

    public int unclaimedBalance;
    public int claimedBalance;
    public string currentTicket;
    public string claimableTicket;
    string claimTicket;
    public DatePicker todatePicker;
    public DatePicker fromdatePicker;

    public DatePicker historytodatePicker;
    public DatePicker historyfromdatePicker;
    public bool isInsidetheRange;
    public string startDate;
    public string endDate;
    public TMP_Text balanceAmountText;
    public TMP_Text winAMountText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(Datas.instance.GetSummary(14, DateTime.Now, DateTime.Today.AddDays(-7), 1, 2));
        gameStarted = false;
        startingTime = 120 - Datas.instance.luckycardsstartGameData.gametime;
        currentTime = startingTime;
        restartTime = startingTime - 1;
        showingwinnerPanel = false;
        totalBalance = float.Parse(Datas.instance.luckycardsstartGameData.usercredit);
        balanceAmountText.text = "Balance              " + totalBalance.ToString();
        SaveAndRetrieveBalance();
        OnAddingBalanceAmountToUnClaimedBalance();
        /* if (PlayerPrefs.HasKey(setTime))
         {
             CheckTimerData();
         }
         else
         {
             CheckTimerData();
         }*/
        // StartTimer();
        resetingTime = startingTime - deadLineTime;
        playerId.text = Datas.instance.loginDatas.username;
        gameId.text = Datas.instance.luckycardsstartGameData.gameplay.ToString();
        prevBalance = totalBalance;
        chipStorage = chip2Value;
        chip = coin2;

    }


    void Update()
    {
        // MainTimer();
       // BalanceAmount();
        SettingsFeature();
        //DisplayBetOnCards();
        totalBetValue = value;
        halfBalance = totalBalance / 2;
       // totalBetText.text = totalBetValue.ToString(); //To display the total bet amount


    }

    public void SaveAndRetrieveBalance()
    {
        if (!PlayerPrefs.HasKey("UnclaimedBalance"))
        {
            PlayerPrefs.SetInt("UnclaimedBalance", 0);
        }
        else
        {
            unclaimedBalance = PlayerPrefs.GetInt("UnclaimedBalance");
        }

        if (!PlayerPrefs.HasKey("ClaimedBalance"))
        {
            PlayerPrefs.SetInt("ClaimedBalance", 0);
        }
        else
        {
            claimedBalance = PlayerPrefs.GetInt("ClaimedBalance");

        }
    }
    //Each and every function will be related to this timer
    void MainTimer()
    {
        //To display the RealWorld Time
        //  actualTimer.text = DateTime.Now.ToShortTimeString();

        //To display the countdown time of 120 seconds 
        if (showingwinnerPanel)
        {
            countDownTime.text = 0.ToString("0");

        }
        else
        {
            countDownTime.text = currentTime.ToString("0");

        }
        currentTime -= Time.deltaTime;
        if (currentTime <= 5)
        {
            // StartCoroutine(Datas.instance.GetSummary(14));

            if (!timeUpdated)
            {
                StartCoroutine(Datas.instance.DrawBet(14));
                timeUpdated = true;
            }
        }
        if (currentTime <= 0)
        {
            //  StartCoroutine(Datas.instance.GetSummary(14));

            currentTime = 10;
            countDownTime.text = 0.ToString("0");


            timeUpdated = true;

            // currentTime = 0;




        }


        if (currentTime < deadLineTime)
        {
            chipStorage = 0;
            ResetChipValues();
            claimField.text = " ";
            totalBalance += totalBetValue;
            countDownTime.color = Color.red;
            ChangeSlotColor();
            KillingChips();
            //KillBonusDisplay();
            ChippiesOff();
            ButtonsSwitchOff();

        }



        else if (currentTime < restartTime)
        {

            ChippiesOn();
            ButtonsSwitchOn();
            countDownTime.color = Color.green;


        }



    }

    //Main Timer Function
    /*public void StartTimer()
    {
        InvokeRepeating("ShowTimer", 1, 1.2f);
        DateTime currentTime2 = DateTime.Now;
        PlayerPrefs.SetString(setTime, currentTime2.ToLongDateString());
       // Debug.Log("Time " + currentTime2);
    }
    void ShowTimer()
    {
        countDownTime.text = currentTime.ToString();
        //Debug.Log("Timer " + currentTime);
        currentTime -= 1;
        if (currentTime <= -1)
        {
            //countDownTime.text = currentTime.ToString();
            CancelInvoke("ShowTimer");
            ResetTimer();
            spinWheel.Play("Idle");
            innerWheel.Play("Idle");
            Invoke("WinnerSelection", .3f);           
            SetAllFlase();
            TotalValueOfBetStored();
            ResetTotalValueOnEveryCards();
            Invoke("ResetTheRebetValuesToZero", resetingTime);
            Invoke("CancelTheReset", resetingTime + 2f);
            


        }
        WarningMessages();
    }
    void ResetTimer()
    {
        currentTime = startingTime;
        timeBtn.interactable = true;
        Invoke("StartTimer", 12f);
    }
    void CheckTimerData()
    {
        string lastData = PlayerPrefs.GetString(setTime);
        DateTime date = DateTime.Parse(lastData, System.Globalization.CultureInfo.CurrentCulture);

        DateTime currentTime1 = DateTime.Now;
        TimeSpan timeSpan = currentTime1 - date;
       // Debug.Log(timeSpan.Seconds);

        int sec = timeSpan.Seconds;
        int currentSec = sec % startingTime;
       // Debug.Log("timer sec " + currentSec);
        currentTime = startingTime - currentSec;
        
        StartTimer();
    }*/

    //To display the balance amount or main balance 
    void BalanceAmount()
    {


        balanceTexts.text = "Balance              " + totalBalance.ToString();
        if (totalBalance <= 0)
        {
            ButtonsSwitchOff();
        }
        else if (totalBalance >= 0)
        {
            ButtonsSwitchOn();
        }

        /*if (value <= totalBalance)
        {
            ButtonsSwitchOn();
        }
        else if (value > totalBalance)
        {
            ButtonsSwitchOff();
        }*/


    }
    //To set the volume of the game

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
        //Debug.Log(volume);
    }

    //This code places the bet
    //The placed bet amount is deducted from the balance amount
    public void BetPlaced()
    {
        if (currentTime > deadLineTime)
        {

            if (value > 0)
            {
                prevBalance = totalBalance;
                //totalBalance -= totalBetValue;
                BalanceAmount();
                BetPlacedComment();
                LastplacedBetAmount();
                StoringReBetValues();
                TotalValueOnEveryCards();
                ResetChipValues();
                value = 0;
                ChangeSlotColor();
                KillingChips();
                repeatBool = true;
                Debug.Log("Bet Placed : " + totalBetValue);
            }
        }
        StartCoroutine(CallPlayBet());
       
    }


    //This code doubles the amount of the placed bet
    //The placed bet amount is deducted from the balance amount
    public void DoubleUp()
    {
        if (currentTime > deadLineTime)
        {
            repeatBool = true;

            if (halfBalance > totalBetValue)
            {
                DoubleOption();
                AssigningTotalBetvalues();

                /*totalBetValue += totalBetValue;
                value = totalBetValue;*/
                //tempBet = totalBalance - totalBetValue;



                if (betOnJackHearts > 0)
                {
                    if (halfBalance > betOnJackHearts && totalBetValue < halfBalance)
                    {
                        Debug.Log("hiii");
                        JackHeartsSpawner();
                    }

                }
                if (betOnJackSpades > 0)
                {
                    if (halfBalance > betOnJackSpades && totalBetValue < halfBalance)
                    {
                        JackSpadeSpawner();
                    }

                }
                if (betOnJackDiamonds > 0)
                {
                    if (halfBalance > betOnJackDiamonds && totalBetValue < halfBalance)
                    {
                        JackDiamondSpawner();
                    }

                }
                if (betOnJackClubs > 0)
                {
                    if (halfBalance > betOnJackClubs && totalBetValue < halfBalance)
                    {
                        JackClubSpawner();
                    }

                }
                if (betOnQueenHearts > 0)
                {
                    if (halfBalance > betOnQueenHearts && totalBetValue < halfBalance)
                    {
                        QueenHeartSpawner();
                    }

                }
                if (betOnQueenSpades > 0)
                {
                    if (halfBalance > betOnQueenSpades && totalBetValue < halfBalance)
                    {
                        QueenSpadeSpawner();
                    }

                }
                if (betOnQueenDiamonds > 0)
                {
                    if (halfBalance > betOnQueenDiamonds && totalBetValue < halfBalance)
                    {
                        QueenDiamondSpawner();
                    }

                }
                if (betOnQueenClubs > 0)
                {
                    if (halfBalance > betOnQueenClubs && totalBetValue < halfBalance)
                    {
                        QueenClubSpawner();
                    }

                }
                if (betOnKingHearts > 0)
                {
                    if (halfBalance > betOnKingHearts && totalBetValue < halfBalance)
                    {
                        KingHeartSpawner();
                    }

                }
                if (betOnKingSpades > 0)
                {
                    if (halfBalance > betOnKingSpades && totalBetValue < halfBalance)
                    {
                        KingSpadeSpawner();
                    }

                }
                if (betOnKingDiamonds > 0)
                {
                    if (halfBalance > betOnKingDiamonds && totalBetValue < halfBalance)
                    {
                        KingDiamondSpawner();
                    }

                }
                if (betOnKingClubs > 0)
                {
                    if (halfBalance > betOnKingClubs && totalBetValue < halfBalance)
                    {
                        KingClubSpawner();
                    }

                }
                if (totalBalance > halfBalance)
                {
                    totalBalance -= totalBetValue;
                }
            }


            //totalBetText.text = totalBetValue.ToString();
            balanceTexts.text = "Balance :" + totalBalance.ToString();

            // Debug.Log("pressed Doubleup button");
        }

    }

    //This code repeats the previously placed bet amount
    //The placed bet amount is deducted from the balance amount
    public void RepeatButton()
    {
        if (currentTime > deadLineTime)
        {



            if (repeatBool == true)
            {
                ReBetOption();
                totalBalance = totalBalance - value;
                if (betOnJackHearts > 0)
                {


                    jackHeartsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(jackHeartChip);
                    jackHeartChip = Instantiate(chip, jackHeartsCard.transform.position, jackHeartsCard.transform.rotation);
                    jackHeartChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackHeartsCards").transform, false);
                    jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();




                    if (betOnJackHearts >= chip5Value && betOnJackHearts < chip10Value)
                    {
                        // Destroy(newchip);
                        jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();


                    }
                    else if (betOnJackHearts >= chip10Value && betOnJackHearts < chip50Value)
                    {
                        //Destroy(newchip);
                        jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();
                    }
                    else if (betOnJackHearts >= chip50Value && betOnJackHearts < chip100Value)
                    {
                        //Destroy(newchip);
                        jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString(); ;
                    }
                    else if (betOnJackHearts >= chip100Value && betOnJackHearts < chip500Value)
                    {
                        // Destroy (newchip);
                        jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();
                    }
                    else if (betOnJackHearts >= chip500Value)
                    {
                        // Destroy(newchip);
                        jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();
                    }



                }
                if (betOnJackSpades > 0)
                {
                    jackSpadesCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(jackSpadeChip);
                    jackSpadeChip = Instantiate(chip, jackSpadesCard.transform.position, jackSpadesCard.transform.rotation);
                    jackSpadeChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackSpadesCards").transform, false);
                    jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();

                    if (betOnJackSpades >= chip5Value && betOnJackSpades < chip10Value)
                    {
                        jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
                    }
                    else if (betOnJackSpades >= chip10Value && betOnJackSpades < chip50Value)
                    {
                        jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
                    }
                    else if (betOnJackSpades >= chip50Value && betOnJackSpades < chip100Value)
                    {
                        jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
                    }
                    else if (betOnJackSpades >= chip100Value && betOnJackSpades < chip500Value)
                    {
                        jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
                    }
                    else if (betOnJackSpades >= chip500Value)
                    {
                        jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
                    };


                }
                if (betOnJackDiamonds > 0)
                {
                    jackDiamondsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(jackSDiamondChip);
                    jackSDiamondChip = Instantiate(chip, jackDiamondsCard.transform.position, jackDiamondsCard.transform.rotation);
                    jackSDiamondChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackDiamondsCards").transform, false);
                    jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();

                    if (betOnJackDiamonds >= chip5Value && betOnJackDiamonds < chip10Value)
                    {
                        jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
                    }
                    else if (betOnJackDiamonds >= chip10Value && betOnJackDiamonds < chip50Value)
                    {
                        jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
                    }
                    else if (betOnJackDiamonds >= chip50Value && betOnJackDiamonds < chip100Value)
                    {
                        jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
                    }
                    else if (betOnJackDiamonds >= chip100Value && betOnJackDiamonds < chip500Value)
                    {
                        jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
                    }
                    else if (betOnJackDiamonds >= chip500Value)
                    {
                        jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
                    }


                }
                if (betOnJackClubs > 0)
                {
                    jackClubsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(jackClubChip);
                    jackClubChip = Instantiate(chip, jackClubsCard.transform.position, jackClubsCard.transform.rotation);
                    jackClubChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackClubsCards").transform, false);
                    jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();

                    if (betOnJackClubs >= chip5Value && betOnJackClubs < chip10Value)
                    {
                        jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
                    }
                    else if (betOnJackClubs >= chip10Value && betOnJackClubs < chip50Value)
                    {
                        jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
                    }
                    else if (betOnJackClubs >= chip50Value && betOnJackClubs < chip100Value)
                    {
                        jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
                    }
                    else if (betOnJackClubs >= chip100Value && betOnJackClubs < chip500Value)
                    {
                        jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
                    }
                    else if (betOnJackClubs >= chip500Value)
                    {
                        jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
                    }


                }
                if (betOnQueenHearts > 0)
                {
                    queenHeartsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(queenHeartChip);
                    queenHeartChip = Instantiate(chip, queenHeartsCard.transform.position, queenHeartsCard.transform.rotation);
                    queenHeartChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenHeartsCards").transform, false);
                    queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();

                    if (betOnQueenHearts >= chip5Value && betOnQueenHearts < chip10Value)
                    {
                        queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
                    }
                    else if (betOnQueenHearts >= chip10Value && betOnQueenHearts < chip50Value)
                    {
                        queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
                    }
                    else if (betOnQueenHearts >= chip50Value && betOnQueenHearts < chip100Value)
                    {
                        queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
                    }
                    else if (betOnQueenHearts >= chip100Value && betOnQueenHearts < chip500Value)
                    {
                        queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
                    }
                    else if (betOnQueenHearts >= chip500Value)
                    {
                        queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
                    }


                }
                if (betOnQueenSpades > 0)
                {
                    queenSpadesCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(queenSpadeChip);
                    queenSpadeChip = Instantiate(chip, queenSpadesCard.transform.position, queenSpadesCard.transform.rotation);
                    queenSpadeChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenSpadesCards").transform, false);
                    queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();

                    if (betOnQueenSpades >= chip5Value && betOnQueenSpades < chip10Value)
                    {
                        queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
                    }
                    else if (betOnQueenSpades >= chip10Value && betOnQueenSpades < chip50Value)
                    {
                        queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
                    }
                    else if (betOnQueenSpades >= chip50Value && betOnQueenSpades < chip100Value)
                    {
                        queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
                    }
                    else if (betOnQueenSpades >= chip100Value && betOnQueenSpades < chip500Value)
                    {
                        queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
                    }
                    else if (betOnQueenSpades >= chip500Value)
                    {
                        queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
                    }


                }
                if (betOnQueenDiamonds > 0)
                {
                    queenDiamondsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(queenDiamondChip);
                    queenDiamondChip = Instantiate(chip, queenDiamondsCard.transform.position, queenDiamondsCard.transform.rotation);
                    queenDiamondChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenDiamondsCards").transform, false);
                    queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();

                    if (betOnQueenDiamonds >= chip5Value && betOnQueenDiamonds < chip10Value)
                    {
                        queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
                    }
                    else if (betOnQueenDiamonds >= chip10Value && betOnQueenDiamonds < chip50Value)
                    {
                        queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
                    }
                    else if (betOnQueenDiamonds >= chip50Value && betOnQueenDiamonds < chip100Value)
                    {
                        queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
                    }
                    else if (betOnQueenDiamonds >= chip100Value && betOnQueenDiamonds < chip500Value)
                    {
                        queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
                    }
                    else if (betOnQueenDiamonds >= chip500Value)
                    {
                        queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
                    }


                }
                if (betOnQueenClubs > 0)
                {
                    queenClubsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(queenClubChip);
                    queenClubChip = Instantiate(chip, queenClubsCard.transform.position, queenClubsCard.transform.rotation);
                    queenClubChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenClubsCards").transform, false);
                    queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();

                    if (betOnQueenClubs >= chip5Value && betOnQueenClubs < chip10Value)
                    {
                        queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
                    }
                    else if (betOnQueenClubs >= chip10Value && betOnQueenClubs < chip50Value)
                    {
                        queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
                    }
                    else if (betOnQueenClubs >= chip50Value && betOnQueenClubs < chip100Value)
                    {
                        queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
                    }
                    else if (betOnQueenClubs >= chip100Value && betOnQueenClubs < chip500Value)
                    {
                        queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
                    }
                    else if (betOnQueenClubs >= chip500Value)
                    {
                        queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
                    }


                }
                if (betOnKingHearts > 0)
                {
                    kingHeartsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(kingHeartChip);
                    kingHeartChip = Instantiate(chip, kingHeartsCard.transform.position, kingHeartsCard.transform.rotation);
                    kingHeartChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingsHeartsCards").transform, false);
                    kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();

                    if (betOnKingHearts >= chip5Value && betOnKingHearts < chip10Value)
                    {
                        kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
                    }
                    else if (betOnKingHearts >= chip10Value && betOnKingHearts < chip50Value)
                    {
                        kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
                    }
                    else if (betOnKingHearts >= chip50Value && betOnKingHearts < chip100Value)
                    {
                        kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
                    }
                    else if (betOnKingHearts >= chip100Value && betOnKingHearts < chip500Value)
                    {
                        kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
                    }
                    else if (betOnKingHearts >= chip500Value)
                    {
                        kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
                    }


                }
                if (betOnKingSpades > 0)
                {
                    kingSpadesCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(kingSpadeChip);
                    kingSpadeChip = Instantiate(chip, kingSpadesCard.transform.position, kingSpadesCard.transform.rotation);
                    kingSpadeChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingSpadescards").transform, false);
                    kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();

                    if (betOnKingSpades >= chip5Value && betOnKingSpades < chip10Value)
                    {
                        kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
                    }
                    else if (betOnKingSpades >= chip10Value && betOnKingSpades < chip50Value)
                    {
                        kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
                    }
                    else if (betOnKingSpades >= chip50Value && betOnKingSpades < chip100Value)
                    {
                        kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
                    }
                    else if (betOnKingSpades >= chip100Value && betOnKingSpades < chip500Value)
                    {
                        kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
                    }
                    else if (betOnKingSpades >= chip500Value)
                    {
                        kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
                    }


                }
                if (betOnKingDiamonds > 0)
                {
                    kingDiamondsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(kingDiamondChip);
                    kingDiamondChip = Instantiate(chip, kingDiamondsCard.transform.position, kingDiamondsCard.transform.rotation);
                    kingDiamondChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingDiamondsCards").transform, false);
                    kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();

                    if (betOnKingDiamonds >= chip5Value && betOnKingDiamonds < chip10Value)
                    {
                        kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
                    }
                    else if (betOnKingDiamonds >= chip10Value && betOnKingDiamonds < chip50Value)
                    {
                        kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
                    }
                    else if (betOnKingDiamonds >= chip50Value && betOnKingDiamonds < chip100Value)
                    {
                        kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
                    }
                    else if (betOnKingDiamonds >= chip100Value && betOnKingDiamonds < chip500Value)
                    {
                        kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
                    }
                    else if (betOnKingDiamonds >= chip500Value)
                    {
                        kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
                    }


                }
                if (betOnKingClubs > 0)
                {
                    kingClubsCard.GetComponent<SpriteRenderer>().color = Color.red;
                    Destroy(kingClubChip);
                    kingClubChip = Instantiate(chip, kingClubsCard.transform.position, kingClubsCard.transform.rotation);
                    kingClubChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingClubsCards").transform, false);
                    kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();

                    if (betOnKingClubs >= chip5Value && betOnKingClubs < chip10Value)
                    {
                        kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                        kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
                    }
                    else if (betOnKingClubs >= chip10Value && betOnKingClubs < chip50Value)
                    {
                        kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                        kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
                    }
                    else if (betOnKingClubs >= chip50Value && betOnKingClubs < chip100Value)
                    {
                        kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                        kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
                    }
                    else if (betOnKingClubs >= chip100Value && betOnKingClubs < chip500Value)
                    {
                        kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                        kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
                    }
                    else if (betOnKingClubs >= chip500Value)
                    {
                        kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                        kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
                    }


                }

                balanceTexts.text = "Balance :" + totalBalance.ToString();
            }



        }
        repeatBool = false;

    }

    //This code clears the amount of placed bets
    //The cleared amount is returned to the balance amount
    public void ClearButton()
    {
        if (currentTime > deadLineTime)
        {
            totalBalance += totalBetValue;
            value = 0;
            repeatBool = true;
            //  tempBet = 0;
            ResetChipValues();
            // ResetTotalValueOnEveryCards();
            SetAllFlase();
            // totalBetText.text =   totalBetValue.ToString();
            balanceTexts.text = "Balance :" + totalBalance.ToString();
            ChangeSlotColor();
            KillingChips();
            totalBetText.text = 0.ToString();

        }



    }
    public void CloseGameButton()
    {
        ResetDatas();
        SceneManager.LoadScene(1);
    }

    public void ResetDatas()
    {
        Datas.instance.luckycardsstartGameData.status = false;
        Datas.instance.tripplechancestartGameData.status = false;
        Datas.instance.jeethoRaftherStartGameData.status = false;



    }

    public void MinimizeGameButton()
    {
        Debug.Log("Clicked on minimize button");
    }
    public void GameSoundControlButton()
    {
        Debug.Log("Clicked on sound button");
    }
    public void ChangeSlotColor()
    {
        jackHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
        jackSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
        jackDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
        jackClubsCard.GetComponent<SpriteRenderer>().color = Color.white;

        queenHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
        queenSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
        queenDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
        queenClubsCard.GetComponent<SpriteRenderer>().color = Color.white;

        kingHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
        kingSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
        kingDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
        kingClubsCard.GetComponent<SpriteRenderer>().color = Color.white;




    }

    //This is to display the amount placed as bet in the comments section
    void BetPlacedComment()
    {

        betAcceptedText.text = "bet placed     ";
        totalBetText.text = totalBetValue.ToString();
        Invoke("RemoveWarningMessages", 4f);
    }


    //Opens the settings menu
    public void SettingsMenuOpen()
    {

        settingsPanel.SetActive(true);
        Debug.Log("pressed settings");

    }

    //Close the settings menu
    public void SettingsMenuClose()
    {
        ReportPanelDeactivate();
        GameHistoryPanelDeactivate();
        ResultPanelDeactivate();
        UnclaimedTicketsPanelDeactivate();
        RulesPanelActivate();
        settingsPanel.SetActive(false);
    }

    //To get the value of previously placed bet

    void LastplacedBetAmount()
    {
        if (value > 0)
        {
            previousBet = totalBetValue;
        }

    }

    //To remove the text displayed for accepted bet


    //To enable and disable the buttons
    void ButtonsSwitchOn()
    {
        betButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
        doubleUpButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
        repeatButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
    }
    void ButtonsSwitchOff()
    {
        betButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
        repeatButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
        doubleUpButton.GetComponent<UnityEngine.UI.Button>().interactable = false;


    }
    void ChippiesOff()
    {

        for (int i = 0; i < chippies.Length; i++)
        {
            chippies[i].GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
    }
    void ChippiesOn()
    {

        for (int i = 0; i < chippies.Length; i++)
        {
            chippies[i].GetComponent<UnityEngine.UI.Button>().enabled = true;
        }
    }

    //To enable settings panel
    void SettingsFeature()
    {
        if (currentTime < deadLineTime)
        {
            value = 0;
            settingsPanel.SetActive(false);
            settingsButton.GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
        else if (currentTime > deadLineTime)
        {
            settingsButton.GetComponent<UnityEngine.UI.Button>().enabled = true;

        }
    }

    //To display the warning messages before time runs out
    void WarningMessages()
    {
        if (currentTime < warningTime && currentTime > deadLineTime)
        {
            betAcceptedText.text = "Last Chance To Place Bet";
            Invoke("NoMoreBetsMessage", 5f);
        }
    }
    void NoMoreBetsMessage()
    {
        if (currentTime < deadLineTime)
        {
            betAcceptedText.text = "No more Bets";
            Invoke("RemoveWarningMessages", 11f);
        }
    }

    //To remove the warning messages
    void RemoveWarningMessages()
    {
        betAcceptedText.text = string.Empty;
        // totalBetText.text = "0";
    }

    //To select all the cards with J's
    public void SelectAllJs()
    {
        if (LuckyCards_Timer.Instance.timeLeft > deadLineTime)
        {
            if (totalBalance > chipStorage * 4)
            {
                JackHearts();
                JackSpades();
                JackDiamonds();
                JackClubs();
                betOnAllJacks = betOnJackHearts + betOnJackSpades + betOnJackDiamonds + betOnJackClubs;
                // betOfAllTemp1 = betOnAllQueens + betOnAllJacks + betOnAllKings;
                totalBetValue += betOnAllJacks;
                totalBetText.text = totalBetValue.ToString();
                // Debug.Log("Seleced all cards with J");
            }
        }

    }

    public void SelectAllCards(int coloumnnumber)
    {
        foreach (LuckyCards_Cards card in cards)
        {
            if (card.rowNumber == coloumnnumber)
            {
                switch (coloumnnumber)
                {
                    case 0:
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnJackSpades += chipStorage;
                                totalBalance -= chipStorage;
                                JackSpadeSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnJackSpades > 0)
                            {
                                jackOfSpades = true;
                            }
                            // Debug.Log("Clicked on Jack of Spade");
                        }

                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnJackDiamonds += chipStorage;
                                totalBalance -= chipStorage;
                                JackDiamondSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnJackDiamonds > 0)
                            {
                                jackOfDiamonds = true;
                            }
                            // Debug.Log("Clicked on Jack of Diamonds");
                        }
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnJackClubs += chipStorage;
                                totalBalance -= chipStorage;
                                JackClubSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnJackClubs > 0)
                            {
                                jackOfClubs = true;
                            }
                            // Debug.Log("Clicked on Jack of Clubs");
                        }

                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnJackHearts += chipStorage;
                                totalBalance -= chipStorage;

                                JackHeartsSpawner();

                            }
                            AssigningTotalBetvalues();

                            if (betOnJackHearts > 0)
                            {
                                jackOfHearts = true;
                            }
                            // Debug.Log("Clicked on Jack of Hearts");
                        }


                        break;
                    case 1:
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnQueenHearts += chipStorage;
                                totalBalance -= chipStorage;
                                QueenHeartSpawner();
                            }

                            AssigningTotalBetvalues();


                            if (betOnQueenHearts > 0)
                            {
                                queenOfHearts = true;
                            }
                            // Debug.Log("Clicked on Queen of Hearts");
                        }
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnQueenSpades += chipStorage;
                                totalBalance -= chipStorage;
                                QueenSpadeSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnQueenSpades > 0)
                            {
                                queenOfSpades = true;
                            }
                            // Debug.Log("Clicked on Queen of Spades");
                        }
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnQueenDiamonds += chipStorage;
                                totalBalance -= chipStorage;
                                QueenDiamondSpawner();
                            }
                            AssigningTotalBetvalues();


                            if (betOnQueenDiamonds > 0)
                            {
                                queenOfDiamonds = true;
                            }
                            // Debug.Log("Clicked on Queen of Diamonds");
                        }
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnQueenClubs += chipStorage;
                                totalBalance -= chipStorage;
                                QueenClubSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnQueenClubs > 0)
                            {
                                queenOfClubs = true;
                            }
                            // Debug.Log("Clicked on Queen of Clubs");
                        }





                        break;
                    case 2:


                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnKingHearts += chipStorage;
                                totalBalance -= chipStorage;
                                KingHeartSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnKingHearts > 0)
                            {
                                kingOfHearts = true;
                            }
                            //Debug.Log("Clicked on King of Hearts");
                        }
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnKingSpades += chipStorage;
                                totalBalance -= chipStorage;
                                KingSpadeSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnKingSpades > 0)
                            {
                                kingOfSpades = true;
                            }
                            //Debug.Log("Clicked on King of Spades");
                        }
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnKingDiamonds += chipStorage;
                                totalBalance -= chipStorage;
                                KingDiamondSpawner();
                            }
                            AssigningTotalBetvalues();


                            if (betOnKingDiamonds > 0)
                            {
                                kingOfDiamonds = true;
                            }
                            // Debug.Log("Clicked on King of Diamonds");
                        }
                        if (currentTime > deadLineTime)
                        {
                            if (totalBalance >= chipStorage)
                            {


                                betOnKingClubs += chipStorage;
                                totalBalance -= chipStorage;
                                KingClubSpawner();

                            }
                            AssigningTotalBetvalues();


                            if (betOnKingClubs > 0)
                            {
                                kingOfClubs = true;
                            }
                            // Debug.Log("Clicked on King of Clubs");
                        }


                        break;
                }


            }
            else if (card.rowNumber == 0)
            {

            }
            else if (card.rowNumber == 1)
            {

            }
            card.isSelected = !card.isSelected;
        }
    }
    //To select all the cards with K's
    public void SelectAllK()
    {
        if (LuckyCards_Timer.Instance.timeLeft > deadLineTime)
        {
            if (totalBalance > chipStorage * 4)
            {



                KingHearts();
                KingSpades();
                KingDiamonds();
                KingClubs();
                betOnAllKings = betOnKingHearts + betOnKingSpades + betOnKingDiamonds + betOnKingClubs;
                totalBetValue += betOnAllKings;
                totalBetText.text = totalBetValue.ToString();
                // betOfAllTemp1 = betOnAllQueens + betOnAllJacks + betOnAllKings;
                // Debug.Log("Seleced all cards with K");
            }
        }
    }

    //To select all the cards with Q's
    public void SelectAllQ()
    {

        if (LuckyCards_Timer.Instance.timeLeft > deadLineTime)
        {
            if (totalBalance > chipStorage * 4)
            {



                QueenHearts();
                QueenSpades();
                QueenDiamonds();
                QueenClubs();
                betOnAllQueens = betOnQueenHearts + betOnQueenSpades + betOnQueenDiamonds + betOnQueenClubs;
                totalBetValue += betOnAllQueens;
                totalBetText.text = totalBetValue.ToString();
                // betOfAllTemp1 = betOnAllQueens + betOnAllJacks + betOnAllKings;
                //  Debug.Log("Seleced all cards with Q");
            }
        }
    }

    //To select all the cards with Hearts
    public void SelectAllHearts()
    {
        if (LuckyCards_Timer.Instance.timeLeft > deadLineTime)
        {
            if (totalBalance > chipStorage * 3)
            {



                JackHearts();
                QueenHearts();
                KingHearts();
                betOnAllHearts += betOnJackHearts + betOnQueenHearts + betOnKingHearts;
                totalBetValue += betOnAllHearts;
                totalBetText.text = totalBetValue.ToString();
                //betOfAllTemp = betOnAllHearts + betOnAllSpades + betOnAllDiamonds + betOnAllClubs;

                //  Debug.Log("Selected all cards with Hearts");    
            }
        }
    }

    //To select all the cards with Spades
    public void SelectAllSpades()
    {
        if (LuckyCards_Timer.Instance.timeLeft > deadLineTime)
        {
            if (totalBalance > chipStorage * 3)
            {
                JackSpades();
                QueenSpades();
                KingSpades();
                betOnAllSpades += betOnJackSpades + betOnQueenSpades + betOnKingSpades;
                totalBetValue += betOnAllSpades;
                totalBetText.text = totalBetValue.ToString();
                //betOfAllTemp = betOnAllHearts + betOnAllSpades + betOnAllDiamonds + betOnAllClubs; 

                //  Debug.Log("Selected all cards with Spades");
            }
        }
    }


    public void SetHistoryFromBackend()
    {
        historySlots[0].sprite = cardSprites[System.Int32.Parse(Datas.instance.luckycardsstartGameData.jeetojokerhistory[0])];
        historySlots[1].sprite = cardSprites[System.Int32.Parse(Datas.instance.luckycardsstartGameData.jeetojokerhistory[1])];

        historySlots[2].sprite = cardSprites[System.Int32.Parse(Datas.instance.luckycardsstartGameData.jeetojokerhistory[2])];

        historySlots[3].sprite = cardSprites[System.Int32.Parse(Datas.instance.luckycardsstartGameData.jeetojokerhistory[3])];

        historySlots[4].sprite = cardSprites[System.Int32.Parse(Datas.instance.luckycardsstartGameData.jeetojokerhistory[4])];

        historySlots[5].sprite = cardSprites[System.Int32.Parse(Datas.instance.luckycardsstartGameData.jeetojokerhistory[5])];

    }
    public void DecideWinner(int randomNumber)
    {
        switch (randomNumber)
        {
            case 0:
                winnerCard = cards[0];
                winnerSprite = cardSprites[0];
                Debug.Log("Winner Card is " + cards[0].cardName);
                break;
            case 1:
                winnerCard = cards[1];
                winnerSprite = cardSprites[1];
                Debug.Log("Winner Card is " + cards[1].cardName);
                break;
            case 2:
                winnerCard = cards[2];
                winnerSprite = cardSprites[2];
                Debug.Log("Winner Card is " + cards[2].cardName);
                break;
            case 3:
                winnerCard = cards[3];
                winnerSprite = cardSprites[3];
                Debug.Log("Winner Card is " + cards[3].cardName);
                break;
            case 4:
                winnerCard = cards[4];
                winnerSprite = cardSprites[4];
                Debug.Log("Winner Card is " + cards[4].cardName);
                break;
            case 5:
                winnerCard = cards[5];
                winnerSprite = cardSprites[5];
                Debug.Log("Winner Card is " + cards[5].cardName);
                break;
            case 6:
                winnerCard = cards[6];
                winnerSprite = cardSprites[6];
                Debug.Log("Winner Card is " + cards[6].cardName);
                break;
            case 7:
                winnerCard = cards[7];
                winnerSprite = cardSprites[7];
                Debug.Log("Winner Card is " + cards[7].cardName);
                break;
            case 8:
                winnerCard = cards[8];
                winnerSprite = cardSprites[8];
                Debug.Log("Winner Card is " + cards[8].cardName);
                break;
            case 9:
                winnerCard = cards[9];
                winnerSprite = cardSprites[9];
                Debug.Log("Winner Card is " + cards[9].cardName);
                break;
            case 10:
                winnerCard = cards[10];
                winnerSprite = cardSprites[10];
                Debug.Log("Winner Card is " + cards[10].cardName);
                break;
            case 11:
                winnerCard = cards[11];
                winnerSprite = cardSprites[11];
                Debug.Log("Winner Card is " + cards[11].cardName);
                break;

        }
        TurnOffAllBonusDisplay();

        //bonusDisplayer[].SetActive(true);//
        //  WinnerBonusDisplay();
        WinnerDisplay();
        WinnerSpriteDisplay(winnerSprite);
    }

    public void TurnOffAllBonusDisplay()
    {
        foreach (GameObject go in bonusDisplayer)
        {
            go.SetActive(false);
        }
    }
    //To select all the cards with Diamonds
    public void SelectAllDiamonds()
    {
        if (LuckyCards_Timer.Instance.timeLeft > deadLineTime)
        {
            if (totalBalance > chipStorage * 3)
            {



                JackDiamonds();
                QueenDiamonds();
                KingDiamonds();
                betOnAllDiamonds += betOnJackDiamonds + betOnQueenDiamonds + betOnKingDiamonds;
                totalBetValue += betOnAllDiamonds;
                totalBetText.text = totalBetValue.ToString();
                //betOfAllTemp = betOnAllHearts + betOnAllSpades + betOnAllDiamonds + betOnAllClubs;

                // Debug.Log("Selected all cards with Diamonds");
            }
        }
    }

    //To select all the cards with Clubs
    public void SelectAllClubs()
    {
        if (LuckyCards_Timer.Instance.timeLeft > deadLineTime)
        {
            if (totalBalance > chipStorage * 3)
            {


                JackClubs();
                QueenClubs();
                KingClubs();
                betOnAllClubs += betOnJackClubs + betOnQueenClubs + betOnKingClubs;
                totalBetValue += betOnAllClubs;
                totalBetText.text = totalBetValue.ToString();
                //betOfAllTemp = betOnAllHearts + betOnAllSpades + betOnAllDiamonds + betOnAllClubs;

                //Debug.Log("Selected all cards with Clubs");
            }
        }
    }

    //This function is used to pic a random card from all the cards available
    //The winner is picked via this function


    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 
    public void SelectWinner()
    {
        randomSymbol = 0;
        randomNumber = 0;
        if (!gameStarted)
        {
            foreach (LuckyCards_SpinManager spin in spinManagers)
            {
                spin.spinWheel = true;

                if (spin.wheelType == LuckyCards_SpinManager.WheelType.SecondWheel)
                {
                    //1.073
                    spin.transform.rotation = Quaternion.Euler(0, 0, 0f);
                }
                else
                {
                    spin.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            gameStarted = true;
        }
        else
        {
            foreach (LuckyCards_SpinManager spin in spinManagers)
            {
                spin.spinWheel = true;

                if (spin.wheelType == LuckyCards_SpinManager.WheelType.SecondWheel)
                {
                    //1.073
                    spin.transform.rotation = Quaternion.Euler(0, 0, -28.71f);
                }
                else
                {
                    spin.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        foreach (LuckyCards_SpinManager spin in spinManagers)
        {
            spin.spinWheel = true;


            switch (System.Int32.Parse(Datas.instance.luckyCardsDrawBetDatas.win_number))
            {
                case 0:


                    spinManagers[1].AngularDrag = dragValuesSymbol[0];
                    spinManagers[0].AngularDrag = dragValueNumber[0];
                    Debug.Log(" Case 1 is " + spinManagers[1].AngularDrag);
                    break;
                case 1:


                    spinManagers[1].AngularDrag = dragValuesSymbol[1];
                    spinManagers[0].AngularDrag = dragValueNumber[1];
                    Debug.Log(" Case 2 is " + spinManagers[1].AngularDrag);
                    break;
                case 2:


                    spinManagers[1].AngularDrag = dragValuesSymbol[2];
                    spinManagers[0].AngularDrag = dragValueNumber[2];
                    Debug.Log(" Case 3 is " + spinManagers[1].AngularDrag);
                    break;
                case 3:

                    spinManagers[1].AngularDrag = dragValuesSymbol[3];
                    spinManagers[0].AngularDrag = dragValueNumber[3];
                    Debug.Log(" Case 4 is " + spinManagers[1].AngularDrag);
                    break;



                case 4:

                    spinManagers[1].AngularDrag = dragValuesSymbol[0];
                    spinManagers[0].AngularDrag = dragValueNumber[4];
                    Debug.Log(" Case 5 is " + spinManagers[1].AngularDrag);
                    break;

                case 5:


                    spinManagers[1].AngularDrag = dragValuesSymbol[1];
                    spinManagers[0].AngularDrag = dragValueNumber[5];
                    Debug.Log(" Case 6 is " + spinManagers[1].AngularDrag);
                    break;

                case 6:


                    spinManagers[1].AngularDrag = dragValuesSymbol[2];
                    spinManagers[0].AngularDrag = dragValueNumber[6];
                    Debug.Log(" Case 7 is " + spinManagers[1].AngularDrag);
                    break;

                case 7:

                    spinManagers[1].AngularDrag = dragValuesSymbol[3];
                    spinManagers[0].AngularDrag = dragValueNumber[7];
                    Debug.Log(" Case 8 is " + spinManagers[1].AngularDrag);
                    break;

                case 8:


                    spinManagers[1].AngularDrag = dragValuesSymbol[0];
                    spinManagers[0].AngularDrag = dragValueNumber[8];
                    Debug.Log(" Case 9 is " + spinManagers[1].AngularDrag);
                    break;

                case 9:


                    spinManagers[1].AngularDrag = dragValuesSymbol[1];
                    spinManagers[0].AngularDrag = dragValueNumber[9];
                    Debug.Log(" Case 10  is " + spinManagers[1].AngularDrag);
                    break;

                case 10:

                    spinManagers[1].AngularDrag = dragValuesSymbol[2];
                    spinManagers[0].AngularDrag = dragValueNumber[10];
                    Debug.Log(" Case 11 is " + spinManagers[1].AngularDrag);
                    break;
                case 11:


                    spinManagers[1].AngularDrag = dragValuesSymbol[3];
                    spinManagers[0].AngularDrag = dragValueNumber[11];
                    Debug.Log(" Case 12 is " + spinManagers[1].AngularDrag);
                    break;
            }
        }
        showingwinnerPanel = true;
        Invoke("ReturnTheAmountOfWin", 16f);
        Invoke("WinnerDisplay", 16f);
    }
    public void WinnerSelection()
    {
        if (!gameStarted)
        {
            /* cardIndex = UnityEngine.Random.Range(0, cards.Length);
             RandomWinner = cardIndex;*/
            //cardIndex = 0;

            randomSymbol = 0;
            randomNumber = 0;
            Debug.Log(winnerNumber);
            foreach (LuckyCards_SpinManager spin in spinManagers)
            {



                spin.spinWheel = true;
                if (spin.wheelType == LuckyCards_SpinManager.WheelType.SecondWheel)
                {
                    /* if (RandomWinner != 11)
                     {
                         winnerNumber = RandomWinner + 1;
                     }
                     else
                     {
                         winnerNumber = 0;
                     }*/
                    //1.073
                    spin.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    /* if (RandomWinner != 0)
                     {
                         winnerNumber = RandomWinner - 1;
                     }
                     else
                     {
                         winnerNumber = 11;
                     }*/
                    spin.transform.rotation = Quaternion.Euler(0, 0, 0);//-28.79f
                }


            }

            Debug.Log(winner);



            if (winner == cards[0].cardType)
            {

                spinWheel.Play("Jack");
                innerWheel.Play("Heart");
                cardName = "Jack Heart";
                card = LuckyCard_CardType.JackHearts;
                winnerSprite = cardSprites[0];


            }
            if (winner == cards[1].cardType)
            {
                spinWheel.Play("Jack");
                innerWheel.Play("Spade");
                cardName = "Jack Spade";
                card = LuckyCard_CardType.JackSpades;
                winnerSprite = cardSprites[1];

            }
            if (winner == cards[2].cardType)
            {
                spinWheel.Play("Jack");
                innerWheel.Play("Diamond");
                cardName = "Jack Diamond";
                card = LuckyCard_CardType.JackDiamonds;
                winnerSprite = cardSprites[2];

            }
            if (winner == cards[3].cardType)
            {
                spinWheel.Play("Jack");
                innerWheel.Play("Club");
                cardName = "Jack Club";
                card = LuckyCard_CardType.JackClubs;
                winnerSprite = cardSprites[3];

            }
            if (winner == cards[4].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Heart");
                cardName = "Queen Heart";
                card = LuckyCard_CardType.QueenHearts;
                winnerSprite = cardSprites[4];

            }
            if (winner == cards[5].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Spade");
                cardName = "Queen Spade";
                card = LuckyCard_CardType.QueenSpades;
                winnerSprite = cardSprites[5];

            }
            if (winner == cards[6].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Diamond");
                cardName = "Queen Diamonds";
                card = LuckyCard_CardType.QueenDiamonds;
                winnerSprite = cardSprites[6];

            }
            if (winner == cards[7].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Club");
                cardName = "Queen Club";
                card = LuckyCard_CardType.QueenClubs;
                winnerSprite = cardSprites[7];

            }
            if (winner == cards[8].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Heart");
                cardName = "King Heart";
                card = LuckyCard_CardType.KingHearts;
                winnerSprite = cardSprites[8];

            }
            if (winner == cards[9].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Spade");
                cardName = "King Spades";
                card = LuckyCard_CardType.KingSpades;
                winnerSprite = cardSprites[9];

            }
            if (winner == cards[10].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Diamond");
                cardName = "King Diamonds";
                card = LuckyCard_CardType.KingDiamonds;
                winnerSprite = cardSprites[10];

            }
            if (winner == cards[11].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Club");
                cardName = "King Clubs";
                card = LuckyCard_CardType.KingClubs;
                winnerSprite = cardSprites[11];

            }
            showingwinnerPanel = true;
            Invoke("ReturnTheAmountOfWin", 16f);
            Invoke("WinnerDisplay", 16f);
            gameStarted = true;
        }
        else
        {
            showingwinnerPanel = true;

            /* cardIndex = UnityEngine.Random.Range(0, cards.Length);
             RandomWinner = cardIndex;*/
            //cardIndex = 0;
            // winnerNumber = RandomWinner;
            Debug.Log(winnerNumber);
            foreach (LuckyCards_SpinManager spin in spinManagers)
            {
                spin.spinWheel = true;
                if (spin.wheelType == LuckyCards_SpinManager.WheelType.SecondWheel)
                {
                    //1.073
                    spin.transform.rotation = Quaternion.Euler(0, 0, -28.79f);
                }
                else
                {
                    spin.transform.rotation = Quaternion.Euler(0, 0, 0);
                }


            }

            // winner = cards[RandomWinner].cardType;
            Debug.Log(winner);



            if (winner == cards[0].cardType)
            {

                spinWheel.Play("Jack");
                innerWheel.Play("Heart");
                cardName = "Jack Heart";
                card = LuckyCard_CardType.JackHearts;
                winnerSprite = cardSprites[0];


            }
            if (winner == cards[1].cardType)
            {
                spinWheel.Play("Jack");
                innerWheel.Play("Spade");
                cardName = "Jack Spade";
                card = LuckyCard_CardType.JackSpades;
                winnerSprite = cardSprites[1];

            }
            if (winner == cards[2].cardType)
            {
                spinWheel.Play("Jack");
                innerWheel.Play("Diamond");
                cardName = "Jack Diamond";
                card = LuckyCard_CardType.JackDiamonds;
                winnerSprite = cardSprites[2];

            }
            if (winner == cards[3].cardType)
            {
                spinWheel.Play("Jack");
                innerWheel.Play("Club");
                cardName = "Jack Club";
                card = LuckyCard_CardType.JackClubs;
                winnerSprite = cardSprites[3];

            }
            if (winner == cards[4].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Heart");
                cardName = "Queen Heart";
                card = LuckyCard_CardType.QueenHearts;
                winnerSprite = cardSprites[4];

            }
            if (winner == cards[5].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Spade");
                cardName = "Queen Spade";
                card = LuckyCard_CardType.QueenSpades;
                winnerSprite = cardSprites[5];

            }
            if (winner == cards[6].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Diamond");
                cardName = "Queen Diamonds";
                card = LuckyCard_CardType.QueenDiamonds;
                winnerSprite = cardSprites[6];

            }
            if (winner == cards[7].cardType)
            {
                spinWheel.Play("Queen");
                innerWheel.Play("Club");
                cardName = "Queen Club";
                card = LuckyCard_CardType.QueenClubs;
                winnerSprite = cardSprites[7];

            }
            if (winner == cards[8].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Heart");
                cardName = "King Heart";
                card = LuckyCard_CardType.KingHearts;
                winnerSprite = cardSprites[8];

            }
            if (winner == cards[9].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Spade");
                cardName = "King Spades";
                card = LuckyCard_CardType.KingSpades;
                winnerSprite = cardSprites[9];

            }
            if (winner == cards[10].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Diamond");
                cardName = "King Diamonds";
                card = LuckyCard_CardType.KingDiamonds;
                winnerSprite = cardSprites[10];

            }
            if (winner == cards[11].cardType)
            {
                spinWheel.Play("King");
                innerWheel.Play("Club");
                cardName = "King Clubs";
                card = LuckyCard_CardType.KingClubs;
                winnerSprite = cardSprites[11];

            }
            Invoke("ReturnTheAmountOfWin", 16f);
            Invoke("WinnerDisplay", 16f);



        }


    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    void KillBonusDisplay()
    {
        bonusDisplayer[0].SetActive(false);
        bonusDisplayer[1].SetActive(false);
        bonusDisplayer[2].SetActive(false);
        bonusDisplayer[3].SetActive(false);
        bonusDisplayer[4].SetActive(false);
        bonusDisplayer[5].SetActive(false);
        bonusDisplayer[6].SetActive(false);
        bonusDisplayer[7].SetActive(false);
        bonusDisplayer[8].SetActive(false);
        bonusDisplayer[9].SetActive(false);
        bonusDisplayer[10].SetActive(false);
        bonusDisplayer[11].SetActive(false);
    }
    void WinnerBonusDisplay()
    {
        if (winner == cards[0].cardType)
        {
            bonusDisplayer[0].SetActive(true);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);

        }
        if (winner == cards[1].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(true);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[2].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(true);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[3].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(true);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[4].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(true);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[5].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(true);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[6].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(true);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[7].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(true);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[8].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(true);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[9].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(true);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[10].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(true);
            bonusDisplayer[11].SetActive(false);
        }
        if (winner == cards[11].cardType)
        {

            bonusDisplayer[0].SetActive(false);
            bonusDisplayer[1].SetActive(false);
            bonusDisplayer[2].SetActive(false);
            bonusDisplayer[3].SetActive(false);
            bonusDisplayer[4].SetActive(false);
            bonusDisplayer[5].SetActive(false);
            bonusDisplayer[6].SetActive(false);
            bonusDisplayer[7].SetActive(false);
            bonusDisplayer[8].SetActive(false);
            bonusDisplayer[9].SetActive(false);
            bonusDisplayer[10].SetActive(false);
            bonusDisplayer[11].SetActive(true);
        }
    }
    void WinnerDisplay()
    {
        if (winner == cards[0].cardType)
        {
            jackHeartsCard.GetComponent<SpriteRenderer>().color = Color.green;

        }
        if (winner == cards[1].cardType)
        {

            jackSpadesCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[2].cardType)
        {

            jackDiamondsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[3].cardType)
        {

            jackClubsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[4].cardType)
        {

            queenHeartsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[5].cardType)
        {

            queenSpadesCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[6].cardType)
        {

            queenDiamondsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[7].cardType)
        {

            queenClubsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[8].cardType)
        {

            kingHeartsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[9].cardType)
        {

            kingSpadesCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[10].cardType)
        {

            kingDiamondsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (winner == cards[11].cardType)
        {

            kingClubsCard.GetComponent<SpriteRenderer>().color = Color.green;
        }
        // WinnerBonusDisplay();
        totalWinAmount += winAmount;
        Invoke("ChangeSlotColor", 6f);


        //   StoringHistory();
        // claimableBalance += winAmount;
        // WinnerSpriteDisplay(winnerSprite);
        foreach (LuckyCards_SpinManager spin in spinManagers)
        {
            spin.winUpdate = false;
        }
    }
    void ActivateWinnerPanel()
    {
        winnerPanel.SetActive(true);
        winnerText.text = " You Won " + winAmount;
        Invoke("DisableWinnerPanel", 4f);
        DisplayWinText();

    }
    void DisplayWinText()
    {
        totalWinText.text = winAmount.ToString();
        Invoke("RemoveWinText", resetingTime);
    }
    void RemoveWinText()
    {
        totalWinText.text = "0";
    }

    //To disable the panel that shows the random winner
    void DisableWinnerPanel()
    {
        winnerPanel.SetActive(false);
    }

    //To enable and disable the panel which displays the rules of the game
    public void RulesPanelActivate()
    {
        rulesPanel.SetActive(true);
        ReportPanelDeactivate();
        GameHistoryPanelDeactivate();
        ResultPanelDeactivate();
        UnclaimedTicketsPanelDeactivate();
    }

    public void RulesPanelDeactivate()
    {
        rulesPanel.SetActive(false);
    }

    //To enable and disable the panel which displays the reports of the game
    public void ReportPanelActivate()
    {
        reportPanel.SetActive(true);
        RulesPanelDeactivate();
        GameHistoryPanelDeactivate();
        ResultPanelDeactivate();
        UnclaimedTicketsPanelDeactivate();
    }
    public void ReportPanelDeactivate()
    {
        reportPanel.SetActive(false);
    }

    //To enable and disable the panel which displays the result of the previous games
    public void ResultPanelActivate()
    {
        resultsPanel.SetActive(true);
        ReportPanelDeactivate();
        GameHistoryPanelDeactivate();
        RulesPanelDeactivate();
        UnclaimedTicketsPanelDeactivate();
    }
    public void ResultPanelDeactivate()
    {
        resultsPanel.SetActive(false);
    }

    //To enable and disable the panel which shows the history of the game
    public void GameHistoryPanelActivate()
    {
        gameHistoryPanel.SetActive(true);
        ReportPanelDeactivate();
        RulesPanelDeactivate();
        ResultPanelDeactivate();
        UnclaimedTicketsPanelDeactivate();
    }
    public void GameHistoryPanelDeactivate()
    {
        gameHistoryPanel.SetActive(false);
    }

    //To enable and disable the panel which shows the unclaimed tickets won in different draws of the game
    public void UnclaimedTicketsPanelActivate()
    {
        unclaimedPanel.SetActive(true);
        ReportPanelDeactivate();
        GameHistoryPanelDeactivate();
        ResultPanelDeactivate();
        RulesPanelDeactivate();
    }
    public void UnclaimedTicketsPanelDeactivate()
    {
        unclaimedPanel.SetActive(false);
    }

    //To claim the unclaimed amount from the winning draws



    //To place the bet amount to the cards
    public void JackHearts()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnJackHearts += chipStorage;
                // betTakenAmount[0] += (int)betOnJackHearts;
                totalBalance -= chipStorage;

                JackHeartsSpawner();

            }
            AssigningTotalBetvalues();

            if (betOnJackHearts > 0)
            {
                jackOfHearts = true;
            }
            // Debug.Log("Clicked on Jack of Hearts");
        }

    }
    public void JackSpades()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnJackSpades += chipStorage;
                totalBalance -= chipStorage;
                JackSpadeSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnJackSpades > 0)
            {
                jackOfSpades = true;
            }
            // Debug.Log("Clicked on Jack of Spade");
        }

    }
    public void JackDiamonds()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnJackDiamonds += chipStorage;
                totalBalance -= chipStorage;
                JackDiamondSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnJackDiamonds > 0)
            {
                jackOfDiamonds = true;
            }
            // Debug.Log("Clicked on Jack of Diamonds");
        }

    }
    public void JackClubs()

    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnJackClubs += chipStorage;
                totalBalance -= chipStorage;
                JackClubSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnJackClubs > 0)
            {
                jackOfClubs = true;
            }
            // Debug.Log("Clicked on Jack of Clubs");
        }

    }
    public void QueenHearts()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnQueenHearts += chipStorage;
                totalBalance -= chipStorage;
                QueenHeartSpawner();
            }

            AssigningTotalBetvalues();


            if (betOnQueenHearts > 0)
            {
                queenOfHearts = true;
            }
            // Debug.Log("Clicked on Queen of Hearts");
        }

    }
    public void QueenSpades()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnQueenSpades += chipStorage;
                totalBalance -= chipStorage;
                QueenSpadeSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnQueenSpades > 0)
            {
                queenOfSpades = true;
            }
            // Debug.Log("Clicked on Queen of Spades");
        }

    }
    public void QueenDiamonds()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnQueenDiamonds += chipStorage;
                totalBalance -= chipStorage;
                QueenDiamondSpawner();
            }
            AssigningTotalBetvalues();


            if (betOnQueenDiamonds > 0)
            {
                queenOfDiamonds = true;
            }
            // Debug.Log("Clicked on Queen of Diamonds");
        }

    }
    public void QueenClubs()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnQueenClubs += chipStorage;
                totalBalance -= chipStorage;
                QueenClubSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnQueenClubs > 0)
            {
                queenOfClubs = true;
            }
            // Debug.Log("Clicked on Queen of Clubs");
        }

    }
    public void KingHearts()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnKingHearts += chipStorage;
                totalBalance -= chipStorage;
                KingHeartSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnKingHearts > 0)
            {
                kingOfHearts = true;
            }
            //Debug.Log("Clicked on King of Hearts");
        }

    }
    public void KingSpades()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnKingSpades += chipStorage;
                totalBalance -= chipStorage;
                KingSpadeSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnKingSpades > 0)
            {
                kingOfSpades = true;
            }
            //Debug.Log("Clicked on King of Spades");
        }

    }
    public void KingDiamonds()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnKingDiamonds += chipStorage;
                totalBalance -= chipStorage;
                KingDiamondSpawner();
            }
            AssigningTotalBetvalues();


            if (betOnKingDiamonds > 0)
            {
                kingOfDiamonds = true;
            }
            // Debug.Log("Clicked on King of Diamonds");
        }

    }
    public void KingClubs()
    {
        if (currentTime > deadLineTime)
        {
            if (totalBalance >= chipStorage)
            {


                betOnKingClubs += chipStorage;
                totalBalance -= chipStorage;
                KingClubSpawner();

            }
            AssigningTotalBetvalues();


            if (betOnKingClubs > 0)
            {
                kingOfClubs = true;
            }
            // Debug.Log("Clicked on King of Clubs");
        }

    }
    void JackHeartsSpawner()
    {
        if (chipStorage > 0 || betOnJackHearts > 0)
        {

            jackHeartsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(jackHeartChip);
            jackHeartChip = Instantiate(chip, jackHeartsCard.transform.position, jackHeartsCard.transform.rotation);
            jackHeartChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackHeartsCards").transform, false);
            jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();




            if (betOnJackHearts >= chip5Value && betOnJackHearts < chip10Value)
            {
                // Destroy(newchip);
                jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();


            }
            else if (betOnJackHearts >= chip10Value && betOnJackHearts < chip50Value)
            {
                //Destroy(newchip);
                jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();
            }
            else if (betOnJackHearts >= chip50Value && betOnJackHearts < chip100Value)
            {
                //Destroy(newchip);
                jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString(); ;
            }
            else if (betOnJackHearts >= chip100Value && betOnJackHearts < chip500Value)
            {
                // Destroy (newchip);
                jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();
            }
            else if (betOnJackHearts >= chip500Value)
            {
                // Destroy(newchip);
                jackHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                jackHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackHearts.ToString();
            }
        }

    }
    void JackSpadeSpawner()
    {
        if (chipStorage > 0 || betOnJackSpades > 0)
        {
            jackSpadesCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(jackSpadeChip);
            jackSpadeChip = Instantiate(chip, jackSpadesCard.transform.position, jackSpadesCard.transform.rotation);
            jackSpadeChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackSpadesCards").transform, false);
            jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();

            if (betOnJackSpades >= chip5Value && betOnJackSpades < chip10Value)
            {
                jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
            }
            else if (betOnJackSpades >= chip10Value && betOnJackSpades < chip50Value)
            {
                jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
            }
            else if (betOnJackSpades >= chip50Value && betOnJackSpades < chip100Value)
            {
                jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
            }
            else if (betOnJackSpades >= chip100Value && betOnJackSpades < chip500Value)
            {
                jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
            }
            else if (betOnJackSpades >= chip500Value)
            {
                jackSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                jackSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackSpades.ToString();
            }
        }

    }
    void JackDiamondSpawner()
    {
        if (chipStorage > 0 || betOnJackDiamonds > 0)
        {
            jackDiamondsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(jackSDiamondChip);
            jackSDiamondChip = Instantiate(chip, jackDiamondsCard.transform.position, jackDiamondsCard.transform.rotation);
            jackSDiamondChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackDiamondsCards").transform, false);
            jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();

            if (betOnJackDiamonds >= chip5Value && betOnJackDiamonds < chip10Value)
            {
                jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
            }
            else if (betOnJackDiamonds >= chip10Value && betOnJackDiamonds < chip50Value)
            {
                jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
            }
            else if (betOnJackDiamonds >= chip50Value && betOnJackDiamonds < chip100Value)
            {
                jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
            }
            else if (betOnJackDiamonds >= chip100Value && betOnJackDiamonds < chip500Value)
            {
                jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
            }
            else if (betOnJackDiamonds >= chip500Value)
            {
                jackSDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                jackSDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackDiamonds.ToString();
            }
        }

    }
    void JackClubSpawner()
    {
        if (chipStorage > 0 || betOnJackClubs > 0)
        {
            jackClubsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(jackClubChip);
            jackClubChip = Instantiate(chip, jackClubsCard.transform.position, jackClubsCard.transform.rotation);
            jackClubChip.transform.SetParent(GameObject.FindGameObjectWithTag("JackClubsCards").transform, false);
            jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();

            if (betOnJackClubs >= chip5Value && betOnJackClubs < chip10Value)
            {
                jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
            }
            else if (betOnJackClubs >= chip10Value && betOnJackClubs < chip50Value)
            {
                jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
            }
            else if (betOnJackClubs >= chip50Value && betOnJackClubs < chip100Value)
            {
                jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
            }
            else if (betOnJackClubs >= chip100Value && betOnJackClubs < chip500Value)
            {
                jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
            }
            else if (betOnJackClubs >= chip500Value)
            {
                jackClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                jackClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnJackClubs.ToString();
            }
        }
    }
    void QueenHeartSpawner()
    {
        if (chipStorage > 0 || betOnQueenHearts > 0)
        {
            queenHeartsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(queenHeartChip);
            queenHeartChip = Instantiate(chip, queenHeartsCard.transform.position, queenHeartsCard.transform.rotation);
            queenHeartChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenHeartsCards").transform, false);
            queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();

            if (betOnQueenHearts >= chip5Value && betOnQueenHearts < chip10Value)
            {
                queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
            }
            else if (betOnQueenHearts >= chip10Value && betOnQueenHearts < chip50Value)
            {
                queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
            }
            else if (betOnQueenHearts >= chip50Value && betOnQueenHearts < chip100Value)
            {
                queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
            }
            else if (betOnQueenHearts >= chip100Value && betOnQueenHearts < chip500Value)
            {
                queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
            }
            else if (betOnQueenHearts >= chip500Value)
            {
                queenHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                queenHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenHearts.ToString();
            }
        }

    }
    void QueenSpadeSpawner()
    {
        if (chipStorage > 0 || betOnQueenSpades > 0)
        {
            queenSpadesCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(queenSpadeChip);
            queenSpadeChip = Instantiate(chip, queenSpadesCard.transform.position, queenSpadesCard.transform.rotation);
            queenSpadeChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenSpadesCards").transform, false);
            queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();

            if (betOnQueenSpades >= chip5Value && betOnQueenSpades < chip10Value)
            {
                queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
            }
            else if (betOnQueenSpades >= chip10Value && betOnQueenSpades < chip50Value)
            {
                queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
            }
            else if (betOnQueenSpades >= chip50Value && betOnQueenSpades < chip100Value)
            {
                queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
            }
            else if (betOnQueenSpades >= chip100Value && betOnQueenSpades < chip500Value)
            {
                queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
            }
            else if (betOnQueenSpades >= chip500Value)
            {
                queenSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                queenSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenSpades.ToString();
            }
        }

    }
    void QueenDiamondSpawner()
    {
        if (chipStorage > 0 || betOnQueenDiamonds > 0)
        {
            queenDiamondsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(queenDiamondChip);
            queenDiamondChip = Instantiate(chip, queenDiamondsCard.transform.position, queenDiamondsCard.transform.rotation);
            queenDiamondChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenDiamondsCards").transform, false);
            queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();

            if (betOnQueenDiamonds >= chip5Value && betOnQueenDiamonds < chip10Value)
            {
                queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
            }
            else if (betOnQueenDiamonds >= chip10Value && betOnQueenDiamonds < chip50Value)
            {
                queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
            }
            else if (betOnQueenDiamonds >= chip50Value && betOnQueenDiamonds < chip100Value)
            {
                queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
            }
            else if (betOnQueenDiamonds >= chip100Value && betOnQueenDiamonds < chip500Value)
            {
                queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
            }
            else if (betOnQueenDiamonds >= chip500Value)
            {
                queenDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                queenDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenDiamonds.ToString();
            }
        }

    }
    void QueenClubSpawner()
    {
        if (chipStorage > 0 || betOnQueenClubs > 0)
        {
            queenClubsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(queenClubChip);
            queenClubChip = Instantiate(chip, queenClubsCard.transform.position, queenClubsCard.transform.rotation);
            queenClubChip.transform.SetParent(GameObject.FindGameObjectWithTag("QueenClubsCards").transform, false);
            queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();

            if (betOnQueenClubs >= chip5Value && betOnQueenClubs < chip10Value)
            {
                queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
            }
            else if (betOnQueenClubs >= chip10Value && betOnQueenClubs < chip50Value)
            {
                queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
            }
            else if (betOnQueenClubs >= chip50Value && betOnQueenClubs < chip100Value)
            {
                queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
            }
            else if (betOnQueenClubs >= chip100Value && betOnQueenClubs < chip500Value)
            {
                queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
            }
            else if (betOnQueenClubs >= chip500Value)
            {
                queenClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                queenClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnQueenClubs.ToString();
            }
        }

    }
    void KingHeartSpawner()
    {
        if (chipStorage > 0 || betOnKingHearts > 0)
        {
            kingHeartsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(kingHeartChip);
            kingHeartChip = Instantiate(chip, kingHeartsCard.transform.position, kingHeartsCard.transform.rotation);
            kingHeartChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingsHeartsCards").transform, false);
            kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();

            if (betOnKingHearts >= chip5Value && betOnKingHearts < chip10Value)
            {
                kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
            }
            else if (betOnKingHearts >= chip10Value && betOnKingHearts < chip50Value)
            {
                kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
            }
            else if (betOnKingHearts >= chip50Value && betOnKingHearts < chip100Value)
            {
                kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
            }
            else if (betOnKingHearts >= chip100Value && betOnKingHearts < chip500Value)
            {
                kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
            }
            else if (betOnKingHearts >= chip500Value)
            {
                kingHeartChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                kingHeartChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingHearts.ToString();
            }
        }

    }
    void KingSpadeSpawner()
    {
        if (chipStorage > 0 || betOnKingSpades > 0)
        {
            kingSpadesCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(kingSpadeChip);
            kingSpadeChip = Instantiate(chip, kingSpadesCard.transform.position, kingSpadesCard.transform.rotation);
            kingSpadeChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingSpadescards").transform, false);
            kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();

            if (betOnKingSpades >= chip5Value && betOnKingSpades < chip10Value)
            {
                kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
            }
            else if (betOnKingSpades >= chip10Value && betOnKingSpades < chip50Value)
            {
                kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
            }
            else if (betOnKingSpades >= chip50Value && betOnKingSpades < chip100Value)
            {
                kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
            }
            else if (betOnKingSpades >= chip100Value && betOnKingSpades < chip500Value)
            {
                kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
            }
            else if (betOnKingSpades >= chip500Value)
            {
                kingSpadeChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                kingSpadeChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingSpades.ToString();
            }
        }

    }
    void KingDiamondSpawner()
    {
        if (chipStorage > 0 || betOnKingDiamonds > 0)
        {
            kingDiamondsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(kingDiamondChip);
            kingDiamondChip = Instantiate(chip, kingDiamondsCard.transform.position, kingDiamondsCard.transform.rotation);
            kingDiamondChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingDiamondsCards").transform, false);
            kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();

            if (betOnKingDiamonds >= chip5Value && betOnKingDiamonds < chip10Value)
            {
                kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
            }
            else if (betOnKingDiamonds >= chip10Value && betOnKingDiamonds < chip50Value)
            {
                kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
            }
            else if (betOnKingDiamonds >= chip50Value && betOnKingDiamonds < chip100Value)
            {
                kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
            }
            else if (betOnKingDiamonds >= chip100Value && betOnKingDiamonds < chip500Value)
            {
                kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
            }
            else if (betOnKingDiamonds >= chip500Value)
            {
                kingDiamondChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                kingDiamondChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingDiamonds.ToString();
            }
        }

    }
    void KingClubSpawner()
    {
        if (chipStorage > 0 || betOnKingClubs > 0)
        {

            kingClubsCard.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(kingClubChip);
            kingClubChip = Instantiate(chip, kingClubsCard.transform.position, kingClubsCard.transform.rotation);
            kingClubChip.transform.SetParent(GameObject.FindGameObjectWithTag("KingClubsCards").transform, false);
            kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();

            if (betOnKingClubs >= chip5Value && betOnKingClubs < chip10Value)
            {
                kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin5.GetComponent<SpriteRenderer>().sprite);
                kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
            }
            else if (betOnKingClubs >= chip10Value && betOnKingClubs < chip50Value)
            {
                kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin10.GetComponent<SpriteRenderer>().sprite);
                kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
            }
            else if (betOnKingClubs >= chip50Value && betOnKingClubs < chip100Value)
            {
                kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin50.GetComponent<SpriteRenderer>().sprite);
                kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
            }
            else if (betOnKingClubs >= chip100Value && betOnKingClubs < chip500Value)
            {
                kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin100.GetComponent<SpriteRenderer>().sprite);
                kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
            }
            else if (betOnKingClubs >= chip500Value)
            {
                kingClubChip.GetComponent<LuckyCards_CoinController>().IconChanger(coin500.GetComponent<SpriteRenderer>().sprite);
                kingClubChip.GetComponentInChildren<TextMeshProUGUI>().text = betOnKingClubs.ToString();
            }
        }

    }

    public void RemoveJackHeart()
    {
        value -= betOnJackHearts;
        totalBalance += betOnJackHearts;
        betOnJackHearts = 0;
        Destroy(jackHeartChip);
        jackHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;

    }
    public void RemoveJackSpades()
    {
        value -= betOnJackSpades;
        totalBalance += betOnJackSpades;
        betOnJackSpades = 0;
        Destroy(jackSpadeChip);
        jackSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;

    }
    public void RemoveJackDiamonds()
    {
        value -= betOnJackDiamonds;
        totalBalance += betOnJackDiamonds;
        betOnJackDiamonds = 0;
        Destroy(jackSDiamondChip);
        jackDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveJackClubs()
    {
        value -= betOnJackClubs;
        totalBalance += betOnJackClubs;
        betOnJackClubs = 0;
        Destroy(jackClubChip);
        jackClubsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveQueenHearts()
    {
        value -= betOnQueenHearts;
        totalBalance += betOnQueenHearts;
        betOnQueenHearts = 0;
        Destroy(queenHeartChip);
        queenHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveQueenSpades()
    {
        value -= betOnQueenSpades;
        totalBalance += betOnQueenSpades;
        betOnQueenSpades = 0;
        Destroy(queenSpadeChip);
        queenSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveQueenDiamonds()
    {
        value -= betOnQueenDiamonds;
        totalBalance += betOnQueenDiamonds;
        betOnQueenDiamonds = 0;
        Destroy(queenDiamondChip);
        queenDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveQueenClubs()
    {
        value -= betOnQueenClubs;
        totalBalance += betOnQueenClubs;
        betOnQueenClubs = 0;
        Destroy(queenClubChip);
        queenClubsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveKingHearts()
    {
        value -= betOnKingHearts;
        totalBalance += betOnKingHearts;
        betOnKingHearts = 0;
        Destroy(kingHeartChip);
        kingHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveKingSpades()
    {
        value -= betOnKingSpades;
        totalBalance += betOnKingSpades;
        betOnKingSpades = 0;
        Destroy(kingSpadeChip);
        kingSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveKingDiamonds()
    {
        value -= betOnKingDiamonds;
        totalBalance += betOnKingDiamonds;
        betOnKingDiamonds = 0;
        Destroy(kingDiamondChip);
        kingDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void RemoveKingClubs()
    {
        value -= betOnKingClubs;
        totalBalance += betOnKingClubs;
        betOnKingClubs = 0;
        Destroy(kingClubChip);
        kingClubsCard.GetComponent<SpriteRenderer>().color = Color.white;
    }




    public void Chip2()
    {
        if (currentTime > deadLineTime)
        {
            chipStorage = chip2Value;
            chip = coin2;
            Debug.Log("Called Chip 2");
            // chippies[0].GetComponent<UnityEngine.UI.Image>().sprite = highlightedChips[0];
            //Debug.Log("Clicked on Chip 2");
        }


    }
    public void Chip5()
    {
        if (currentTime > deadLineTime)
        {
            chipStorage = chip5Value;
            chip = coin5;
            //  chippies[1].GetComponent<UnityEngine.UI.Image>().sprite = highlightedChips[1];
            // Debug.Log("Clicked on Chip 5");
        }

    }
    public void Chip10()
    {
        if (currentTime > deadLineTime)
        {
            chipStorage = chip10Value;
            chip = coin10;
            //  chippies[2].GetComponent<UnityEngine.UI.Image>().sprite = highlightedChips[2];
            // Debug.Log("Clicked on Chip 10");
        }

    }
    public void Chip50()
    {
        if (currentTime > deadLineTime)
        {
            chipStorage = chip50Value;
            chip = coin50;
            //  chippies[3].GetComponent<UnityEngine.UI.Image>().sprite = highlightedChips[3];
            // Debug.Log("Clicked on Chip 50");
        }

    }
    public void Chip100()
    {
        if (currentTime > deadLineTime)
        {
            chipStorage = chip100Value;
            chip = coin100;
            //  chippies[4].GetComponent<UnityEngine.UI.Image>().sprite = highlightedChips[4];
            //   Debug.Log("Clicked on Chip 100");
        }

    }
    public void Chip500()
    {
        if (currentTime > deadLineTime)
        {
            chipStorage = chip500Value;
            chip = coin500;
            //  chippies[5].GetComponent<UnityEngine.UI.Image>().sprite = highlightedChips[5];
            //  Debug.Log("Clicked on Chip 500");
        }

    }
   public void ResetChipValues()
    {
/*        totalBalance += totalBetValue;
*/
        // chipStorage = 0;
        betOnJackHearts = 0;
        betOnJackSpades = 0;
        betOnJackDiamonds = 0;
        betOnJackClubs = 0;

        betOnQueenHearts = 0;
        betOnQueenSpades = 0;
        betOnQueenDiamonds = 0;
        betOnQueenClubs = 0;

        betOnKingHearts = 0;
        betOnKingSpades = 0;
        betOnKingDiamonds = 0;
        betOnKingClubs = 0;

        betOnAllHearts = 0;
        betOnAllSpades = 0;
        betOnAllDiamonds = 0;
        betOnAllClubs = 0;

        betOnAllJacks = 0;
        betOnAllQueens = 0;
        betOnAllKings = 0;


    }

    //To assign the total value placed on all the cards to the total bet value
    void AssigningTotalBetvalues()
    {
        betOnAllJacks = betOnJackHearts + betOnJackSpades + betOnJackDiamonds + betOnJackClubs;
        betOnAllQueens = betOnQueenHearts + betOnQueenSpades + betOnQueenDiamonds + betOnQueenClubs;
        betOnAllKings = betOnKingHearts + betOnKingSpades + betOnKingDiamonds + betOnKingClubs;
        value = betOnAllJacks + betOnAllQueens + betOnAllKings;
    }

    //To place the repeat values of the previous placed bet in the current bet
    void StoringReBetValues()
    {
        betOnJackHearts1 = betOnJackHearts;
        betOnJackSpades1 = betOnJackSpades;
        betOnJackDiamonds1 = betOnJackDiamonds;
        betOnJackClubs1 = betOnJackClubs;

        betOnQueenHearts1 = betOnQueenHearts;
        betOnQueenSpades1 = betOnQueenSpades;
        betOnQueenDiamonds1 = betOnQueenDiamonds;
        betOnQueenClubs1 = betOnQueenClubs;

        betOnKingHearts1 = betOnKingHearts;
        betOnKingSpades1 = betOnKingSpades;
        betOnKingDiamonds1 = betOnKingDiamonds;
        betOnKingClubs1 = betOnKingClubs;
    }
    public void TotalValueOfBetStored()
    {
        betOnJackHearts1 = totalBetOnJackHearts;
        betOnJackSpades1 = totalBetOnJackSpades;
        betOnJackDiamonds1 = totalBetOnJackDiamonds;
        betOnJackClubs1 = totalBetOnJackClubs;

        betOnQueenHearts1 = totalBetOnQueenHearts;
        betOnQueenSpades1 = totalBetOnQueenSpades;
        betOnQueenDiamonds1 = totalBetOnQueenDiamonds;
        betOnQueenClubs1 = totalBetOnQueenClubs;

        betOnKingHearts1 = totalBetOnKingHearts;
        betOnKingSpades1 = totalBetOnKingSpades;
        betOnKingDiamonds1 = totalBetOnKingDiamonds;
        betOnKingClubs1 = totalBetOnQueenClubs;
    }
    void ReBetOption()
    {
        totalBalance = prevBalance;

        betOnJackHearts = betOnJackHearts1;
        betOnJackSpades = betOnJackSpades1;
        betOnJackDiamonds = betOnJackDiamonds1;
        betOnJackClubs = betOnJackClubs1;

        betOnQueenHearts = betOnQueenHearts1;
        betOnQueenSpades = betOnQueenSpades1;
        betOnQueenDiamonds = betOnQueenDiamonds1;
        betOnQueenClubs = betOnQueenClubs1;

        betOnKingHearts = betOnKingHearts1;
        betOnKingSpades = betOnKingSpades1;
        betOnKingDiamonds = betOnKingDiamonds1;
        betOnKingClubs = betOnKingClubs1;

        jackHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
        jackSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
        jackDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
        jackClubsCard.GetComponent<SpriteRenderer>().color = Color.white;

        queenHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
        queenSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
        queenDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
        queenClubsCard.GetComponent<SpriteRenderer>().color = Color.white;

        kingHeartsCard.GetComponent<SpriteRenderer>().color = Color.white;
        kingSpadesCard.GetComponent<SpriteRenderer>().color = Color.white;
        kingDiamondsCard.GetComponent<SpriteRenderer>().color = Color.white;
        kingClubsCard.GetComponent<SpriteRenderer>().color = Color.white;



        Destroy(jackHeartChip);
        Destroy(jackSpadeChip);
        Destroy(jackSDiamondChip);
        Destroy(jackClubChip);

        Destroy(queenHeartChip);
        Destroy(queenSpadeChip);
        Destroy(queenDiamondChip);
        Destroy(queenClubChip);

        Destroy(kingHeartChip);
        Destroy(kingSpadeChip);
        Destroy(kingDiamondChip);
        Destroy(kingClubChip);



        subValue = betOnJackHearts + betOnJackSpades + betOnJackDiamonds + betOnJackClubs + betOnQueenHearts + betOnQueenSpades + betOnQueenDiamonds + betOnQueenClubs + betOnKingHearts + betOnKingSpades + betOnKingDiamonds + betOnKingClubs;
        value = subValue;

    }
    void DoubleOption()
    {
        betOnJackHearts += betOnJackHearts;
        betOnJackSpades += betOnJackSpades;
        betOnJackDiamonds += betOnJackDiamonds;
        betOnJackClubs += betOnJackClubs;

        betOnQueenHearts += betOnQueenHearts;
        betOnQueenSpades += betOnQueenSpades;
        betOnQueenDiamonds += betOnQueenDiamonds;
        betOnQueenClubs += betOnQueenClubs;

        betOnKingHearts += betOnKingHearts;
        betOnKingSpades += betOnKingSpades;
        betOnKingDiamonds += betOnKingDiamonds;
        betOnKingClubs += betOnKingClubs;
    }

    /* void DisplayBetOnCards()
     {
         betOnJackHeartsText.text = "JoH " + betOnJackHearts;
         betOnJackSpadesText.text = "JoS " + betOnJackSpades;
         betOnJackDiamondsText.text = "JoD " + betOnJackDiamonds;
         betOnJackClubsText.text = "JoC " + betOnJackClubs;

         betOnQueenHeartsText.text = "QoH " + betOnQueenHearts;
         betOnQueenSpadesText.text = "QoS " + betOnQueenSpades;
         betOnQueenDiamondsText.text = "QoD " + betOnQueenDiamonds;
         betOnQueenClubsText.text = "QoC " + betOnQueenClubs;

         betOnKingHeartsText.text = "KoH " + betOnKingHearts;
         betOnKingSpadesText.text = "KoS " + betOnKingSpades;
         betOnKingDiamondsText.text = "KoD " + betOnKingDiamonds;
         betOnKingClubsText.text = "KoC " + betOnKingClubs;

     }*/

    //To claim all the remaining balance in the claim field

    // Function to add the claimable balance to the main total balance amount
    // This function helps to claim only the required amount that the player requests to add to the main balance amount
    void ClaimAllWinningBalance()
    {
        claimBalanceAmount = float.Parse(claimBalanceAmountStrg);
        //double doubleValue = Convert.ToDouble(claimBalanceAmount);
        if (claimableBalance >= claimBalanceAmount)
        {
            if (claimBalanceAmount > 0)
            {
                claimableBalance -= claimBalanceAmount;
                totalBalance += claimBalanceAmount;
            }

        }

    }

    public void ClaimBalanceButton()
    {
        if (currentTime > deadLineTime)
        {
            claimWinButton.enabled = true;
            claimBalanceAmountStrg = claimField.text;
            ClaimAllWinningBalance();
            claimField.text = " ";
            Debug.Log("Claimed winning : " + claimBalanceAmountStrg);
        }

    }
    // To claim all the claimable (winnings) amount to the total balance amount
    public void ClaimAllWinnings()
    {
        if (currentTime > deadLineTime)
        {

            totalBalance += claimableBalance;
            claimableBalance -= claimableBalance;
            Debug.Log(totalBalance);
        }

    }
    void ShowTimer()
    {
        /* showingwinnerPanel = false;
         startingTime = 97;
         currentTime = startingTime;*/
    }
    void ReturnTheAmountOfWin()
    {
        //  Invoke("ShowTimer", 8);
        StartCoroutine(Datas.instance.StartGame(Datas.instance.loginDatas.userid, Datas.instance.loginDatas.api_token, 14));
        LuckyCards_Timer.Instance.maxTime = 104;
        LuckyCards_Timer.Instance.timeLeft = LuckyCards_Timer.Instance.maxTime;
        LuckyCards_Timer.Instance.enabled = true;
        timeUpdated = false;
        if (winner == cards[0].cardType)
        {
            winAmount = betOnJackHearts1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }

            // betAcceptedText.text = "JackOfHearts  :  " + winAmount;
            AutoClaimFunction();




        }
        gameId.text = Datas.instance.luckycardsstartGameData.gameplay.ToString();

        if (winner == cards[1].cardType)
        {
            winAmount = betOnJackSpades1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "JackOfSpades  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[2].cardType)
        {
            winAmount = betOnJackDiamonds1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "JackOfDiamonds  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[3].cardType)
        {
            winAmount = betOnJackClubs1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "JackOfClubs  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[4].cardType)
        {
            winAmount = betOnQueenHearts1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "QueenOfHearts :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[5].cardType)
        {
            winAmount = betOnQueenSpades1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "QueenOfSpades  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[6].cardType)
        {
            winAmount = betOnQueenDiamonds1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "QueenOfDiamonds  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[7].cardType)
        {
            winAmount = betOnQueenClubs1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            //  betAcceptedText.text = "QueenOfClubs   :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[8].cardType)
        {
            winAmount = betOnKingHearts1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            //  betAcceptedText.text = "KingOfHearts  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[9].cardType)
        {
            winAmount = betOnKingSpades1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "KingOfSpades  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[10].cardType)
        {
            winAmount = betOnKingDiamonds1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "KingOfDiamonds  :  " + winAmount;
            AutoClaimFunction();

        }
        if (winner == cards[11].cardType)
        {
            winAmount = betOnKingClubs1 * winningAmount;
            if (winAmount > 0)
            {
                ActivateWinnerPanel();
            }
            // betAcceptedText.text = "KingOfClubs  :  " + winAmount;
            AutoClaimFunction();
        }
        TurnOffAllBonusDisplay();

    }
    /*
        void StoringHistory()
        {
            if(winner != null)
            {
               // collection.Add(winner);
                // StoringHistoryInGame();

                StoringHistoryInSettingsPanel();


            }
        }*/

    public void SetAllFlase()
    {
        jackOfHearts = false;
        jackOfSpades = false;
        jackOfDiamonds = false;
        jackOfClubs = false;

        queenOfHearts = false;
        queenOfSpades = false;
        queenOfDiamonds = false;
        queenOfClubs = false;

        kingOfHearts = false;
        kingOfSpades = false;
        kingOfDiamonds = false;
        kingOfClubs = false;
    }

    void TotalValueOnEveryCards()
    {
        totalBetOnJackHearts += betOnJackHearts;
        betTakenAmount[0] = (int)totalBetOnJackHearts;
        totalBetOnJackSpades += betOnJackSpades;
        betTakenAmount[1] = (int)totalBetOnJackSpades;
        totalBetOnJackDiamonds += betOnJackDiamonds;
        betTakenAmount[2] = (int)totalBetOnJackDiamonds;
        totalBetOnJackClubs += betOnJackClubs;
        betTakenAmount[3] = (int)totalBetOnJackClubs;

        totalBetOnQueenHearts += betOnQueenHearts;
        betTakenAmount[4] = (int)totalBetOnQueenHearts;
        totalBetOnQueenSpades += betOnQueenSpades;
        betTakenAmount[5] = (int)totalBetOnQueenSpades;
        totalBetOnQueenDiamonds += betOnQueenDiamonds;
        betTakenAmount[6] = (int)totalBetOnQueenDiamonds;
        totalBetOnQueenClubs += betOnQueenClubs;
        betTakenAmount[7] = (int)totalBetOnQueenClubs;

        totalBetOnKingHearts += betOnKingHearts;
        betTakenAmount[8] = (int)totalBetOnKingHearts;
        totalBetOnKingSpades += betOnKingSpades;
        betTakenAmount[9] = (int)totalBetOnKingSpades;
        totalBetOnKingDiamonds += betOnKingDiamonds;
        betTakenAmount[10] = (int)totalBetOnKingDiamonds;
        totalBetOnKingClubs += betOnKingClubs;
        betTakenAmount[11] = (int)totalBetOnKingClubs;
    }
    public void ResetTotalValueOnEveryCards()
    {
        totalBetOnJackHearts = 0;
        totalBetOnJackSpades = 0;
        totalBetOnJackDiamonds = 0;
        totalBetOnJackClubs = 0;

        totalBetOnQueenHearts = 0;
        totalBetOnQueenSpades = 0;
        totalBetOnQueenDiamonds = 0;
        totalBetOnQueenClubs = 0;

        totalBetOnKingHearts = 0;
        totalBetOnKingSpades = 0;
        totalBetOnKingDiamonds = 0;
        totalBetOnKingClubs = 0;

    }

    void ResetTheRebetValuesToZero()
    {
        betOnJackHearts1 = 0;
        betOnJackSpades1 = 0;
        betOnJackDiamonds1 = 0;
        betOnJackClubs1 = 0;

        betOnQueenHearts1 = 0;
        betOnQueenSpades1 = 0;
        betOnQueenDiamonds1 = 0;
        betOnQueenClubs1 = 0;

        betOnKingHearts1 = 0;
        betOnKingSpades1 = 0;
        betOnKingDiamonds1 = 0;
        betOnKingClubs1 = 0;

        previousBet = 0;

    }
    public void KillingChips()
    {
        Destroy(jackHeartChip);
        Destroy(jackSpadeChip);
        Destroy(jackSDiamondChip);
        Destroy(jackClubChip);
        Destroy(queenHeartChip);
        Destroy(queenSpadeChip);
        Destroy(queenDiamondChip);
        Destroy(queenClubChip);
        Destroy(kingHeartChip);
        Destroy(kingSpadeChip);
        Destroy(kingDiamondChip);
        Destroy(kingClubChip);
    }

    public void InvokeFunctions()
    {
        Invoke("ResetTheRebetValuesToZero", resetingTime);
        Invoke("CancelTheReset", resetingTime + 2f);
    }
    void CancelTheReset()
    {
        CancelInvoke("ResetTheRebetValuesToZero");
    }

    void AutoClaimFunction()
    {
        if (autoClaim.GetComponent<UnityEngine.UI.Toggle>().isOn == true)
        {
            totalBalance += winAmount;
        }
        else if (autoClaim.GetComponent<UnityEngine.UI.Toggle>().isOn == false)
        {
            claimableBalance += winAmount;
        }
    }
    //This is to display the history of the game

    void StoringHistoryInSettingsPanel()
    {
        historyStoringPanelText.text = "Previous Draw" + winner;

    }
    /*void StoringHistoryInGame()
    {
        for(int i = 0;i<collection.Count;i++)
        {
            GameObject obj = Instantiate(prevCards,historyStorage.transform.position-new Vector3(-3,0,0),Quaternion.identity);
            obj.GetComponent<HistoryItems>().Storage(collection[i]);
            obj.transform.SetParent(historyStorage.transform, false);
            
        }
    }*/
    public void WinnerSpriteDisplay(Sprite sprite)
    {

        winnerList.Insert(0, sprite);
        if (winnerList.Count > maxSizeForList)
        {
            winnerList.RemoveAt(maxSizeForList - 1);
        }
        // LuckyCards_HistoryItems.Instance.UpdataeWinner(winnerList);
        /*if (winnerList.Count >= maxSizeForList)
        {
            winnerList.RemoveAt(0);
        }
        winnerList.Add(sprite);
       // historyItems.UpdateWinner(WinnerList); 
        LuckyCards_HistoryItems.Instance.UpdateWinner(winnerList);*/
    }



    /* public void OnPointerClick(PointerEventData eventData)
     {
         throw new NotImplementedException();
     }*/

    public IEnumerator CallPlayBet()
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
    
    }

    public void InfoPanelHistorySetting()
    {
        infoPanelHistory[0].text = betOnJackHearts1.ToString();
        infoPanelHistory[1].text = betOnJackSpades1.ToString();
        infoPanelHistory[2].text = betOnJackDiamonds1.ToString();
        infoPanelHistory[3].text = betOnJackClubs1.ToString();
        infoPanelHistory[4].text = betOnQueenHearts1.ToString();
        infoPanelHistory[5].text = betOnQueenSpades1.ToString();
        infoPanelHistory[6].text = betOnQueenDiamonds1.ToString();
        infoPanelHistory[7].text = betOnQueenClubs1.ToString();
        infoPanelHistory[8].text = betOnKingHearts1.ToString();
        infoPanelHistory[9].text = betOnKingSpades1.ToString();
        infoPanelHistory[10].text = betOnKingDiamonds1.ToString();
        infoPanelHistory[11].text = betOnKingClubs1.ToString();
    }

    public void OnClickInfoResult()
    {
        foreach (Transform t in inforesultItemParent)
        {
            Destroy(t.gameObject);
        }
        ResultPanelActivate();
        for (int i = 0; i < Datas.instance.luckyCardsGameSummaryData.result.Count; i++)
        {
            GameObject go = Instantiate(infofresultItemObect, inforesultItemParent);
            go.GetComponent<LuckyCards_ResultItemPopup>().drawTimeText.text = Datas.instance.luckyCardsGameSummaryData.draw_time[i];
            go.GetComponent<LuckyCards_ResultItemPopup>().resultImage.sprite = LuckyCards_GameController.instance.winnerSprites[Datas.instance.luckyCardsGameSummaryData.result[i]];
        }

    }

    public void AddBalanceFromBackendAutoClaimToVariables()
    {
        Debug.LogWarning("Adding Balance From Backend Auto Claim");
        if (autoClaim.isOn)
        {
            claimableTicket = Datas.instance.luckyCardsPlayBetData.unique_id;
            Debug.LogWarning("Inside AuotClaim");
            StartCoroutine(Datas.instance.ClaimBet(14, claimableTicket));
            claimedBalance += Datas.instance.luckyCardsDrawBetDatas.win_amount;
            totalBalance += claimedBalance;
           
            balanceAmountText.text = "Balance              " + userCredit.ToString();
            PlayerPrefs.SetInt("ClaimedBalance", claimedBalance);
        }
        else
        {
            Debug.LogWarning("Outside AutoClaim");
            unclaimedBalance += Datas.instance.luckyCardsDrawBetDatas.win_amount;
            PlayerPrefs.SetInt("UnclaimedBalance", unclaimedBalance);

        }
    }

    public void CallOnClickClaimButton()
    {
        Debug.Log("Calling claim button");
        StartCoroutine(OnCLickClaimBUtton());
    }
    public IEnumerator OnCLickClaimBUtton()
    {
        Debug.Log("Inside IEnumerator");     
        foreach (string claimTicket in Datas.instance.luckyCardsGameSummaryData.game_id)
        {
            if (currentTicket == claimTicket)
            {
             
                StartCoroutine(Datas.instance.ClaimBet(14, claimTicket));
               
                yield return new WaitForSeconds(3);
                userCredit = (float)Datas.instance.luckyCardsClaimBetData.credit;
                unclaimedBalance = 0;

            }
        }
        totalBalance = userCredit;
        balanceTexts.text = "Balance              "  + userCredit.ToString();

    }

    public void OnTicketValueChanged()
    {
        currentTicket = claimField.text;

    }
    public void OnClickInfoReport()
    {

        foreach (Transform t in inforeportItemParent)
        {
            Destroy(t.gameObject);
        }
        ReportPanelActivate();
        StartCoroutine(Datas.instance.GetSummary(14, DateTime.Now, DateTime.Today.AddDays(-7), 1, 1));
        GameObject go = Instantiate(inforeportItemObect, inforeportItemParent);
        go.GetComponent<LuckyCards_ReportItem>().nameText.text = Datas.instance.loginDatas.username;
        go.GetComponent<LuckyCards_ReportItem>().playText.text = Datas.instance.luckyCardsGameSummaryData.play[0];
        go.GetComponent<LuckyCards_ReportItem>().winText.text = Datas.instance.luckyCardsGameSummaryData.win[0];
        go.GetComponent<LuckyCards_ReportItem>().claimText.text = claimedBalance.ToString();
        go.GetComponent<LuckyCards_ReportItem>().unclaimText.text = unclaimedBalance.ToString();
        go.GetComponent<LuckyCards_ReportItem>().endText.text = Datas.instance.luckyCardsGameSummaryData.end[0].ToString();
        go.GetComponent<LuckyCards_ReportItem>().commText.text = 0.ToString();
        go.GetComponent<LuckyCards_ReportItem>().ntpText.text = 0.ToString();
    }

    public void OnClickUnclaimedTickets()
    {

        foreach (Transform t in infounclaimedticketstemParent)
        {
            Destroy(t.gameObject);
        }
        UnclaimedTicketsPanelActivate();
        StartCoroutine(Datas.instance.GetSummary(14, DateTime.Now, DateTime.Today.AddDays(-7), 1, 1));
        for (int i = 0; i < Datas.instance.luckyCardsGameSummaryData.game_id.Count; i++)
        {
            if (OnClickViewUnclaimedTickets(Datas.instance.luckyCardsGameSummaryData.draw_time[i]))
            {
                GameObject go = Instantiate(infounclaimedticketsItemObject, infounclaimedticketstemParent);
                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().ticketIDText.text = Datas.instance.luckyCardsGameSummaryData.game_id[i];
                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().gameIDText.text = Datas.instance.luckyCardsGameSummaryData.game_play[i].ToString();
                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().startpointText.text = Datas.instance.luckyCardsGameSummaryData.start_point[i].ToString();

                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().playedText.text = Datas.instance.luckyCardsGameSummaryData.play[i].ToString();

                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().wonText.text = Datas.instance.luckyCardsGameSummaryData.win[i].ToString();

                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().endpointText.text = Datas.instance.luckyCardsGameSummaryData.end_point[i].ToString();
                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().endText.text = Datas.instance.luckyCardsGameSummaryData.end[i].ToString();
                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().statusText.text = Datas.instance.luckyCardsGameSummaryData.play_status[i];

                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().resultImage.sprite = LuckyCards_GameController.instance.winnerSprites[Datas.instance.luckyCardsGameSummaryData.result[i]];

                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().drawtimeText.text = Datas.instance.luckyCardsGameSummaryData.draw_time[i].ToString();

                go.GetComponent<LuckyCards_UnclaimedTicketsListItem>().tickettimeText.text = Datas.instance.luckyCardsGameSummaryData.ticket_time[i].ToString();
            }
           
        }

    }

    public void OnClickHistoryPanel()
    {

        foreach (Transform t in infohistoryItemParent)
        {
            Destroy(t.gameObject);
        }
        GameHistoryPanelActivate();
        StartCoroutine(Datas.instance.GetSummary(14, DateTime.Now, DateTime.Today.AddDays(-7), 1, 1));
        for (int i = 0; i < Datas.instance.luckyCardsGameSummaryData.game_id.Count; i++)
        {
            if (OnClickViewUnclaimedTickets(Datas.instance.luckyCardsGameSummaryData.ticket_time[i]))
            {
                GameObject go = Instantiate(infohistoryItemObject, infohistoryItemParent);
                go.GetComponent<LuckyCards_HistoryPanelListItem>().ticketIDText.text = Datas.instance.luckyCardsGameSummaryData.game_id[i];
                go.GetComponent<LuckyCards_HistoryPanelListItem>().gameIDText.text = Datas.instance.luckyCardsGameSummaryData.game_play[i].ToString();
                go.GetComponent<LuckyCards_HistoryPanelListItem>().startpointText.text = Datas.instance.luckyCardsGameSummaryData.start_point[i].ToString();

                go.GetComponent<LuckyCards_HistoryPanelListItem>().playedText.text = Datas.instance.luckyCardsGameSummaryData.play[i].ToString();

                go.GetComponent<LuckyCards_HistoryPanelListItem>().wonText.text = Datas.instance.luckyCardsGameSummaryData.win[i].ToString();

                go.GetComponent<LuckyCards_HistoryPanelListItem>().endpointText.text = Datas.instance.luckyCardsGameSummaryData.end_point[i].ToString();
                go.GetComponent<LuckyCards_HistoryPanelListItem>().endText.text = Datas.instance.luckyCardsGameSummaryData.end[i].ToString();
                go.GetComponent<LuckyCards_HistoryPanelListItem>().statusText.text = Datas.instance.luckyCardsGameSummaryData.play_status[i];

                go.GetComponent<LuckyCards_HistoryPanelListItem>().resultImage.sprite = LuckyCards_GameController.instance.winnerSprites[Datas.instance.luckyCardsGameSummaryData.result[i]];

                go.GetComponent<LuckyCards_HistoryPanelListItem>().drawtimeText.text = Datas.instance.luckyCardsGameSummaryData.draw_time[i].ToString();

                go.GetComponent<LuckyCards_HistoryPanelListItem>().tickettimeText.text = Datas.instance.luckyCardsGameSummaryData.ticket_time[i].ToString();
            }
        }


    }

    public bool OnClickViewUnclaimedTickets(string currentdate)
    {
       
       /* Debug.Log(" To Date Check Befor " + (System.DateTime.Parse(fromdatePicker.Ref_InputField.text)));
        Debug.Log(" From Date Check Befor " + System.DateTime.Parse(todatePicker.Ref_InputField.text));*/

        DateRange range = new DateRange((System.DateTime.Parse(startDate)), System.DateTime.Parse(endDate));
        isInsidetheRange =  range.Includes(System.DateTime.Parse(currentdate));
        Debug.Log(range.Includes(System.DateTime.Parse(currentdate)));
        return isInsidetheRange;
    }

    public void OnValuceChangedInDatePicker(string startdate, string enddate)
    {
        startDate = startdate;
        endDate = enddate;
    }

    public void OnValueChangedCall()
    {
        OnValuceChangedInDatePicker(fromdatePicker.Ref_InputField.text, todatePicker.Ref_InputField.text);
    }

    public void OnValueChangedCallHistory()
    {
        OnValuceChangedInDatePicker(historyfromdatePicker.Ref_InputField.text, historytodatePicker.Ref_InputField.text);
    }

    public void OnAddingBalanceAmountToUnClaimedBalance()
    {
        Datas.instance.GetSummary(16, DateTime.Now, DateTime.Today.AddDays(-7), 1, 1);
        for (int i = 0; i < Datas.instance.luckyCardsGameSummaryData.game_id.Count; i++)
        {
            if (Datas.instance.luckyCardsGameSummaryData.game_id.Count > 0)
            {
                unclaimedBalance += System.Int32.Parse(Datas.instance.luckyCardsGameSummaryData.win[i]);
                PlayerPrefs.SetInt("UnclaimedBalance", unclaimedBalance);
            }
        }
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
