using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    CinemachineTransposer transposer;

    float zView;

    private void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
    }

    bool a = false;
    // Update is called once per frame
    void Update()
    {
        if (MobileControlsHUD.Instance.LookBackPressedDown)
        {
            print("DOWN");

            InvertZOffset();
        }
        else if (MobileControlsHUD.Instance.LookBackPressedUp)
        {
            print("UP");

            InvertZOffset();
        }
    }

    void InvertZOffset()
    {
        Vector3 offset = transposer.m_FollowOffset;
        offset.z *= -1;
        transposer.m_FollowOffset = offset;
    }
}
