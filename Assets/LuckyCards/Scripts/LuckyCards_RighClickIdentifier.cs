using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LuckyCards_RighClickIdentifier : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onRightClick;
    float clearValue=0;
     LuckyCards_GameController controller= new LuckyCards_GameController();
    /* public void OnPointerClick(PointerEventData eventData)
     {
         if (eventData.button == PointerEventData.InputButton.Right)
         {
             onRightClick?.Invoke();
         }

     }*/
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightFun();

        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("clicked leftButton");
        }

        
    }
    void RightFun()
    {

        Debug.Log("clicked on right");
      //  controller.betOnJackHearts = clearValue;
        // Destroy(controller.jackHeartChip);
    }


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}


