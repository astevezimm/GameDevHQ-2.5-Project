using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ICollectable>().Collect();
        other.gameObject.SetActive(false);
    }
}
