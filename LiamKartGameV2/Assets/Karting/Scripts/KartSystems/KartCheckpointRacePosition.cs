using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartCheckpointRacePosition : KartComponent
{
    [HideInInspector] public int racePos;
    [HideInInspector] public Checkpoint targetCheckpoint;
    [HideInInspector] public int currentLap = 1;

    private void Start()
    {
        CheckpointsManager.Instance.MoveKartToNextChecker(null, this);
    }

    private void Update()
    {
        if (isPlayer) RacePositionHUD.Instance.SetPositionHUD(racePos, currentLap);
    }
}
