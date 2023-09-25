using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroRechargeItem : MonoBehaviour
{
    [Range(0,100)] [SerializeField] private int rechargePercent = 25;
    [SerializeField] private float disabledTime = 4f;
    public void OnCollected(GameObject kart)
    {
        kart.GetComponentInParent<KartNitro>()?.RechargeNitro(rechargePercent);
        SetActivation(false);
        StartCoroutine(CEnableItem());

    }
    IEnumerator CEnableItem()
    {
        yield return new WaitForSeconds(disabledTime);
        SetActivation(true);
    }
    void SetActivation(bool activator)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(activator);
        }
    }
}