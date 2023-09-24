using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetTriggerEnter))]
public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TargetTriggerEnter>().OnTargetTriggerEnter.AddListener((Collider other) => {
            KartCheckpointRespawner checkpointRespawner = other.GetComponentInParent<KartCheckpointRespawner>();
            checkpointRespawner?.SavePosition(transform);

            KartCheckpointRacePosition kartRacePosition = other.GetComponentInParent<KartCheckpointRacePosition>();
            CheckpointsManager.Instance.MoveKartToNextChecker(this, kartRacePosition);
        });
    }

}
