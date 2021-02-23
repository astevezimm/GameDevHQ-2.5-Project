using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public static event Action<int> OnCoinCollected; 
    
    public static int CoinsCollected { get; private set; }
    
    public void Collect()
    {
        CoinsCollected++;
        OnCoinCollected?.Invoke(CoinsCollected);
    }
}
