using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static PlasticPipe.PlasticProtocol.Messages.Serialization.ItemHandlerMessagesSerialization;
using static UnityEditor.PlayerSettings;

public class CheckpointsManager : MonoBehaviour
{
    public static CheckpointsManager Instance;

    private List<CheckpointChecker> checkpointCheckers = new List<CheckpointChecker>();

    public class CheckpointChecker
    {
        public Checkpoint checkpoint;
        public List<KartCheckpointRacePosition> karts = new List<KartCheckpointRacePosition>();

        public void AddKart(KartCheckpointRacePosition kart)
        {
            kart.targetCheckpoint = checkpoint;
            karts.Add(kart);
        }

        public void RemoveKart(KartCheckpointRacePosition kart)
        {
            kart.targetCheckpoint = null;
            karts.Remove(kart);
        }
    }

    private void Awake()
    {
        Instance = this;

        Checkpoint[] checkpoints = GetComponentsInChildren<Checkpoint>();

        for (int i = 0; i < checkpoints.Length; i++)
        {
            CheckpointChecker checker = new CheckpointChecker();
            checker.checkpoint = checkpoints[i];
            checker.karts = new List<KartCheckpointRacePosition>();

            checkpointCheckers.Add(checker);
        }
    }

    private void Update()
    {
        int kartPos = GetKartsCount();

        for (int i = 0; i < checkpointCheckers.Count; i++)
        {
            CheckpointChecker checker = checkpointCheckers[i];
            SortKartsInChecker(checker);

            // Add race pos
            for (int j = 0; j < checker.karts.Count; j++)
            {
                checker.karts[j].racePos = kartPos;
                kartPos--;
                if (kartPos <= 0)
                    return;
            }
        }
    }

    private int GetKartsCount()
    {
        int kartsCount = 0;

        for (int i = 0; i < checkpointCheckers.Count; i++)
        {
            for (int j = 0; j < checkpointCheckers[i].karts.Count; j++)
            {
                kartsCount++;
            }
        }

        return kartsCount;
    }

    public CheckpointChecker GetChecker(Checkpoint checkpoint)
    {
        if (checkpoint == null) return checkpointCheckers[0];

        for (int i = 0; i < checkpointCheckers.Count; i++)
        {
            if (checkpointCheckers[i].checkpoint == checkpoint)
            {
                return checkpointCheckers[i];
            }
        }

        return checkpointCheckers[0];
    }

    public CheckpointChecker GetNextChecker(Checkpoint checkpoint)
    {
        if (checkpoint == null) return checkpointCheckers[0];

        for (int i = 0; i < checkpointCheckers.Count; i++)
        {
            if (checkpointCheckers[i].checkpoint == checkpoint)
            {
                return (i + 1 < checkpointCheckers.Count) ? checkpointCheckers[i + 1] : checkpointCheckers[0];
            }
        }

        return checkpointCheckers[0];
    }

    public void MoveKartToNextChecker(Checkpoint reachedCheckpoint, KartCheckpointRacePosition kart)
    {
        CheckpointChecker currentChecker = GetChecker(kart.targetCheckpoint);
        currentChecker.RemoveKart(kart);

        CheckpointChecker nextChecker = GetNextChecker(reachedCheckpoint);
        nextChecker.AddKart(kart);

    }

    void SortKartsInChecker(CheckpointChecker checker)
    {
        Checkpoint checkpoint = checker.checkpoint;
        List<KartCheckpointRacePosition> karts = checker.karts;

        for (int i = 1; i < karts.Count; i++)
        {
            for (int j = 0; j < karts.Count - i; j++)
            {
                if (Vector3.Distance(karts[j].transform.position, checkpoint.transform.position) < Vector3.Distance(karts[j + 1].transform.position, checkpoint.transform.position))
                {
                    KartCheckpointRacePosition aux = karts[j];
                    karts[j] = karts[j + 1];
                    karts[j + 1] = aux;
                }
            }
        }
    }
}

//[CustomEditor(typeof(CheckpointsManager))]
//public class CheckpointsManagerEditor : UnityEditor.Editor
//{
//    CheckpointsManager lookAtPoint;

//    public void OnEnable()
//    {
//        lookAtPoint = target as CheckpointsManager;
//    }
//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        if (GUILayout.Button("Fill Debug Ray"))
//        {
            
//        }
//        serializedObject.ApplyModifiedProperties();
//    }
//}
