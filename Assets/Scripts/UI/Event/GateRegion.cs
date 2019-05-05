using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VisualizeOnEditor))]
public class GateRegion : MonoBehaviour
{
    public string ID;
    public bool IsWarp = false;
    public bool IsAuto = false;
    public string TargetID;
    public string TargetScene;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsWarp == false) return;
        if (collision.transform.gameObject.tag != "Player") return;
        if (IsAuto == false && Input.GetButtonDown("Vertical") == false) return;
        
        Builder.FindGameObject<SceneSwitch>("SceneSwitch")
            .Switch(TargetID, TargetScene);
    }
}
