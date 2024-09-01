using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;
public class Fun_Target_SpinManager : MonoBehaviour
{
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
    private void Awake()
    {
    }
    void OnEnable()
    {
        spinWheel = false;
        Assert.raiseExceptions = true;
        for (int i = 0; i < 10; i++)
        {
          //  spinWheelNumbers.Add(spinWheelSingles[i]);
        }
        Body = GetComponent<Rigidbody2D>();
        Body.angularVelocity = 0f;
        Body.angularDrag = 0f;
        Body.angularDrag = 0.05f;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Torque = 500;
        spinWheel = true;
    }

    private void FixedUpdate()
    {

        if (spinWheel)
        {
            //  Debug.Log("Random Number is " + GameManager.Instance.singleWheelRandomNum + " " + spinWheelSingles.Length);
            //  SpinWheel(AngularDrag, this.GetComponent<SpinManager>()) ;//GameManager.Instance.trippleSpins[GameManager.Instance.trippleWheelRandomNum]
            SpinWheel(0.609f,this); //spinWheelSingles[Random.Range(0,spinWheelSingles.Length)]
            if (Body.IsSleeping())
            {
                Debug.Log("Spinning Finished");
                this.enabled = false;
                spinWheel = false;
                Fun_Target_Time_Manager.Instance.enabled = true;
               
            }                                                   // SpinWheel(AngularDrag,this.GetComponent<SpinManager>());
        }
        //GameManager.Instance.SpinWheels();


    } 

    public void SpinWheel(float angularDrag, Fun_Target_SpinManager SpinWheel)
    {

        // Debug.Log("Angular Drag is " + angularDrag);
        if (Torque == 0f)
            return;

        var timeStep = Time.fixedDeltaTime;
        var angularVelocity = Body.angularVelocity + Torque * timeStep;
        //Debug.Log("TIMESTEP IS " + timeStep + " angular velocity " + Body.angularVelocity);
        Debug.Log("Angular velocity is   " + angularVelocity);
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
               



                // Debug.Log("Win number single is " + winNumber);
            }
        }
        Body.sleepMode = RigidbodySleepMode2D.StartAwake;
    }

}
