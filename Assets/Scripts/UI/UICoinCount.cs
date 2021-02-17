using TMPro;
using UnityEngine;

public class UICoinCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        Coin.OnCoinCollected += coins => text.text = coins.ToString();
    }
}