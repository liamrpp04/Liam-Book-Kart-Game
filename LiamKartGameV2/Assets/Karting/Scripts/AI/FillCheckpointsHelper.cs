#if UNITY_EDITOR

using KartGame.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCheckpointsHelper
{
    public static void FillCheckpoints(DebugCheckpointRay debugCheckpointRay)
    {
        debugCheckpointRay.Colliders = debugCheckpointRay.GetComponentsInChildren<Collider>();

        var kartAgents = GameObject.FindObjectsOfType<KartAgent>();

        foreach (var agent in kartAgents)
        {
            agent.Colliders = debugCheckpointRay.Colliders;
        }
    }
}
#endif
