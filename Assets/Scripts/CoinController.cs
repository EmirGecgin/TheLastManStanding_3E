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
        SFXManager.instance.PlaySfxPitched(2);
    }

    public void DropCoin(Vector3 position,int value)
    {
        CoinPickup newCoin = Instantiate(coin, position + new Vector3(0.5f, 0.4f, 0f), Quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }

    public void SpendCoin(int coinsToSpend)
    {
        currentCoins -= coinsToSpend;
        
        UIController.Instance.UpdateCoins();
    }
}
