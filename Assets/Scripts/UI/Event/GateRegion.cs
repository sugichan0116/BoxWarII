using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VisualizeOnEditor))]
public class GateRegion : MonoBehaviour
{
    public string ID;
    public bool IsWarp = false;
    public string TargetID;
    public string TargetScene;

    private SceneSwitch sceneSwitch;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != "Player") return;
        if (Input.GetButtonDown("Vertical") == false) return;

        if (IsWarp)
        {
            Builder.FindGameObject<SceneSwitch>("SceneSwitch")
                .Switch(TargetID, TargetScene);
        }
        
    }
}
