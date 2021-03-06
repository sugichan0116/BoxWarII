﻿using UnityEngine;

public class Background : MonoBehaviour
{
    // スクロールするスピード
    private GameObject target;
    public Vector2 scale;
    public bool X = true, Y = true;
    private Vector3 offset;
    [Range(0, 1)]
    public float depth = 0.1f;

    private void Start()
    {
        target = Camera.main.gameObject;
        offset = target.transform.position;
    }

    void Update()
    {
        Vector3 delta = target.transform.position - offset;

        Vector2 repeat = new Vector2(
            (X) ? Mathf.Repeat(delta.x * depth / scale.x * 100, 1) : 0f,
            (Y) ? Mathf.Clamp(delta.y * depth / scale.y * 100, 0, 1) : 0f
            );

        // マテリアルにオフセットを設定する
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", repeat);
    }

    private void OnDestroy()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);
    }
}