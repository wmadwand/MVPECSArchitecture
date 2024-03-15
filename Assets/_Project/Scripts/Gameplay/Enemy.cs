using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Score;
    public bool IsCollisionEnter = false;

    public void Remove()
    {
        var _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOScale(0f, .5f)
                  .SetEase(Ease.InBack))
                  .AppendCallback(() => Destroy(gameObject));

        _sequence.Play();
    }
}
