﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailManager : MonoBehaviour
{
    public ItemUnit item;

    public Image icon;
    public Text header, text, subText, rare, cost;

    void Update()
    {
        if (item == null) return;
        
        icon.sprite = item.status.icon;
        header.text = item.status.Name;
        rare.text = $"Rare {Builder.Repeat("★", item.status.rare)}";
        cost.text = $"Cost {Builder.Repeat("●", item.status.cost)}";
        text.text = item.status.text;
        subText.text = item.status.DetailedText();
    }
}
/*
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            item = hit.collider.gameObject.GetComponent<ItemUnit>();
            Debug.Log(hit.collider.gameObject.name);
            if(item != null)
            Debug.Log("Woking!");
        }
        */ //どうやら物理には効くので、敵のHPに使える