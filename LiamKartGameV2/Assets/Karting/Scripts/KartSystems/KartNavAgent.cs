using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KartNavAgent : KartComponent, IInput
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private KartCheckpointRacePosition checker;
    public InputData GenerateInput()
    {
        navAgent.SetDestination(checker.targetCheckpoint.transform.position);

        //Vector3 nextPos = navAgent.nextPosition;
        //Debug.Log("next pos " + nextPos);

        //Vector3 dir = nextPos - transform.position;

        //Debug.Log("Original dir: " + dir);
        //Debug.Log("Original dir z: " + dir.z);

        //Vector3 relativeDir = transform.InverseTransformDirection(nextPos - transform.position);
        //Debug.Log("relative : " + relativeDir);

        ////Vector3 targetDir = Quaternion.Inverse(transform.rotation) * (pos - transform.position);
        ////Debug.Log("Target Dir: " + targetDir);
        return new InputData
        {
            //Accelerate = relativeDir.z > 0,
            //Brake = relativeDir.z < 0,
            //TurnInput = relativeDir.x
        };
    }

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        checker = GetComponent<KartCheckpointRacePosition>();

        //navAgent.isStopped = true;

    }

    private void Update()
    {
    }
}
