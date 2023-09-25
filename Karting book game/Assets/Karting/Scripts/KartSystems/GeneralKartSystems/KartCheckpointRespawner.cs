using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartCheckpointRespawner : KartComponet
{
    private Vector3 position;
    private Quaternion rotation;
    void Start()
    {
        SaveTransform(transform);
    }
    public void SaveTransform(Transform checkpoint)
    {
        position = checkpoint.position;
        rotation = checkpoint.rotation;
    }
    public void RespawnKart()
    {
        transform.position = position;
        transform.rotation = rotation;
        kart.Rigidbody.velocity = Vector3.zero;
        kart.DriftSparkVFX.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint")) SaveTransform(other.transform);
    }
}
