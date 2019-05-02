using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Builder : MonoBehaviour
{
    private static string containerTag = "Pool";
    
    private static GameObject poolFX;
    private static string nameFX = "FX Pool";

    private static GameObject poolBullet;
    private static string nameBullet = "Bullet Pool";

    private static GameObject poolBlock;
    private static string nameBlock = "Block Pool";
    
    private static GameObject poolTweet;
    private static string nameTweet = "TweetPool";

    //CAUTION : quaternion lookat
    public static Quaternion Rotate(Vector2 a)
    {
        return Quaternion.Euler(0f, 0f, AngleBetween(Vector2.zero, a));
    }

    //CAUTION : quaternion -> angleBetween
    public static float AngleBetween(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
    
    //NOTE : finder
    public static T FindGameObject<T>(string Tag)
    {
        return GameObject.FindGameObjectsWithTag(Tag)
             .FirstOrDefault(value => value.GetComponent<T>() != null)
            .GetComponent<T>();
    }

    //NOTE : finder
    public static GameObject FindGameObject(string Tag, string name)
    {
        return GameObject.FindGameObjectsWithTag(Tag)
             .FirstOrDefault(value => value.name == name);
    }
    
    //NOTE : util
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    
    public static string Repeat(string t, int n)
    {
        string text = "";
        for (int i = 0; i < n; i++) text += t;

        return text;
    }
    
    public static TweetBox TweetBox(TweetBox prefab, Transform trans)
    {
        if (poolTweet == null) poolTweet = FindGameObject(containerTag, nameTweet);

        return Instantiate(
            prefab, 
            trans.position, 
            trans.rotation, 
            poolTweet.transform);
    }
    
    public static EnduranceBody Block(EnduranceBody prefab, Transform trans)
    {
        if (poolBlock == null) poolBlock = FindGameObject(containerTag, nameBlock);
        
        return Instantiate(
            prefab, 
            trans.position, 
            trans.rotation, 
            poolBlock.transform);
    }

    public static ParticleSystem Effecter(ParticleSystem prefab, Transform trans)
    {
        if(poolFX == null) poolFX = FindGameObject(containerTag, nameFX);

        return Instantiate(
            prefab, 
            trans.position, 
            trans.rotation, 
            poolFX.transform
            );
    }

    public static BulletBehaviour Bullet(BulletBehaviour prefab, Transform trans)
    {
        if (poolBullet == null) poolBullet = FindGameObject(containerTag, nameBullet);

        return Instantiate(
            prefab,
            trans.position,
            trans.rotation,
            poolBullet.transform
            );
    }

    public static void Init()
    {
        poolBullet = null;
        poolFX = null;
        poolBlock = null;
    }
}
