using UnityEngine;

namespace KartGame.KartSystems
{

    public class KeyboardInput : BaseInput
    {
        public bool IsMobile = true;
        public bool IsPlayer = false;
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";
        public Joystick joystick;

        public override InputData GenerateInput()
        {
            InputData data = new InputData();
            if (IsMobile && IsPlayer)
            {
                data.TurnInput = joystick.Horizontal;
                data.Accelerate = joystick.Vertical > 0;
                data.Brake = joystick.Vertical < 0;
            }
            else
            {
                data.TurnInput = Input.GetAxis("Horizontal");
                data.Accelerate = Input.GetButton(AccelerateButtonName);
                data.Brake = Input.GetButton(BrakeButtonName);
            }

            return data;
        }
    }
}
