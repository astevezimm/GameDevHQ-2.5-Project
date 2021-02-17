using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public static event Action<int> OnCoinCollected; 
    
    private static int _coinsCollected;
    
    public void Collect()
    {
        _coinsCollected++;
        OnCoinCollected?.Invoke(_coinsCollected);
    }
}
