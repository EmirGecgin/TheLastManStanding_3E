using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int currentCoins;

    public CoinPickup coin;

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        
        UIController.Instance.UpdateCoins();
    }

    public void DropCoin(Vector3 position,int value)
    {
        CoinPickup newCoin = Instantiate(coin, position + new Vector3(0.2f, 0.1f, 0f), Quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }
}
