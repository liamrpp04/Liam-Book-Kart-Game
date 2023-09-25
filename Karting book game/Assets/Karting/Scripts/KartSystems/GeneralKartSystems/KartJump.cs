using UnityEngine;

public class KartJump : KartComponet
{   
    [SerializeField] private float jumpForce = 2000;
    void Update()
    {
        if(!isPlayer) return;

        if (kart.CanMove && kart.GroundPercent > 0.15f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                kart.Rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            }
        }
    }
}
