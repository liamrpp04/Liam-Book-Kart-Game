using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartOilObstacleActivator : KartComponent
{
    [SerializeField] private GameObject hoseActivatorGo;

    //private Queue<OilObstacle> oilObstaclesQueue= new Queue<OilObstacle>();

    private int timerId;

    MobileControlsHUD mobileControls;

    private bool isActive;

    private void Start()
    {
        mobileControls = MobileControlsHUD.Instance;

        if (hoseActivatorGo == null)
        {
            hoseActivatorGo = transform.Find("OilHoseActivator")?.gameObject;
        }

        hoseActivatorGo?.SetActive(false);
    }

    private void Update()
    {
        if (!kart.GetCanMove()) return;

        if (Input.GetKeyDown(KeyCode.R) || mobileControls.ItemPressedDown)
        {
            if (mobileControls.IsRechargingItem)
                return;

            SFXManager.PlaySound("oilActivator");

            StartActivator();
            mobileControls.RechargeOilItem();
        }
    }

    //public void AddToQueue(OilObstacle oilObstacle)
    //{
    //    oilObstacle.Show();
    //    oilObstaclesQueue.Enqueue(oilObstacle);
    //}

    //private void ClearQueue()
    //{
    //    if (oilObstaclesQueue.Count == 0)
    //        return;

    //    OilObstacle oilObstacle = oilObstaclesQueue.Dequeue();
    //    oilObstacle.Hide(ClearQueue);
    //}

    public void StartActivator()
    {
        if (isActive)
        {
            return;
        }
        isActive = true;

        hoseActivatorGo.SetActive(true);
        timerId = Timer.StartTimer(4.5f, FinishActivator);
    }

    public void FinishActivator()
    {
        if (!isActive)
        {
            return;
        }
        isActive = false;

        Timer.FinishTimer(timerId);
        hoseActivatorGo.SetActive(false);
        //ClearQueue();
    }
}
