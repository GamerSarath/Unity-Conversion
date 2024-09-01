using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Fun_Target_Coin_Manager : MonoBehaviour, IPointerClickHandler
{
    public int index;
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Fun_Target_Game_Manager.instance.betAmount[index] = 0;
            Fun_Target_Ui_Manager.instance.betAmountsText[index].text =Fun_Target_Game_Manager.instance.betAmount[index].ToString();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            Fun_Target_Game_Manager.instance.AddBet(index);
        }
    }
}
