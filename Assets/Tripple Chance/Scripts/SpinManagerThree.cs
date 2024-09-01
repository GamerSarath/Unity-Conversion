using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class SpinManagerThree : MonoBehaviour
{
    public float Torque = 500.0f;
    public float MaxAngularVelocity = 1000.0f;
    public float AngularDrag = 0.7f;

    private float PredictedRotation;
    private Rigidbody2D Body;
    public Transform spinningWheel;
    public bool spinWheel;
    public float[] trippleSpinAngularVelocities;
    public List<float> spinWheelNumbers = new List<float>();
    public int tripplewinNumber;
    private void Awake()
    {
    }
    void Start()
    {
        Assert.raiseExceptions = true;
       
        Body = GetComponent<Rigidbody2D>();
        for (int i = 0; i < 10; i++)
        {
            spinWheelNumbers.Add(trippleSpinAngularVelocities[i]);
        }
        Body.angularVelocity = 0f;
        Body.angularDrag = 0f;
    }

    private void FixedUpdate()
    {

        if (spinWheel)
        {
            int digit = (int)char.GetNumericValue(Datas.instance.winDigits[0]);
            SpinWheelThree(trippleSpinAngularVelocities[digit], this.GetComponent<SpinManagerThree>());
            //SpinWheel(GameManager.Instance.singleSpins[GameManager.Instance.singleWheelRandomNum], this.GetComponent<SpinManager>());
        }
        //GameManager.Instance.SpinWheels();
        if(Body.IsSleeping())
        {
            CalculateWinNUmber();
        }

    }

    public  void SpinWheelThree(float angularDrag, SpinManagerThree SpinWheel)
    {
       // Debug.Log("Angular Drag is " + angularDrag);
        if (Torque == 0f)
            return;

        var timeStep = Time.fixedDeltaTime;
        var angularVelocity = Body.angularVelocity + Torque * timeStep;
        //  Debug.Log("Angular velocity is   " + angularVelocity);
        if (angularVelocity >= MaxAngularVelocity)
        {
            angularVelocity = MaxAngularVelocity;
            Body.angularDrag = angularDrag;
            Torque = 0f;
        }
       // Debug.Log("Angular Drag after is " + angularDrag);

        Body.angularVelocity = angularVelocity;
        PredictedRotation = PredictRotation(Body.rotation, angularVelocity, angularDrag, timeStep);
    }

    /*public void SpinWheel(float angularDrag, SpinManagerTwo SpinWheel)
    {
        Debug.Log("Angular Drag is " + angularDrag);
        if (Torque == 0f)
            return;

        var timeStep = Time.fixedDeltaTime;
        var angularVelocity = Body.angularVelocity + Torque * timeStep;
        //  Debug.Log("Angular velocity is   " + angularVelocity);
        if (angularVelocity >= MaxAngularVelocity)
        {
            angularVelocity = MaxAngularVelocity;
            Body.angularDrag = angularDrag;
            Torque = 0f;
        }
        Debug.Log("Angular Drag after is " + angularDrag);

        Body.angularVelocity = angularVelocity;
        PredictedRotation = PredictRotation(Body.rotation, angularVelocity, angularDrag, timeStep);
    }*/
    /*void OnGUI()
    {
        GUILayout.Label($"Predicted Rotation: {PredictedRotation} ({Mathf.Repeat(PredictedRotation, 360 - Mathf.Epsilon)})");
        GUILayout.Label($"Current Rotation: {Body.rotation} ({Mathf.Repeat(Body.rotation, 360 - Mathf.Epsilon)})");
        GUILayout.Label($"Current Velocity: {Body.angularVelocity}");
    }*/

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
    public void CalculateWinNUmber()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == System.Array.IndexOf(trippleSpinAngularVelocities, Body.angularDrag))
            {
                tripplewinNumber = spinWheelNumbers.IndexOf(Body.angularDrag);
                GameManager.Instance.trippleResult = tripplewinNumber;
            }
        }

    }

}