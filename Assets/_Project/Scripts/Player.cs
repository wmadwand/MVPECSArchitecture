using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<Enemy> OnDestroyEnemy;

    //public bool Is

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            OnDestroyEnemy?.Invoke(enemy);
        }
    }

    public void SetPosition(Vector2 touchPosition, float playerSpeed)
    {
        var offset = 30;
        var pos = new Vector3(Mathf.Clamp(touchPosition.x, offset, Screen.width - offset), Mathf.Clamp(touchPosition.y, offset, Screen.height - offset));
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;

        //originPos = player.transform.position;

        transform.position = Vector3.Lerp(transform.position, pos, playerSpeed * Time.deltaTime);

        //    //TODO: sqrMagnitude
        //    var distance = Vector3.Distance(originPos, player.transform.position);
        //scorePanel.model.AddDistance(distance);

        //    //TotalDistance += distance;
        //    originPos = player.transform.position;
    }
}