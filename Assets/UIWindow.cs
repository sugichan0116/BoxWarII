using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIWindow : MonoBehaviour
{
    public Vector2 offset;
    public float time = 1f;

    //private bool isOpen = false;
    //private float maxTime = 10f;
    
    public void Open()
    {
        transform.DOMove(offset, time).SetRelative();
        //transform.localScale = new Vector3(TextObject.characterSize, 1f, 1f);
        //Destroy(gameObject, maxTime);
    }

    public void CloseAuto()
    {
        transform.DOMove(offset, time).SetRelative();
        Destroy(gameObject, time);
    }

    public void Close()
    {
        transform.DOScale(-.002f, .2f).SetRelative();
        Destroy(gameObject, time);
    }
}
