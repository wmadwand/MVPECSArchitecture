using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InoutTest input;

    private void OnMouseDown()
    {
        input.pos = transform.position;
    }
}
