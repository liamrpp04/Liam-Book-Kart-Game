using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetTriggerEnter))]
public class NitroItem : MonoBehaviour
{
    // Fadeeee
    [Range(0, 1)]
    [SerializeField] private float recoverValue = 0.2f;

    bool waiting = false;
    private void Start()
    {
        GetComponent<TargetTriggerEnter>().OnTargetTriggerEnter.AddListener((Collider kartCollider) =>
        {
            if (waiting) return;

            KartNitro kartNitro = kartCollider.GetComponentInParent<KartNitro>();
            kartNitro.RecoverNitro(recoverValue);

            transform.GetChild(0).gameObject.SetActive(false);
            waiting = true;

            StartCoroutine(CEnableAfterTime());
        });
    }

    IEnumerator CEnableAfterTime()
    {
        yield return new WaitForSeconds(3.5f);
        transform.GetChild(0).gameObject.SetActive(true);
        waiting = false;
    }
}
