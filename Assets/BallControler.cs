using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLook;
    // Update is called once per frame
    void Update()
    {
        freeLook.enabled = Input.GetMouseButtonDown(0);
    }
}
