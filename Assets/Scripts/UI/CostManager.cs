using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CostManager : MonoBehaviour
{
    public Text text;

    public delegate void EventHandler(bool isCost);
    public event EventHandler OnEquip;

    private bool isChanged = false;

    private void Start()
    {
        foreach(var cell in GetComponentsInChildren<CellUnit>()) {
            cell.OnChanged += value => {
                isChanged = true; //UpdateCost();
            };
        }
    }

    private void LateUpdate()
    {
        if (isChanged) {
            isChanged = false;
            UpdateCost();
        }
    }

    private void UpdateCost()
    {
        int now = 0, cost = 0;

        foreach (var cell in GetComponentsInChildren<CellUnit>())
        {
            if (cell.Item() == null) continue;

            now += cell.Item().status.cost;
            if(cell.Item().status is StatusRobot robot) cost += robot.maxCost;
        }
        
        OnEquip(cost < now);

        text.text = Builder.Repeat((cost >= now) ? "●" : "x", now)
            + Builder.Repeat("○", Mathf.Max(0, cost - now));
    }

}
