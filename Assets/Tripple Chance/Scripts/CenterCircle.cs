using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCircle : MonoBehaviour
{
    public int rotateSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(!GameManager.Instance.spinWheelOne.GetComponent<Rigidbody2D>().IsSleeping())
        {
            this.transform.Rotate(new Vector3(0,0, rotateSpeed * Time.deltaTime));
        }
    }
}
