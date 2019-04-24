using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRegion : MonoBehaviour
{
    public TweetBox tweetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != "Player") return;

        TweetBox tweet = Builder.TweetBox(tweetPrefab, transform);
        tweet.text = "ゆかりさんを崇めるのじゃ…………はあ尊い";
    }
}
