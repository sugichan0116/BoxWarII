using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetRegion : WindowRegion
{
    public string Text;
    
    protected override void WindowOpen(UIWindow window)
    {
        window.Open();
        TweetBox box = window as TweetBox;
        box.text = Text;
    }
}
