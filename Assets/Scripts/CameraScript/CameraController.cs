using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook CM_FreeLook;

    public void SetInputActive(bool value)
    {
        if (value)
        {
            CM_FreeLook.m_XAxis.m_InputAxisName = "Mouse X";
            CM_FreeLook.m_YAxis.m_InputAxisName = "Mouse Y";
        } else
        {
            CM_FreeLook.m_XAxis.m_InputAxisName = "";
            CM_FreeLook.m_YAxis.m_InputAxisName = "";
        }
    } 
}
