using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JeethoRafther_Horse : MonoBehaviour
{
    public int horseIndex;
    public float speed;
    public float minSPeed;
    public float maxSpeed;
    public float minAcceleration;
    public float maxAcceeleration;
    public Vector3 startingPosition;
    public Transform target;
    public float currentSpeed;
    public float acceleration;

    private int current;

    private void OnEnable()
    {
        acceleration = Random.Range(minAcceleration, maxAcceeleration);
        speed = Random.Range(minSPeed, maxSpeed);
        startingPosition = transform.localPosition;
    }
  

    void Update()
    {
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }

        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

    }



}
