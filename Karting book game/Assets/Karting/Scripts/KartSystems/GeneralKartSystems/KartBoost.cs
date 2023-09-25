using UnityEngine;
public class KartBoost : KartComponet
{
    public void Boost(Vector3 boostVector)
    {
        if (kart.CanMove && kart.GroundPercent > 0.15f)
        {
            if (!isPlayer)
            {
                print("agent");
                Vector3 kartVelo = kart.Rigidbody.velocity;
                if (Mathf.Abs(boostVector.z) > Mathf.Abs(boostVector.x))
                {
                    
                    kartVelo = new Vector3(0, kartVelo.y, kartVelo.z);
                    
                }
                else
                {
                    kartVelo = new Vector3(kartVelo.x, kartVelo.y, 0);
                    
                }

                kart.Rigidbody.velocity = kartVelo;
                print(kart.Rigidbody.velocity);
            }

            kart.Rigidbody.AddForce(boostVector,ForceMode.VelocityChange);
        }
    }
}