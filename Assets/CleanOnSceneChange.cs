using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleanOnSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
    }

}
