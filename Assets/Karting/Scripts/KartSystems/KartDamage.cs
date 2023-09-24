using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartDamage : KartComponent
{
    public void TakeDamage(float delay = 0f)
    {
        StartCoroutine(IDamage(delay));
    }

    IEnumerator IDamage(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        kart.Rigidbody.velocity = Vector3.zero;
        kart.Rigidbody.AddForce(Vector3.up * 4, ForceMode.VelocityChange);
        kart.Rigidbody.AddTorque(Vector3.down * 4, ForceMode.VelocityChange);
    }
}
