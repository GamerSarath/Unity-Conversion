using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LuckyCards_Cards : MonoBehaviour, IPointerClickHandler
{
    public LuckyCards_Cards card;
    public int indexNumber;
    public int rowNumber;
    public int colNumber;
    public LuckyCards_CardType cardType;
    public string cardName;
    public int betAmount;
    public bool isSelected;
    //[SerializeField] int selectedCard;
    // Start is called before the first frame update
    private void Awake()
    {
        card= this;
    }
    private void Start()
    {
        isSelected= false;
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            // selectedCard = this.indexNumber;
            LuckyCards_GameController.instance.selectedCard = indexNumber;
            RightClickFunction();

        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(LuckyCards_GameController.instance.mobileInput)
            {
                isSelected = !isSelected; ;
                if (!isSelected)
                {
                    LuckyCards_GameController.instance.selectedCard = indexNumber;
                    RightClickFunction();
                }
                else
                {
                    LuckyCards_GameController.instance.selectedCards.Add(card);
                }
            }
            else
            {
                LuckyCards_GameController.instance.selectedCard = indexNumber;

                LuckyCards_GameController.instance.selectedCards.Add(card);

                LuckyCards_GameController.instance.totalBetValue += LuckyCards_GameController.instance.chipStorage;
                LuckyCards_GameController.instance.totalBetText.text = LuckyCards_GameController.instance.totalBetValue.ToString();

            }

            /*selectedCard = this.indexNumber;
             LuckyCards_GameController.instance.selectedCards.Add(card);

             LeftClickFuntion();*/
        }


    }
    void RightClickFunction()
    {

        Debug.Log("clicked on right");

        for (int i = LuckyCards_GameController.instance.selectedCards.Count - 1; i >= 0; i--)

        {

            if (LuckyCards_GameController.instance.selectedCard == 0)
            {
                LuckyCards_GameController.instance.RemoveJackHeart();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 1)
            {
                LuckyCards_GameController.instance.RemoveJackSpades();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 2)
            {
                LuckyCards_GameController.instance.RemoveJackDiamonds();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 3)
            {
                LuckyCards_GameController.instance.RemoveJackClubs();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 4)
            {
                LuckyCards_GameController.instance.RemoveQueenHearts();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 5)
            {
                LuckyCards_GameController.instance.RemoveQueenSpades();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 6)
            {
                LuckyCards_GameController.instance.RemoveQueenDiamonds();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 7)
            {
                LuckyCards_GameController.instance.RemoveQueenClubs();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 8)
            {
                LuckyCards_GameController.instance.RemoveKingHearts();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 9)
            {
                LuckyCards_GameController.instance.RemoveKingSpades();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 10)
            {
                LuckyCards_GameController.instance.RemoveKingDiamonds();
            }
            else if (LuckyCards_GameController.instance.selectedCard == 11)
            {
                LuckyCards_GameController.instance.RemoveKingClubs();
            }

        }


    }
    /*void LeftClickFuntion()
    {

        Debug.Log("clicked on Left");
        foreach (Cards card in GameController.instance.listedCards)

        {
            if (card.selectedCard == 0)
            {
                //GameController.instance.JackHearts();
            }
            else if (card.selectedCard == 1)
            {

            }
            else if (card.selectedCard == 2)
            {

            }
            else if (card.selectedCard == 3)
            {

            }
            else if (card.selectedCard == 4)
            {

            }
            else if (card.selectedCard == 5)
            {

            }
            else if (card.selectedCard == 6)
            {

            }
            else if (card.selectedCard == 7)
            {

            }
            else if (card.selectedCard == 8)
            {

            }
            else if (card.selectedCard == 9)
            {

            }
            else if (card.selectedCard == 10)
            {

            }
            else if (card.selectedCard == 11)
            {

            }

        }
    }*/


}
    public enum LuckyCard_CardType
    {

        JackHearts, QueenHearts, KingHearts,
        JackSpades, QueenSpades, KingSpades,
        JackDiamonds, QueenDiamonds, KingDiamonds,
        JackClubs, QueenClubs, KingClubs


    }
