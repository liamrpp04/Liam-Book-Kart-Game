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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            InvertZOffset();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse2))
        {
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
