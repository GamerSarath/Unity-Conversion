using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeethoRafther_PlayPanelMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
  

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
}
