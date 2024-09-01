using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JeethoRafther_BetButton : MonoBehaviour,IPointerClickHandler
{
    public int index;
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //On Deselect - fully clearthe particular horse bet
            JeethoRafther_Gamemanager.instance.betAmount[index] = 0;
            JeethoRafther_UIManager.instance.betAmountsText[index].text = JeethoRafther_Gamemanager.instance.betAmount[index].ToString();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            //On Select - Gamemanager array bet amount add
            Debug.Log("Clicked on left button");
           
            JeethoRafther_Gamemanager.instance.AddHorseBet(index);


        }
    }
}
