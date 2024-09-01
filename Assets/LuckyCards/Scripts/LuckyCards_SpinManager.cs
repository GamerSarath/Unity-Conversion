using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
[RequireComponent(typeof(Rigidbody2D))]
public class LuckyCards_SpinManager : MonoBehaviour
{
    public enum WheelType 
    {
      FirstWheel,SecondWheel
    
    }

    public int randomNumber;
    public int randomNumber2;
    public int winNumber;
    
    public bool randomNumberUpdated = false;

    public WheelType wheelType;
    public float Torque = 500.0f;
    public float MaxAngularVelocity = 1000.0f;
    public float AngularDrag = 0.7f;

    private float PredictedRotation;
    private Rigidbody2D Body;
    public Transform spinningWheel;
    public bool spinWheel;
    public float[] spinWheelSingles;
    public List<float> spinWheelNumbers = new List<float>();
    public int SinglewinNumber;
    public bool canUpdateTimeList = false;
    public bool winUpdate;
    public bool isClaiming;

    private void Awake()
    {

    }
    void Start()
    {
        isClaiming = false;

        spinWheel = false;
        randomNumberUpdated = false;
        winUpdate = false;
        Assert.raiseExceptions = true;
        /*for (int i = 0; i < 10; i++)
        {
            spinWheelNumbers.Add(spinWheelSingles[i]);
        }*/
        Body = GetComponent<Rigidbody2D>();
        Body.angularVelocity = 0f;
        Body.angularDrag = 0f;
    }

    private void FixedUpdate()
    {
        
        if (spinWheel)
        {

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

         

            if (wheelType == WheelType.SecondWheel)
            {
                if (!randomNumberUpdated)
                {
                   // LuckyCards_GameController.instance.randomNumber = Random.Range(0, 12);
                   // randomNumber =System.Int32.Parse(Datas.instance.luckyCardsDrawBetDatas.win_number);
                    randomNumberUpdated = true;

                    Debug.Log("Random Number is " + randomNumber);
                    // Debug.Log(randomNumber);
                }
               //AngularDrag = spinWheelSingles[randomNumber]; 
               
                SpinWheel(AngularDrag, LuckyCards_GameController.instance.spinManagers[1]); //spinWheelSingles[Random.Range(0,spinWheelSingles.Length)]
            }
            else 
            {
               
                    // randomNumber = Random.Range(0, spinWheelSingles.Length);
                   
                    
                    //  AngularDrag = spinWheelSingles[randomNumber];
                        Debug.Log("Random Number is " + LuckyCards_GameController.instance.randomNumber);
                    // Debug.Log(randomNumber);
                SpinWheel(AngularDrag, LuckyCards_GameController.instance.spinManagers[0]); //spinWheelSingles[Random.Range(0,spinWheelSingles.Length)]
                
                // Debug.Log(randomNumber);
            }


////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //  Debug.Log("Random Number is " + GameManager.Instance.singleWheelRandomNum + " " + spinWheelSingles.Length);
            //  SpinWheel(AngularDrag, this.GetComponent<SpinManager>()) ;//GameManager.Instance.trippleSpins[GameManager.Instance.trippleWheelRandomNum]
          
            //
            if (Body.IsSleeping())
            {
                // Debug.Log("Spinning Finished");

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                randomNumberUpdated = false;
                spinWheel = false;
                if (wheelType == WheelType.SecondWheel)
                {
                    for (int i = 0; i < 10; i++)
                    {

                        winNumber = System.Array.IndexOf(spinWheelSingles, Body.angularDrag);

                    }

                    if (!isClaiming)
                    {
                        LuckyCards_GameController.instance.AddBalanceFromBackendAutoClaimToVariables();
                        LuckyCards_GameController.instance.winAMountText.text = Datas.instance.luckyCardsClaimBetData.total_won;
                       

                        isClaiming = true;
                    }
                    if (!winUpdate)
                    {
                        LuckyCards_GameController.instance.winnerDisplay.enabled = true;
                        LuckyCards_GameController.instance.winnerDisplay.sprite = LuckyCards_GameController.instance.winnerSprites[System.Int32.Parse(Datas.instance.luckyCardsDrawBetDatas.win_number)];
                        LuckyCards_GameController.instance.DecideWinner(System.Int32.Parse(Datas.instance.luckyCardsDrawBetDatas.win_number));

                        winUpdate = true;
                    }
                }
                else
                {
                    
                    winNumber = System.Array.IndexOf(spinWheelSingles, Body.angularDrag);
                }
                Body.angularDrag = 0.05f;
                Torque = 500f;
                

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////               

                //   GameManager.Instance.spinMark.SetActive(true);
                // GameManager.Instance.gameEnds = true;

                /*if (!canUpdateTimeList)
                {
                    GameManager.Instance.spinWheelOne.GetComponent<SpinManager>().CalculateWinNumber();

                    string time = UIManager.Instance.currentTimeText.text;
                    GameManager.Instance.timeList.Insert(0, time.Substring(0, 5));


                    GameManager.Instance.SettingUpWinNumbers();
                    if (GameManager.Instance.timeList.Count >= 6)
                    {
                        Debug.LogWarning("Time List Limit Reached");
                        GameManager.Instance.timeList.RemoveAt(5);
                        GameManager.Instance.singleList.RemoveAt(5);
                        GameManager.Instance.doubleList.RemoveAt(5);
                        GameManager.Instance.trippleList.RemoveAt(5);

                    }
                    UIManager.Instance.UpdateTimeListTexts();

                    canUpdateTimeList = true;
                }*/
            }                                                   // SpinWheel(AngularDrag,this.GetComponent<SpinManager>());
        }
        //GameManager.Instance.SpinWheels();


    }

    public void SpinWheel(float angularDrag, LuckyCards_SpinManager SpinWheel)
    {

        // Debug.Log("Angular Drag is " + angularDrag);
        if (Torque == 0f)
            return;

        var timeStep = Time.fixedDeltaTime;
        var angularVelocity = Body.angularVelocity + Torque * timeStep;
        //Debug.Log("TIMESTEP IS " + timeStep + " angular velocity " + Body.angularVelocity);
        //Debug.Log("Angular velocity is   " + angularVelocity);
        if (angularVelocity >= MaxAngularVelocity)
        {
            angularVelocity = MaxAngularVelocity;
            Body.angularDrag = angularDrag;
            Torque = 0f;

        }

        //Debug.Log("Angular Drag after is " + angularDrag);
        ///Debug.Log("Angular Velocity is " + angularVelocity);
        Body.angularVelocity = angularVelocity;
        PredictedRotation = PredictRotation(Body.rotation, angularVelocity, angularDrag, timeStep);
        //Debug.Log("Angular Velocity after is " + Body.angularVelocity);
        //  Debug.Log("is sleeping si " + Body.IsSleeping());

    }
    /*  void OnGUI()
    {
        GUILayout.Label($"Predicted Rotation: {PredictedRotation} ({Mathf.Repeat(PredictedRotation, 360 - Mathf.Epsilon)})");
        GUILayout.Label($"Current Rotation: {Body.rotation} ({Mathf.Repeat(Body.rotation, 360 - Mathf.Epsilon)})");
        GUILayout.Label($"Current Velocity: {Body.angularVelocity}");
    }
*/
    float PredictRotation(float rotation, float angularVelocity, float angularDrag, float timeStep)
    {
        // If drag is zero then this integration method becomes an infinite loop.
        Assert.IsTrue(angularDrag > 0f);

        var sleepTime = 0f;
        var sleepToleranceSqr = Physics2D.angularSleepTolerance * Physics2D.angularSleepTolerance;

        // Iterate until the body would be asleep.
        while (sleepTime < Physics2D.timeToSleep)
        {
            angularVelocity *= 1f / (1f + timeStep * angularDrag);
            rotation += timeStep * angularVelocity;

            if ((angularVelocity * angularVelocity) <= sleepToleranceSqr)
                sleepTime += timeStep;
        };

        return rotation;
    }
    public void CalculateWinNumber()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == System.Array.IndexOf(spinWheelSingles, Body.angularDrag))
            {
                SinglewinNumber = spinWheelNumbers.IndexOf(Body.angularDrag);
            //    GameManager.Instance.singleResult = SinglewinNumber;



                // Debug.Log("Win number single is " + winNumber);
            }
        }
        Body.sleepMode = RigidbodySleepMode2D.StartAwake;
    }

}



