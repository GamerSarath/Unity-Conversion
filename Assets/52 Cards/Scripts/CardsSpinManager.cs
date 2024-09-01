using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;
public class CardsSpinManager : MonoBehaviour
{
    public enum WheelType
    {
        IconWheel,
        NumbersWheel
    }
    [SerializeField] WheelType wheelType;
    public float Torque = 500.0f;
    public float MaxAngularVelocity = 1000.0f;
    public float AngularDrag = 0.7f;
    public bool spinWheel;
    [SerializeField] float[] iconWheelDragValues;
    [SerializeField] float[] numbersWheelDragValues;
    [SerializeField] GameObject[] spinManagers;
    private float PredictedRotation;
    private Rigidbody2D Body;
    public Transform spinningWheel;
    [SerializeField] int spinWheelNumbers;
    [SerializeField] int spinWheelIcons;
    public string iconString;
    public string numberString;
    bool isIconFixed = false;
    bool isNumberFixed = false;
    public List<Sprite> iconWinSprite = new List<Sprite>();
    public List<Sprite>  numberWinSprite = new List<Sprite>();
    void OnEnable()
    {
        Assert.raiseExceptions = true;
        spinWheel = false;
        Body = GetComponent<Rigidbody2D>();
        Body.angularVelocity = 0f;
        Body.angularDrag = 0f;
        spinWheel = true;
        isIconFixed = false;
        isNumberFixed = false;
    }
    private void FixedUpdate()
    {

        if (spinWheel)
        {
            if (wheelType == WheelType.NumbersWheel)
            {
                if(!isNumberFixed)
                {
                    spinWheelNumbers = Random.Range(0, numbersWheelDragValues.Length);
                    isNumberFixed = true;
                }
               
                SpinWheel(numbersWheelDragValues[spinWheelNumbers], CardsGameManager.instance.spinManager[0]);

            }
            else
            {
                if(!isIconFixed)
                {
                    spinWheelIcons = Random.Range(0, iconWheelDragValues.Length);
                    isIconFixed=true;
                }
               
                SpinWheel(iconWheelDragValues[spinWheelIcons], CardsGameManager.instance.spinManager[1]);

            }


            if (Body.IsSleeping())
            {
                if (!CardsGameManager.instance.gameEnds)
                {
                    
                    Torque = 0;
                    Body.angularDrag = 0.05f;
                    Torque = 500;
                    spinWheel = false;
                    this.enabled = false;
                    CardsGameManager.instance.gameEnds = true;

                    CardsUIManager.instance.UpdateWinAmount(0);
                    WinMoment(wheelType);
                    CardsGameManager.instance.DecideVictory();

                    Debug.Log("Spinning Finished");
                    // CardsGameManager.instance.GameStarts();

                }

            }
        }

       
    }
   
    /*  void OnGUI()
    {
        GUILayout.Label($"Predicted Rotation: {PredictedRotation} ({Mathf.Repeat(PredictedRotation, 360 - Mathf.Epsilon)})");
        GUILayout.Label($"Current Rotation: {Body.rotation} ({Mathf.Repeat(Body.rotation, 360 - Mathf.Epsilon)})");
        GUILayout.Label($"Current Velocity: {Body.angularVelocity}");
    }*/
    public void SpinWheel(float angularDrag, CardsSpinManager SpinWheel)
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
        else
        {
            angularVelocity = Body.angularVelocity + Torque * timeStep;
        }
        //Debug.Log("Angular Drag after is " + angularDrag);
        ///Debug.Log("Angular Velocity is " + angularVelocity);
        Body.angularVelocity = angularVelocity;
        PredictedRotation = PredictRotation(Body.rotation, angularVelocity, angularDrag, timeStep);
        //Debug.Log("Angular Velocity after is " + Body.angularVelocity);
        //  Debug.Log("is sleeping si " + Body.IsSleeping());

    }

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

    public void WinMoment(WheelType wheel)
    {
        if(wheel == WheelType.IconWheel)
        {
            switch(spinWheelIcons)
            {
                case 0:
                    iconString = "Club";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[0]);
                    break;

                case 1:
                    iconString = "Hearts";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[2]);
                    break;

                case 2:
                    iconString = "Spades";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[3]);
                    break;

                case 3:
                    iconString = "Diamond";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[1]);
                    break;

                case 4:
                    iconString = "Spades";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[3]);
                    break;

                case 5:
                    iconString = "Hearts";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[2]);
                    break;

                case 6:
                    iconString = "Hearts";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[2]);
                    break;

                case 7:
                    iconString = "Club";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[0]);
                    break;

                case 8:
                    iconString = "Club";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[0]);
                    break;

                case 9:
                    iconString = "Spades";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[3]);
                    break;

                case 10:
                    iconString = "Diamond";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[1]);
                    break;

                case 11:
                    iconString = "Hearts";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[2]);
                    break;

                case 12:
                    iconString = "Diamond";
                    iconWinSprite.Insert(0, CardsGameManager.instance.IconSprites[1]);
                    break;

               
            }
          
            //CardsGameManager.instance.historyIconList.Insert(0, iconString);
           /* for (int i = 0;i < CardsUIManager.instance.historyIconImages.Length;i++)
            {
                if (i < iconWinSprite.Count)
                {
                    CardsUIManager.instance.historyIconImages[i].sprite = iconWinSprite[i];
                    CardsUIManager.instance.historyIconImages[i].enabled = true;
                }
             
            }*/
         /*   if (CardsGameManager.instance.historyIconList.Count  >= 12)
            {
                CardsGameManager.instance.historyIconList.RemoveAt(11);
                iconWinSprite.RemoveAt(11);
            }*/
        }
        else
        {
            switch (spinWheelNumbers)
            {
                case 0:
                    numberString = string.Concat(iconString +  " 2" );
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[0]);
                    break;

                case 1:
                    numberString = string.Concat(iconString +  " 3");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[1]);

                    break;

                case 2:
                    numberString = string.Concat(iconString + " 4");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[2]);

                    break;

                case 3:
                    numberString = string.Concat(iconString + " 5");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[3]);

                    break;

                case 4:
                    numberString = string.Concat(iconString + " 6");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[4]);

                    break;

                case 5:
                    numberString = string.Concat(iconString + " 7");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[5]);

                    break;

                case 6:
                    numberString = string.Concat(iconString + " 8");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[6]);

                    break;

                case 7:
                    numberString = string.Concat(iconString + " 9");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[7]);

                    break;

                case 8:
                    numberString = string.Concat(iconString + " 10");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[8]);

                    break;

                case 9:
                    numberString = string.Concat(iconString + " J");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[9]);

                    break;

                case 10:
                    numberString = string.Concat(iconString + " Q");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[10]);

                    break;

                case 11:
                    numberString = string.Concat(iconString + " K");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[11]);

                    break;

                case 12:
                    numberString = string.Concat(iconString + " A");
                    numberWinSprite.Insert(0, CardsGameManager.instance.numberSprites[12]);

                    break;


            }
            CardsGameManager.instance.GetComponent<CardFunctions>().repeatList = new List<Cards>();
            for (int i = CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList.Count - 1; i >= 0; i--)
            {
                int tempInteger = 0;
                CardsGameManager.instance.GetComponent<CardFunctions>().repeatList.Add(CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList[i]);
                CardsGameManager.instance.GetComponent<CardFunctions>().repeatList[(CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList.Count - 1) - i].betAmount = tempInteger;
            }
            CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList.Clear();

            //CardsGameManager.instance.historyNumberList.Insert(0, numberString);

           /* for (int i = 0; i < CardsUIManager.instance.historyNumberImages.Length; i++)
            {
                if (i < numberWinSprite.Count)
                {
                    CardsUIManager.instance.historyNumberImages[i].sprite = numberWinSprite[i];
                    CardsUIManager.instance.historyNumberImages[i].enabled = true;
                }

            }*/
            if (CardsGameManager.instance.GetComponent<CardFunctions>().advanceList != null)
            {
                for (int i = CardsGameManager.instance.GetComponent<CardFunctions>().advanceList.Count - 1; i >= 0; i--)
                {
                    if (!CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList.Contains(CardsGameManager.instance.GetComponent<CardFunctions>().advanceList[i]))
                    {
                        CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList.Add(CardsGameManager.instance.GetComponent<CardFunctions>().advanceList[i]);


                        /*for (int j = CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList.Count - 1; j >= 0; j--)
                        {
                            CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList[j].OnSelectCard();
                        }*/
                    }


                }
                CardsGameManager.instance.GetComponent<CardFunctions>().advanceList.Clear();
            }

            /*            if(CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards != null)
                        {
                            for(int i = CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Count;i >= 0; i--)
                            {
                                CardsGameManager.instance.GetComponent<CardFunctions>().bettakenList.Add(CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards[i]);

                            }
                        }*/
          /*  if (CardsGameManager.instance.historyNumberList.Count >= 12)
            {
                CardsGameManager.instance.historyNumberList.RemoveAt(11);
                numberWinSprite.RemoveAt(11);
            }*/
        }

        

        

        
        // CardsGameManager.instance.DecideWinString();

    }
}
