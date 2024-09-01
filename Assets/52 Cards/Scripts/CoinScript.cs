using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] int coinAmount;
    public void OnClickCoin()
    {
        CardsGameManager.instance.currentBetAmount = coinAmount;
    }
}
