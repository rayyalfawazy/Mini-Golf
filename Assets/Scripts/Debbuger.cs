using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Debbuger : MonoBehaviour
{
    public UnityEvent events;

    private void Start()
    {
        events.Invoke();
    }
}
