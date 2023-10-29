using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class OilObstacle : MonoBehaviour
{
    [SerializeField] private TargetTriggerEnter activatorTrigger;
    [SerializeField] private TargetTriggerEnter targetTrigger;
    [SerializeField] private GameObject oilObj;

    private bool isShown;
    private int timerId;

    private List<KartOilObstacleSlider> kartsInObstacle = new List<KartOilObstacleSlider>();

    private void Start()
    {
        //activatorTrigger.OnTargetTriggerEnter.AddListener(other => {
        //    KartOilObstacleActivator activator = other.GetComponentInParent<KartOilObstacleActivator>();
        //    activator.AddToQueue(this);
        //});
        //render.material = new Material(render.material);

        //Color original = render.material.color;
        //render.material.color = new Color(original.r, original.g, original.b, 0);
        //render.transform.position = render.transform.position - Vector3.up * 0.2f;
        oilObj.SetActive(false);

        activatorTrigger.OnTargetTriggerExit.AddListener(other =>
        {
            Debug.Log("ACTIVATE");
            //KartOilObstacleActivator activator = other.GetComponentInParent<KartOilObstacleActivator>();
            //activator.AddToQueue(this);
            Show();
        });

        targetTrigger.OnTargetTriggerEnter.AddListener(other =>
        {
            KartOilObstacleSlider mudSliderr = other.GetComponentInParent<KartOilObstacleSlider>();
            mudSliderr.StartSlide();
            kartsInObstacle.Add(mudSliderr);
        });

        targetTrigger.OnTargetTriggerExit.AddListener(other =>
        {
            KartOilObstacleSlider mudSliderr = other.GetComponentInParent<KartOilObstacleSlider>();
            mudSliderr.StopSlide();
            kartsInObstacle.Remove(mudSliderr);

        });
    }

    public void Show()
    {
        if (isShown)
            return;

        isShown = true;
        oilObj.gameObject.SetActive(true);

        timerId = Timer.StartTimer(4f, Hide);
        //render.material.DOFade(1f, 0.7f);
        //render.transform.DOMoveY(render.transform.position.y + 0.2f, 0.7f);
    }

    public void Hide()
    {
        if (!isShown)
            return;

        Timer.FinishTimer(timerId);

        isShown = false;

        oilObj.SetActive(false);

        // The rest
        for (int i = kartsInObstacle.Count - 1; i >= 0 ; i--)
        {
            var mudSlider = kartsInObstacle[i];
            mudSlider.StopSlide();
            kartsInObstacle.Remove(mudSlider);
        }
        //render.material.DOFade(0f, 0.7f).OnComplete(() => {
        //render.transform.DOMoveY(render.transform.position.y - 0.2f, 0.7f).OnComplete(() =>
        //{
        //    OnComplete?.Invoke();
        //    render.transform.parent.gameObject.SetActive(false);
        //});
    }
}
