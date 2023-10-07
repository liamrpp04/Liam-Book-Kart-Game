using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartNitro : KartComponent
{
    [SerializeField] private float maxNitroValue = 100;
    [SerializeField] private float wasteDelta = 10;
    [SerializeField] private float topSpeedMultiplier = 2f;
    [SerializeField] private float accelerationMultiplier = 2.5f;
    [SerializeField] private GameObject[] effects;

    // Recharge
    [SerializeField] private float fullRechargeTime = 4f;
    private float rechargedNitroValue;
    bool isRecharging;

    private float nitroValue;

    float baseTopSpeed;
    float baseAcceleration;

    MobileControlsHUD mobileControls;

    // Start is called before the first frame update
    void Start()
    {
        mobileControls = MobileControlsHUD.Instance;

        nitroValue = 0;
        UpdateNitroHUD();

        SetActiveEffect(false);

    }

    public void RecoverNitro(float part = 1f)
    {
        //float recoverValue = Mathf.Lerp(0, maxNitroValue, part);
        //nitroValue += recoverValue;
        //if (nitroValue > maxNitroValue) nitroValue = maxNitroValue;

        //UpdateNitroHUD();

        StopNitro();

        float recoverValue = Mathf.Lerp(0, maxNitroValue, part);

        rechargedNitroValue = (isRecharging ? rechargedNitroValue : nitroValue) + recoverValue;
        if (rechargedNitroValue > maxNitroValue) rechargedNitroValue = maxNitroValue;

        isRecharging = true;
    }

    void UpdateNitroHUD()
    {
        if (isPlayer) NitroHUD.Instance.SetNitroValueHUD(nitroValue, maxNitroValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (!kart.GetCanMove()) return;

        if (isRecharging)
        {
            float delta = (maxNitroValue / fullRechargeTime) * Time.deltaTime;
            nitroValue += delta;
            if(nitroValue >= rechargedNitroValue)
            {
                nitroValue = rechargedNitroValue;
                isRecharging = false;
            }
            UpdateNitroHUD();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || mobileControls.NitroPressedDown)
        {
            StartNitro();
        }
        else if (Input.GetKey(KeyCode.Space) || mobileControls.NitroIsPressed)
        {
            ApplyNitro();
        }
        else if (Input.GetKeyUp(KeyCode.Space) || mobileControls.NitroPressedUp)
        {
            StopNitro();
        }
    }

    public void StartNitro()
    {
        if (kart.using_nitro) return;

        if (nitroValue <= 0) return;

        baseTopSpeed = kart.baseStats.TopSpeed;
        baseAcceleration = kart.baseStats.Acceleration;

        //
        kart.using_nitro = true;
        kart.baseStats.TopSpeed = baseTopSpeed * topSpeedMultiplier;
        kart.baseStats.Acceleration = baseAcceleration * accelerationMultiplier;
        //
        SetActiveEffect(true);
    }

    private void ApplyNitro()
    {
        if (!kart.using_nitro) {
            StartNitro();
            return;
        }

        if (nitroValue > 0)
        {
            nitroValue -= wasteDelta * Time.deltaTime;

            if (nitroValue <= 0)
            {
                nitroValue = 0;
                StopNitro();
            }
            UpdateNitroHUD();
        }
    }

    public void StopNitro()
    {
        if (!kart.using_nitro) return;

        kart.baseStats.TopSpeed = baseTopSpeed;
        kart.baseStats.Acceleration = baseAcceleration;
        kart.using_nitro = false;
        //
        SetActiveEffect(false);

    }

    void SetActiveEffect(bool active)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            var effect = effects[i];

            if (effect == null) return;

            var partycles = effect.GetComponentsInChildren<ParticleSystem>();
            if (active)
            {
                foreach (var partycle in partycles)
                {
                    partycle.Play();
                }
            }
            else
            {
                foreach (var partycle in partycles)
                {
                    partycle.Stop();
                }
            }
        }

    }
}
