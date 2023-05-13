using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spinner : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(0, 360.0f), 3.0f)
            .SetLoops(-1)
            .SetRelative()
            .SetEase(Ease.Linear);
    }
}
