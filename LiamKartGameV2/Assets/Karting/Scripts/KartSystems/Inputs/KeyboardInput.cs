using UnityEngine;

namespace KartGame.KartSystems
{

    public class KeyboardInput : BaseInput
    {
        public bool IsPlayer = false;
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        MobileControlsHUD mobileControls;

        private void Start()
        {
            mobileControls = MobileControlsHUD.Instance;
        }

        public override InputData GenerateInput()
        {
            if (!IsPlayer)
                return default;

            InputData data = new InputData();

            data.TurnInput = mobileControls.JoystickHorizontal != 0 ? mobileControls.JoystickHorizontal : Input.GetAxis("Horizontal");
            data.Accelerate = mobileControls.JoystickVertical > 0 || Input.GetButton(AccelerateButtonName);
            data.Brake = mobileControls.JoystickVertical < 0 || Input.GetButton(BrakeButtonName);

            return data;
        }
    }
}
