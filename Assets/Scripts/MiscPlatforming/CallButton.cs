using UnityEngine;

public class CallButton : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake() => _renderer = GetComponent<Renderer>();

    public void TurnOn() => _renderer.material.color = Color.green;
    public void TurnOff() => _renderer.material.color = Color.red;
}