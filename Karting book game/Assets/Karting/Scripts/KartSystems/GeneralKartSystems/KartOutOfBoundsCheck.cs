using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartOutOfBoundsCheck : KartComponet
{
    [SerializeField] private LayerMask OutOfBoundsLayerMask;
    [SerializeField] private float maxRayLength = 0.1f;
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, maxRayLength, OutOfBoundsLayerMask))
        {
            KartCheckpointRespawner respawner = GetComponent<KartCheckpointRespawner>();
            respawner?.RespawnKart();
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * maxRayLength);
    }
}
