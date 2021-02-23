using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private int coinQuota = 8;
    
    private bool _activatable;
    private CallButton _callButton;

    private void Awake()
    {
        PlayerController.OnActivate += HandleActivate;
        _callButton = GetComponentInChildren<CallButton>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _activatable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _activatable = false;
    }

    private void HandleActivate()
    {
        if (_activatable && Coin.CoinsCollected >= coinQuota)
        {
            _callButton.TurnOn();
        }
    }
}