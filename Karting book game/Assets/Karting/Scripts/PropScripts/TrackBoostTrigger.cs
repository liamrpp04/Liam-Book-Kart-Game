using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBoostTrigger : MonoBehaviour
{
    [SerializeField] private float BoostMagnitude;
    [SerializeField] private Transform Direction;
    public void ApplyBoost(GameObject kart)
    {
        Vector3 BoostVector = (Direction.position - transform.position).normalized;
        KartBoost kartBoost = kart.GetComponentInParent<KartBoost>();
        if (kartBoost != null)
        {  
            kartBoost.Boost(BoostVector * BoostMagnitude);
        }
    }
    private void OnDrawGizmos()
    {
        if (Direction == null) return;
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(Direction.position, 1);
        Gizmos.DrawLine(transform.position, Direction.position);
    }
}
