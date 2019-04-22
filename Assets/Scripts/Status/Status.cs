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
    public List<string> Attribute = new List<string>(1);
    public Sprite icon;
    public string text = "good small bullet.";
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
