using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        
    }

    private async UniTask Test()
    {
        await UniTask.WaitForSeconds(1);
    }
}
