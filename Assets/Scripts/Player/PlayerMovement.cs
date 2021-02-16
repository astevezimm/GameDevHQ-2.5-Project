using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float gravity = 1;
    
    private CharacterController _characterController;
    
    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void Update()
    {
        Vector3 velocity = Vector3.right * (PlayerController.Movement * speed);
        if (!_characterController.isGrounded)
            velocity.y -= gravity;
        _characterController.Move(velocity * Time.deltaTime);
    }
}
