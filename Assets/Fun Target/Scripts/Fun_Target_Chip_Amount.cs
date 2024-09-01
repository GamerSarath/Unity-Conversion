using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun_Target_Chip_Amount : MonoBehaviour
{
    public int chipAmount;
    public void SelectedChipAmount(int chips)
    {
        Fun_Target_Game_Manager.instance.currentBetamount = chips;
    }
}
