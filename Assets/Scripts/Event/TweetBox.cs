using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweetBox : UIWindow
{
    public Text TextObject;
    public string text;
        
    void Start()
    {
        TextObject.text = text;
    }
    
}
