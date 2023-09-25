using UnityEngine;
public class KartNitro : KartComponet
{
    [SerializeField] private float maxNitroValue = 100;
    [SerializeField] private float depletionTime = 4;
    [SerializeField] private float RechargeTimeTo100 = 4;
    [SerializeField] private float topSpeedMultiplier = 2;
    [SerializeField] private float AccelerationMultiplier = 2.6f;
    private float currentNitroValue;
    private float kartTopSpeed;
    private float kartAcceleration;
    private float depletionRate;
    private float rechargeRate;
    private float rechargedNitroValue;
    private bool isNitroRecharging;
    void Start()
    {
        currentNitroValue = maxNitroValue;
        UpdateKartNitroUI();
    }

    void Update()
    {
        if (!kart.CanMove) return;
        if (!isPlayer) return;
        if (isNitroRecharging)
        {
            rechargeRate = maxNitroValue / RechargeTimeTo100 * Time.deltaTime;
            currentNitroValue += rechargeRate;
            if(currentNitroValue >= rechargedNitroValue)
            {
                currentNitroValue = rechargedNitroValue;
                isNitroRecharging = false;
            }
            UpdateKartNitroUI();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space)) StartNitro();
        else if (Input.GetKey(KeyCode.Space)) ApplyNitro();
        else if (Input.GetKeyUp(KeyCode.Space)) StopNitro();
    }
    public void RechargeNitro(int RechargePercent)
    {
        StopNitro();
        rechargedNitroValue = (isNitroRecharging? rechargedNitroValue : currentNitroValue) + RechargePercent / 100f * maxNitroValue;
        if (rechargedNitroValue > maxNitroValue) rechargedNitroValue = maxNitroValue;
        isNitroRecharging = true;
        //print(rechargedNitroValue);
    }
    public void StopNitro()
    {
        if (!kart.isUsingNitro) return;
        kart.baseStats.TopSpeed = kartTopSpeed;
        kart.baseStats.Acceleration = kartAcceleration;
        kart.isUsingNitro = false;
    }
    public void StartNitro()
    {
        kartTopSpeed = kart.baseStats.TopSpeed;
        kartAcceleration = kart.baseStats.Acceleration;
        kart.isUsingNitro = true;
    }
    public void ApplyNitro()
    {
        if (!kart.isUsingNitro)
        {
            StartNitro();
            return;
        }
        if (currentNitroValue > 0)
        {
            kart.baseStats.TopSpeed = kartTopSpeed * topSpeedMultiplier;
            kart.baseStats.Acceleration = kartAcceleration * AccelerationMultiplier;
            depletionRate = maxNitroValue / depletionTime;
            currentNitroValue -= depletionRate * Time.deltaTime;
            if (currentNitroValue <= 0)
            {
                currentNitroValue = 0;
                StopNitro();
            }
            UpdateKartNitroUI();
        }
    }
    void UpdateKartNitroUI()
    {
        if (!isPlayer) return;
        NitroUI.Instance?.UpdateNitroUI(currentNitroValue, maxNitroValue);
    }
}
