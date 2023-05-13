using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController cameraController;
    [SerializeField] TMP_Text shootCounterText;
    
    bool isBallOutside;
    bool isBallTeleporting;
    Vector3 lastBallPosition;

    private void Start()
    {
        //Debug.Log(SceneManager.);
    }

    private void Update()
    {
        //Mengambil posisi terakhir bola
        if (ballController.ShootingMode)
        {
            lastBallPosition = ballController.transform.position;
        }

        shootCounterText.text = $"Shot Attemp : {ballController.GetShots}";

        var inputActive = Input.GetMouseButton(0) && 
        ballController.IsMove()  == false &&
        ballController.ShootingMode == false &&
        isBallOutside == false;

        cameraController.SetInputActive(inputActive);   
    }

    public void OnGoalEnter()
    {
        ballController.enabled = false;
    }

    public void OnBallOutside()
    {
        if (!isBallTeleporting)
        {
            Invoke("TPBallLastPosition", 1.5f);
        }
        ballController.enabled = false;
        isBallOutside = true;
        isBallTeleporting = true;
    }

    public void TPBallLastPosition()
    {
        TeleportBall(lastBallPosition);
    }

    public void TeleportBall(Vector3 targetPosition)
    {
        var rb = ballController.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballController.transform.position = lastBallPosition;
        rb.isKinematic = false;

        ballController.enabled = true;
        isBallOutside = false;
        isBallTeleporting = false;
    }
}
