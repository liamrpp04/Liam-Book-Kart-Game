using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    private Dictionary<int, TimerAction> timerActions = new Dictionary<int, TimerAction>();
    private int countId = 0;

    private void Awake()
    {
        Instance = this;
    }

    public static int StartTimer(float time, Action OnComplete) => Instance.DoStartTimer(time, OnComplete);
    public static bool TimerExists(int id) => Instance.DoTimerExists(id);
    public static void FinishTimer(int id) => Instance.DoFinishTimer(id);

    public int DoStartTimer(float time, Action OnComplete)
    {
        TimerAction timer = new TimerAction();
        timer.Tick(time, OnComplete);
        timerActions.Add(countId, timer);
        countId++;
        return countId - 1;
    }

    public bool DoTimerExists(int id)
    {
        return timerActions.ContainsKey(id);
    }

    public void DoFinishTimer(int id)
    {
        if (!TimerExists(id))
        {
            Debug.LogError("Timer id does not exists");
            return;
        }

        timerActions[id].Stop();
        //timerActions.Remove(id);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TimerAction timer in timerActions.Values)
        {
            if (timer.stopped)
                continue;

            timer.Update();
        }
    }
}

public class TimerAction
{
    public Action onCompleteCallback;
    public float value;
    public bool stopped;

    public void Tick(float time, Action OnComplete)
    {
        value = time;
        onCompleteCallback = OnComplete;
    }

    public void Update()
    {
        if (stopped) return;

        value -= Time.deltaTime;
        if (value <= 0)
        {
            onCompleteCallback?.Invoke();
            stopped = true;
        }
    }

    public void Stop() => stopped = true;
    public void Resume() => stopped = false;
}
