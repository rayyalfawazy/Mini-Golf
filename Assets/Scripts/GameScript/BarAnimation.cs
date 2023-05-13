using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarAnimation : MonoBehaviour
{
    [SerializeField] float scaleLimitX;
    [SerializeField] float duration;
    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence().SetLoops(-1);
        transform.DORotate(new Vector3(0, 360.0f), 3.0f)
            .SetLoops(-1)
            .SetRelative()
            .SetEase(Ease.Linear);
        sequence.Append
            (
            transform.DOScaleX(scaleLimitX, duration)
                .SetRelative()
                .SetEase(Ease.Linear)
            );

        sequence.Append
            (
            transform.DOScaleX(-scaleLimitX, duration)
                .SetRelative()
                .SetEase(Ease.Linear)
            );
    }
}
