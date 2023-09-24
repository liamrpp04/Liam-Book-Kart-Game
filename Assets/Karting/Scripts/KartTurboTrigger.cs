using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KartTurboTrigger : TargetTriggerEnter
{
    [Header("* Turbo props")]
    [SerializeField] private float boostForce = 20;
    //[SerializeField] private UnityEvent<KartTurbo> OnTrigger;

    [SerializeField] private Transform directional;

    private void Start()
    {
        OnTargetTriggerEnter.AddListener(other => {
            KartTurbo kartTurbo = other.GetComponentInParent<KartTurbo>();
            //OnTrigger?.Invoke(kartTurbo);
            Turbo(kartTurbo);
        });
    }

    private void OnDrawGizmos()
    {
        if (directional == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(directional.position, 1f);
        Gizmos.DrawLine(transform.position, directional.position);
    }

    public void Turbo(KartTurbo kartTurbo)
    {
        Vector3 dir = (directional.position - transform.position).normalized;
        kartTurbo.Turbo(dir * boostForce);
    }
}
