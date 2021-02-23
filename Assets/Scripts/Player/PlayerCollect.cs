using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable == null)
            return;
        collectable.Collect();
        other.gameObject.SetActive(false);
    }
}
