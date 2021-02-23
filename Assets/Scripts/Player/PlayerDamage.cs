using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public static event Action<int> OnLivesChanged;
    public static event Action OnPlayerDeath;
    public static event Action OnCheckPointUpdated;
    
    [SerializeField] private int lives = 3;

    private Transform _transform;
    private Vector3 _respawnPoint;

    private void Awake()
    {
        _transform = transform;
        _respawnPoint = _transform.position;
    }

    public void TakeDamage()
    {
        lives--;
        OnLivesChanged?.Invoke(lives);
        Respawn();
        if (lives == 0)
            OnPlayerDeath?.Invoke();
    }

    private void Respawn() => _transform.position = _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("CheckPoint"))
            return;
        _respawnPoint = other.transform.position;
        OnCheckPointUpdated?.Invoke();
    }
}