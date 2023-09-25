using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(ArcadeKart))]
public class KartComponet : MonoBehaviour
{
    public bool isPlayer => GetComponent<KeyboardInput>() != null;
    protected ArcadeKart kart;
    void Awake()
    {
        kart = GetComponent<ArcadeKart>();
    }
}
