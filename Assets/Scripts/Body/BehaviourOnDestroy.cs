using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourOnDestroy : MonoBehaviour 
{
    private static bool isQuitting = false;

    void OnApplicationQuit () => isQuitting = true;

    void OnDestroy ()
    {
        if (!isQuitting) DoOnDestroy();
    }

    protected virtual void DoOnDestroy() {}
}

