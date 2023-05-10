using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Outside : MonoBehaviour
{
    public UnityEvent OnBallEnter = new UnityEvent(); // Buat Event System

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ball")) // Deteksi Tag "Ball"
        {
            OnBallEnter.Invoke(); // Buat Event System
        }
    }
}
