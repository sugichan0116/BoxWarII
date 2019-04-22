using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFacingBehaviour : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = RectTransformUtility
            .WorldToScreenPoint(Camera.main, transform.position);
        Vector2 mouse = (Vector2)Input.mousePosition - playerPosition;

        transform.rotation = Builder.Rotate(mouse);
    }
}
