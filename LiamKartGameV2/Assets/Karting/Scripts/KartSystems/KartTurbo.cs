using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

[RequireComponent(typeof(ArcadeKart))]
public class KartTurbo : MonoBehaviour
{
    [SerializeField] private float coldDown = 3f;
    private ArcadeKart kart;

    bool turboAllowed = true;
    int turboCount = 0;
    float delta;

    private void Start()
    {
        kart = GetComponent<ArcadeKart>();
    }

    public void AddKartTurbo(int count = 1)
    {
        turboCount += count;
        NitroHUD.Instance.SetCountText(turboCount);

    }

    public void Turbo(Vector3 boostForce)
    {
        kart.Rigidbody.velocity = Vector3.zero;
        //kart.transform.rotation = Quaternion.LookRotation(boostForce, Vector3.up);
        kart.Rigidbody.AddForce(boostForce, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if (kart.GetCanMove() && kart.GroundPercent > 0.1f)
        {
            if (!turboAllowed)
            {
                delta -= Time.deltaTime;
                if (delta <= 0) turboAllowed = true;
                return;
            }

            if (turboCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Turbo(kart.transform.forward * kart.GetMaxSpeed() * 1.85f);
                    turboCount--;
                    turboAllowed = false;
                    delta = coldDown;

                    NitroHUD.Instance.SetCountText(turboCount);
                }
            }
        }
    }
}
