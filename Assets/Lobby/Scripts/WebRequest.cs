using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public abstract class WebRequest : MonoBehaviour
{
    public string url;


    public abstract void SendWebRequest(); 
}
