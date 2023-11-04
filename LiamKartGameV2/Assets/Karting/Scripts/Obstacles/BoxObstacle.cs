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
            KartDamage kartDamage = other.GetComponentInParent<KartDamage>();
            if (kartDamage.isPlayer)
                SFXManager.PlaySound("boxCrash");
            kartDamage?.TakeDamage(0f);
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
            rb.AddForce(new Vector3(Random.Range(-1, 1f), Random.Range(0, 1f), Random.Range(-1f, 1f)) * 8f, ForceMode.VelocityChange);
        }

        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
    }

}
