using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(
  fileName = "Status",
  menuName = "ScriptableObject/Status",
  order = 0)
]
[System.Serializable]
public class Status : ScriptableObject
{
    public string Name = "name";
    public List<StatusAttribute> Attribute = new List<StatusAttribute> { StatusAttribute.Default };
    public Sprite icon;
    [Multiline]
    public string text = "good small bullet.";

    public virtual string DetailedText()
    {
        return "Attribute : Item";
    }
}


public enum StatusAttribute
{
    Default,
    Main,
    Sub,
    Robot,
    Gun,
    Bullet,
    Item
}

/*
[CreateAssetMenu(
  fileName = "BulletPackage",
  menuName = "ScriptableObject/BulletPackage",
  order = 0)
]
public class BulletStatusPackage : ScriptableObject
{
    public List<BulletStatus> List = new List<BulletStatus>();
}
*/
