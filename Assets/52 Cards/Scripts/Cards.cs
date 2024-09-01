using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[System.Serializable]
public abstract class Cards : MonoBehaviour
{
    public int indexNumber;
    public int rowNumber;
    public int coloumnNumber;
    public LuckyCards_CardType cardType;
    public int cardValue;
    public int betAmount;
    public int BetAmount;
    public bool coloumnSelected;
    public bool rowSelected;
    public bool optedToRemove;
    public string cardString;
    public bool clearBet = false;
    public GameObject currentSprite;
    public abstract void OnSelectCard();

    public abstract void OnDeSelectCard();
    public abstract void OnSelectCardRow();
    public abstract void OnSelectCardColoumn();

    public abstract Sprite SelectCoinSprite();


    public abstract void OnSelectCardRowRemoval(Cards card);
    public abstract void OnSelectCardColoumnRemoval(Cards card);

    public abstract void RemoveAddedCardFromList(Cards card);
}

public enum LuckyCards_CardType
{
    None,
    Club,
    Hearts,
    Diamond,
    Spades

}

