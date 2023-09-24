using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

[RequireComponent(typeof(ArcadeKart))]
public class JumpKart : MonoBehaviour
{
    private ArcadeKart kart;
    [SerializeField] private float JumpForce = 2000;
    bool isPlayer;
    private void Start()
    {
        kart = GetComponent<ArcadeKart>();
        isPlayer = GetComponent<KeyboardInput>() != null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayer) return;
        if (kart.GetCanMove() && kart.GroundPercent > 0.1f)
        {
            if (Input.GetButtonDown("Jump"))
            {

                kart.Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }


}
