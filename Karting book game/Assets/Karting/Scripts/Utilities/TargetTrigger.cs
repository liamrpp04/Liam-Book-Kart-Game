using UnityEngine.Events;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    public UnityEvent<GameObject> targetTriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            targetTriggerEnter?.Invoke(other.gameObject);
        }
    }
}