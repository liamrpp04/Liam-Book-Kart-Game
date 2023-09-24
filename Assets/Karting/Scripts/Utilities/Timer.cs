using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    private List<TimerAction> timerActions = new List<TimerAction>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (TimerAction timer in timerActions)
        {
            timer.Tick();
        }
    }
}

public class TimerAction
{
    public Action OnComplete;
    float time;
    public float value;
    bool stopped;

    public void Start()
    {

    }

    public void Tick()
    {
        if (stopped) return;

        value -= Time.deltaTime;
        if(value <= 0)
        {

        }
    }

    public void Stop() => stopped = true;
    public void Resume() => stopped = false;
}
