using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private Transform _transform;

    private void Awake() => _transform = transform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = _transform;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}