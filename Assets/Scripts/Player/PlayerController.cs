using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static PlayerInput _playerInput;

    public static float Movement => _playerInput.actions["Movement"].ReadValue<float>();

    private void Awake() => _playerInput = FindObjectOfType<PlayerInput>();
}
