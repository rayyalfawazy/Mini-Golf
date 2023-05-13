using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public UnityEvent OnGoal = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            Invoke("MakeGoal", 1.5f);
        }
    }

    public void MakeGoal()
    {
        OnGoal.Invoke();
    }
}
