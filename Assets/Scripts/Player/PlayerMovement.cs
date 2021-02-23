using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float gravity = 1;
    [SerializeField] private float jumpForce = 50;
    [SerializeField] private float bottom = -8;
    
    private CharacterController _characterController;
    private bool _jump;
    private bool _doubleJump;
    private float _yVelocity = -1;
    private Transform _transform;
    private PlayerDamage _playerDamage;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerDamage = GetComponent<PlayerDamage>();
        PlayerController.OnJump += () => _jump = true;
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _characterController.Move(new Vector3(Move(), Jump()) * Time.deltaTime);
        if (_transform.position.y < bottom)
            _playerDamage.TakeDamage();
    }

    private float Move() => PlayerController.Movement * speed;

    private float Jump()
    {
        if (_characterController.isGrounded)
        {
            if (_jump)
            {
                _yVelocity = jumpForce;
                _doubleJump = true;
            }
            else
            {
                _yVelocity = -1;
                _doubleJump = false;
            }
        }
        else if (_doubleJump && _jump)
        {
            _yVelocity = jumpForce;
            _doubleJump = false;
        }
        _yVelocity -= gravity;
        _jump = false;
        return _yVelocity;
    }
}
