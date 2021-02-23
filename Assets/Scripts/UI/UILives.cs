using TMPro;
using UnityEngine;

public class UILives : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        PlayerDamage.OnLivesChanged += lives => text.text = lives.ToString();
    }
}
