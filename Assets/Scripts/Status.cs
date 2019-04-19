using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string text = "good small bullet.";
    public float Mass = 1f;
    public float FiringSpeed = 100f;
    public float Cooltime = 0.3f;
    public BulletBehaviour prefabBullet;
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
