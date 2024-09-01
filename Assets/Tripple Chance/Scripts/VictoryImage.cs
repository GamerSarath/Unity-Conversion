using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VictoryImage : MonoBehaviour
{
    public TMP_Text text;

    private void Awake()
    {
        text = this.transform.GetChild(0).GetComponent<TMP_Text>();
    }
}
