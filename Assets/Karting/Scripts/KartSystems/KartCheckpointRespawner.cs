using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartCheckpointRespawner : KartComponent
{
    private Vector3 position;
    private Vector3 eulerAngles;

    private void Start()
    {
        SavePosition(transform);
    }

    public void SavePosition(Transform checkpoint)
    {
        position = checkpoint.position;
        eulerAngles = checkpoint.eulerAngles;
    }

    public void RespawnToPosition()
    {
        transform.position = position;
        transform.eulerAngles = eulerAngles;
        kart.Rigidbody.velocity = Vector3.zero;
        kart.DriftSparkVFX.Stop();

    }
}
