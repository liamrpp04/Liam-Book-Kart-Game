using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilObstacle : MonoBehaviour
{
    [SerializeField] private TargetTriggerEnter targetTrigger;

    private void Start()
    {
        targetTrigger.OnTargetTriggerEnter.AddListener(other =>
        {
            KartMudSlider mudSliderr = other.GetComponentInParent<KartMudSlider>();
            mudSliderr.StartSlide();
        });

        targetTrigger.OnTargetTriggerExit.AddListener(other =>
        {
            KartMudSlider mudSliderr = other.GetComponentInParent<KartMudSlider>();
            mudSliderr.StopSlide();
        });
    }
}
