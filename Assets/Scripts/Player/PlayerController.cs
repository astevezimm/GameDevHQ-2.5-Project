using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static PlayerInput _playerInput;

    public static float Movement => _playerInput.actions["Movement"].ReadValue<float>();

    public static event Action OnJump;
    public static event Action OnActivate;

    private void Awake() => _playerInput = FindObjectOfType<PlayerInput>();

    public void Jump(InputAction.CallbackContext context) => PerformAction(context, OnJump);
    
    public void Activate(InputAction.CallbackContext context) => PerformAction(context, OnActivate);

    private void PerformAction(InputAction.CallbackContext context, Action action)
    {
        if (context.performed)
            action?.Invoke();
    }
}
