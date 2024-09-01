using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeethoRafther_Chips : MonoBehaviour
{
    public int chipAmount;



    public void SelectChipAmount(int chips)
    {
        JeethoRafther_Gamemanager.instance.currentBetamount = chips;
    }
}
