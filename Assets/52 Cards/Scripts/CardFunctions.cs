using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class CardFunctions : MonoBehaviour
{
    public List<Cards> selectedCards;
    public List<Cards> repeatList = new List<Cards>();
    public List<Cards> bettakenList = new List<Cards>();
    public List<Cards> advanceList = new List<Cards>();
    public  Cards[] listedCards;
    public  int selectedCardsCount;
    [SerializeField] GameObject[] coloumnButtons;
    [SerializeField] GameObject[] coloumnRemovalButtons;
    [SerializeField] GameObject[] rowButtons;
    [SerializeField] GameObject[] rowRemovalButtons;
    public void SelectCardRow(int rownumber)
    {
        foreach(var card in listedCards)
        {
            if(card.rowNumber == rownumber)
            {
                card.OnSelectCardRow();
                rowButtons[rownumber].SetActive(false);
                rowRemovalButtons[rownumber].SetActive(true);
            }
        }
    }

    public void SelectCardColoumn(int coloumnnumber)
    {
        foreach (var card in listedCards)
        {
            if (card.coloumnNumber == coloumnnumber)
            {
                card.OnSelectCardColoumn();
                coloumnButtons[coloumnnumber].SetActive(false);
                coloumnRemovalButtons[coloumnnumber].SetActive(true);
            }
        }
      //  equivalentList = selectedCards;
    }
    public void RemoveColoumn(int coloumnnumber)
    {
        Debug.Log("Calling remove coloumn method");
       // equivalentList = selectedCards;
        for(int i = selectedCards.Count - 1; i >= 0  ; i--)
        {
            Debug.Log("i is " + i );
            if (selectedCards[i].coloumnNumber == coloumnnumber)
            {
                Debug.Log("i is " + i + " card coloumn number is " +  selectedCards[i].coloumnNumber);
                coloumnRemovalButtons[coloumnnumber].SetActive(false);
                coloumnButtons[coloumnnumber].SetActive(true);
                CardsGameManager.instance.totalBetTaken -= selectedCards[i].betAmount;
                CardsUIManager.instance.UpdateTotalBetAmount(CardsGameManager.instance.totalBetTaken);
                selectedCards[i].OnSelectCardColoumnRemoval(selectedCards[i]);


            }
        }
        //equivalentList = selectedCards;
      
    }

    public void RemoveRow(int rownumber)
    {
        
        for (int i = selectedCards.Count - 1; i >= 0; i--)
        {
            if (selectedCards[i].rowNumber == rownumber)
            {
                CardsGameManager.instance.totalBetTaken -= selectedCards[i].betAmount;
                CardsUIManager.instance.UpdateTotalBetAmount(CardsGameManager.instance.totalBetTaken);
                selectedCards[i].OnSelectCardRowRemoval(selectedCards[i]);
                rowRemovalButtons[rownumber].SetActive(false);
                rowButtons[rownumber].SetActive(true);
            }
        }
       
    }
}
