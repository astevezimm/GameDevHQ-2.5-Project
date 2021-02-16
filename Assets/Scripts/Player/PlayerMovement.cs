using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    
    private CharacterController _characterController;
    
    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void Update()
    {
        float movement = PlayerController.Movement * speed * Time.deltaTime;
        _characterController.Move(Vector3.right * movement);
    }
}
