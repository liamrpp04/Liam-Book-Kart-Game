using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

[RequireComponent(typeof(ArcadeKart))]
public class KartComponent : MonoBehaviour
{
    public bool isPlayer => GetComponent<KeyboardInput>().IsPlayer;
    protected ArcadeKart kart;

    private void Awake()
    {
        kart = GetComponent<ArcadeKart>();
    }
}
