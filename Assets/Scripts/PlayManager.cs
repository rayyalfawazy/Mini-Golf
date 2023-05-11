using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController cameraController;
    [SerializeField] TMP_Text shootCounterText;

    
    bool isBallOutside;
    bool isBallTeleporting;
    bool isGetScore;
    Vector3 lastBallPosition;

    private void Update()
    {
        //Mengambil posisi terakhir bola
        if (ballController.ShootingMode)
        {
            lastBallPosition = ballController.transform.position;
        }

        shootCounterText.text = $"Shot Counted : {ballController.GetShots}";

        if (!ballController.IsMove())
        {
            isGetScore = true;
            if (isGetScore)
            {
                Debug.Log($"Ball Moving {ballController.IsMove()} & Get Score {isGetScore}");
                isGetScore = false;
            }
        }


        var inputActive = Input.GetMouseButton(0) && 
        ballController.IsMove()  == false &&
        ballController.ShootingMode == false &&
        isBallOutside == false;

        cameraController.SetInputActive(inputActive);   
    }

    public void OnGoalEnter()
    {
        // Todo show window popup
        ballController.enabled = false;
        Debug.Log("Goal Popup");
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
