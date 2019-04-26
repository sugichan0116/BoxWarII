using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweetGroup : MonoBehaviour
{
    [SerializeField]
    public List<string> scripts;
    [SerializeField]
    public List<EventRegion> list;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Text = scripts[i];
        }
    }

}
