using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentObject : MonoBehaviour
{
    public static ResidentObject singleton;

    void Awake()
    {
        //　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
        if (singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
            //　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
