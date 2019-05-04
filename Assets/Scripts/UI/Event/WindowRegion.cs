using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VisualizeOnEditor))]
[System.Serializable]
public class WindowRegion : MonoBehaviour
{
    public UIWindow windowPrefab;
    public bool isOnce = false;

    private int num = 0;
    protected UIWindow window;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOnce && num > 0) return;
        if (window != null) return;
        if (collision.transform.gameObject.tag != "Player") return;

        window = Builder.Window(windowPrefab, transform);
        WindowOpen(window);
        num++;
    }

    protected virtual void WindowOpen(UIWindow window) => window.Open();

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (window == null) return;

        WindowClose(window);
    }

    protected virtual void WindowClose(UIWindow window) => window.Close();
}
