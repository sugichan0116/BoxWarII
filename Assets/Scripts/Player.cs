using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnduranceBody))]
public class Player : MonoBehaviour
{
    public List<GunBehaviour> guns;
    public PlayerMove Move;
    
    // Start is called before the first frame update
    void Start()
    {
        //Move = GetComponent<PlayerMove>();
    }

    private void Update() => FireGuns();

    private void FireGuns()
    {
        if (Input.GetMouseButtonDown(0) && Builder.IsPointerOverUIObject() == false)
        {
            Vector2 playerPosition = RectTransformUtility
                .WorldToScreenPoint(Camera.main, transform.position);
            Vector2 mouse = (Vector2)Input.mousePosition - playerPosition;

            foreach (var gun in guns)
            {
                gun.Fire(mouse);
            }
        }
    }

    public void UseItem(StatusItem item)
    {
        EnduranceBody body = GetComponent<EnduranceBody>();

        if(item.Type == ItemAttribute.Repair)
        {
            body.AddHealth(item.strongth);
        }
    }

}
