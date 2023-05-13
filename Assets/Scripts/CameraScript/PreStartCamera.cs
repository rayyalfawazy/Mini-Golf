using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PreStartCamera : MonoBehaviour
{
    CinemachineFreeLook FreeLookPreStart;
    [SerializeField] CinemachineFreeLook CM_FreeLook;
    [SerializeField] UnityEvent OnPreStart;
    [SerializeField] UnityEvent AfterPreStart;

    private void Start()
    {
        FreeLookPreStart = GetComponent<CinemachineFreeLook>();
        FreeLookPreStart.transform.DOMoveZ(3.5f, 5).OnComplete(CompleteMove);
        OnPreStart.Invoke();
    }

    private void CompleteMove()
    {
        FreeLookPreStart.gameObject.SetActive(false);
        CM_FreeLook.gameObject.SetActive(true);
        AfterPreStart.Invoke();
    }
}
