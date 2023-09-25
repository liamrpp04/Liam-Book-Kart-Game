using KartGame.AI;
using UnityEngine;

public class AddCheckPointsHelper
{
    public static void AddCheckPoints(DebugCheckpointRay m_DebugCheckpointRay)
    {

        m_DebugCheckpointRay.Colliders = m_DebugCheckpointRay.GetComponentsInChildren<Collider>();
        var kartAgents = GameObject.FindObjectsOfType<KartAgent>();

        foreach (KartAgent agent in kartAgents)
        {
            agent.Colliders = m_DebugCheckpointRay.Colliders;
        }
    }
}