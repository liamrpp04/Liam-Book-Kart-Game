using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObstacle : MonoBehaviour
{
    [SerializeField] private TargetTriggerEnter targetTrigger;
    private void Start()
    {
        targetTrigger.OnTargetTriggerEnter.AddListener(other =>
        {
            KartDamage mudBlocker = other.GetComponentInParent<KartDamage>();
            mudBlocker?.TakeDamage(0.15f);
            StartCoroutine(DestroyBox());
        });
    }

    IEnumerator DestroyBox()
    {
        //gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        foreach (Transform part in transform.GetChild(1))
        {
            Rigidbody rb = part.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)), ForceMode.VelocityChange);
        }

        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
    }

}
