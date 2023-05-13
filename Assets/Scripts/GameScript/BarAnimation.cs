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

        sequence.Append
            (
            transform.DOScale(new Vector3(-scaleLimitX, 0, 0), duration)
                .SetRelative()
                .SetEase(Ease.Linear)
            );

        sequence.Append
            (
            transform.DOScale(new Vector3(-scaleLimitX,0,0), duration)
                .SetRelative()
                .SetEase(Ease.Linear)
            );
    }
}
