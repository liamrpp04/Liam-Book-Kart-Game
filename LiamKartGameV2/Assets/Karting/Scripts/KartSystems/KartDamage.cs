using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartDamage : KartComponent
{
    [SerializeField] private Animator kartVisuaAnim;

    private void Start()
    {
        if (kartVisuaAnim == null)
            kartVisuaAnim = transform.Find("KartVisual").GetComponent<Animator>();
    }

    public void TakeDamage(float delay = 0f)
    {
        StartCoroutine(IDamage(delay));
    }

    IEnumerator IDamage(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        kart.SetCanMove(false);
        kart.Rigidbody.velocity = Vector3.zero;
        kart.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        // Stop nitro if used
        GetComponent<KartNitro>()?.StopNitro();

        kartVisuaAnim.SetTrigger("Crush");

        yield return new WaitForSeconds(0.5f);
        kart.SetCanMove(true);
        kart.Rigidbody.constraints = RigidbodyConstraints.None;

        //kart.Rigidbody.AddForce(Vector3.up * 4, ForceMode.VelocityChange);
        //kart.Rigidbody.AddTorque(Vector3.down * 4, ForceMode.VelocityChange);
    }
}
