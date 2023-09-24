using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartGroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float maxDistance = 0.5f;
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, maxDistance, groundMask))
        {
            KartCheckpointRespawner checkPointer = GetComponent<KartCheckpointRespawner>();
            if (checkPointer != null)
            {
                checkPointer.RespawnToPosition();
                Debug.Log("RESPAWN");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * maxDistance);
    }
}
