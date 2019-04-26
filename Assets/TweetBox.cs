using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class TweetBox : MonoBehaviour
{
    public Vector2 offset;
    public string text;
    public float time = 1f;
    private Vector2 target;
    public Text TextObject;

    // Start is called before the first frame update
    void Start()
    {
        target = (Vector2)transform.position + offset;
        TextObject.text = text;
        //transform.localScale = new Vector3(TextObject.characterSize, 1f, 1f);
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target, 0.1f);
    }
}
