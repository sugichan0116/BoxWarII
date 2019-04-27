using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRegion : MonoBehaviour
{
    public string ID;
    public bool IsWarp = false;
    public string TargetID;
    public string TargetScene;

    private SceneSwitch sceneSwitch;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != "Player") return;

        if (IsWarp)
        {
            Builder.FindGameObject<SceneSwitch>("SceneSwitch")
                .Switch(TargetID, TargetScene);
        }
        
    }
}
