using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : Cards, IPointerClickHandler
{
    public Cards card;
    [SerializeField] Sprite currentCoinSprite;
   
    [SerializeField]GameObject coinImagePrefab;
    [SerializeField] int yOffset;
    private void Start()
    {
        card = GetComponent<Card>();

    }

   
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnDeSelectCard();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnSelectCard();
        }
    }

    public override void OnSelectCard()
    {
        card.betAmount += CardsGameManager.instance.currentBetAmount;
        CardsGameManager.instance.totalBetTaken = CardsGameManager.instance.totalBetTaken + CardsGameManager.instance.currentBetAmount;
        CardsUIManager.instance.UpdateTotalBetAmount(CardsGameManager.instance.totalBetTaken);
        if (currentSprite == null)
        {
            currentSprite = Instantiate(coinImagePrefab, gameObject.transform);
            currentSprite.transform.localPosition = new Vector3(0, yOffset, 0);
            currentSprite.GetComponent<Image>().sprite = SelectCoinSprite();
            
        }
        else
        {
            currentSprite.GetComponent<Image>().sprite = SelectCoinSprite();

        }
        if (!CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Contains(card))
        {
            CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Add(card);
        }
    }

    public override void OnSelectCardRow()
    {
        
        if (!CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Contains(card))
        {
            CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Add(card);
            card.betAmount += CardsGameManager.instance.currentBetAmount;
            CardsGameManager.instance.totalBetTaken += card.betAmount;
            CardsUIManager.instance.UpdateTotalBetAmount(CardsGameManager.instance.totalBetTaken);
        }

        if (currentSprite == null)
        {
            currentSprite = Instantiate(coinImagePrefab, gameObject.transform);
            currentSprite.transform.localPosition = new Vector3(0, yOffset, 0);
            currentSprite.GetComponent<Image>().sprite = SelectCoinSprite();

        }
       
    }

    public override void OnSelectCardColoumn()
    {

        if (!CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Contains(card))
        {
            CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Add(card);
            card.betAmount += CardsGameManager.instance.currentBetAmount;
            CardsGameManager.instance.totalBetTaken += card.betAmount;
            CardsUIManager.instance.UpdateTotalBetAmount(CardsGameManager.instance.totalBetTaken);
            card.coloumnSelected = true;
        }
        if (currentSprite == null)
        {
            currentSprite = Instantiate(coinImagePrefab, gameObject.transform);
            currentSprite.transform.localPosition = new Vector3(0, yOffset, 0);
            currentSprite.GetComponent<Image>().sprite = SelectCoinSprite();
        }
        
    }

    public override void OnSelectCardColoumnRemoval(Cards card)
    {
        if(currentSprite != null)
        {
            DestroyCurrentCoinSprite();
           // card.betAmount = 0;
            RemoveAddedCardFromList(card);
        }
    }

    public override void OnSelectCardRowRemoval(Cards card)
    {
        if (currentSprite != null)
        {
            DestroyCurrentCoinSprite();
            card.betAmount = 0;
            RemoveAddedCardFromList(card);
        }
    }
    public override void OnDeSelectCard()
    {
        OnCardClearance();

    }

    void OnCardClearance()
    {
        if(!clearBet)
        {
            CardsGameManager.instance.totalBetTaken -= card.betAmount;
            CardsUIManager.instance.UpdateTotalBetAmount(CardsGameManager.instance.totalBetTaken);
         //   card.betAmount = 0;
        }
       
       
        RemoveAddedCardFromList(this);
        DestroyCurrentCoinSprite();
        clearBet = false;
    }

    public override Sprite SelectCoinSprite()
    {
    
        if (card.betAmount >= 5 && card.betAmount < 10)
        {
           // DestroyCurrentCoinSprite();
            currentCoinSprite = CardsGameManager.instance.coinSprite[0];
        }
        if (card.betAmount >= 10 && card.betAmount < 50)
        {
            currentCoinSprite = CardsGameManager.instance.coinSprite[1];
        }
        if (card.betAmount >= 50 && card.betAmount < 100)
        {
            currentCoinSprite = CardsGameManager.instance.coinSprite[2];
        }
        if (card.betAmount >= 100 && card.betAmount < 200)
        {
            
            currentCoinSprite = CardsGameManager.instance.coinSprite[3];
        }
        if (card.betAmount >= 200 && card.betAmount < 500)
        {
            currentCoinSprite = CardsGameManager.instance.coinSprite[4];
        }
        if (card.betAmount >= 500 && card.betAmount < 1000)
        {
            currentCoinSprite = CardsGameManager.instance.coinSprite[5];
        }
        if (card.betAmount >= 1000)
        {
            currentCoinSprite = CardsGameManager.instance.coinSprite[6];
        }
        return currentCoinSprite;
    }

    void DestroyCurrentCoinSprite()
    {
        Destroy(currentSprite);
    }

    public override void RemoveAddedCardFromList(Cards card)
    {
        CardsGameManager.instance.GetComponent<CardFunctions>().selectedCards.Remove(card);


    }


}
