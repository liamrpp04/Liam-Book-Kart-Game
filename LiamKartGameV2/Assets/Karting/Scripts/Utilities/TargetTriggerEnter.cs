using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum AfterBHV
{
    None,
    DisableObject,
    DisableCollider
}

public class TargetTriggerEnter : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private AfterBHV afterBhv = AfterBHV.DisableObject;
    public UnityEvent<Collider> OnTargetTriggerEnter;
    public UnityEvent<Collider> OnTargetTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            OnTargetTriggerEnter?.Invoke(other);
            if (afterBhv == AfterBHV.DisableObject)
                gameObject.SetActive(false);
            else if (afterBhv == AfterBHV.DisableCollider)
                gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            OnTargetTriggerExit?.Invoke(other);
        }
    }
}
