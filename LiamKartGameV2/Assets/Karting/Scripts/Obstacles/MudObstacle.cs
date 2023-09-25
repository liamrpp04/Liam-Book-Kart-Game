using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class MudObstacle : MonoBehaviour
{
    [SerializeField] private TargetTriggerEnter targetTrigger;
    [HideInInspector] public bool hasPlayer;
    private void Start()
    {
        targetTrigger.OnTargetTriggerEnter.AddListener(other =>
        {
            KartMudBlocker mudBlocker = other.GetComponentInParent<KartMudBlocker>();
            mudBlocker?.Block(this);
        });
    }

}
