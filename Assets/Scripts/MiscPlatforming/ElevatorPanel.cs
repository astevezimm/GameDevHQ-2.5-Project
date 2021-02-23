using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
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
        if (_activatable)
        {
            _callButton.TurnOn();
        }
    }
}