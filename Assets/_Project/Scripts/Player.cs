using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<Enemy> OnDestroyEnemy;

    public InoutTest input;

    private void OnMouseDown()
    {
        input.pos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            OnDestroyEnemy?.Invoke(enemy);
        }
    }
}
