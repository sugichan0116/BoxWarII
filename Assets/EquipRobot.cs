using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CostManager))]
public class EquipRobot : MonoBehaviour
{
    public CellUnit cellRobot;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Builder.FindGameObject<Player>("Player");

        cellRobot.OnChanged += value =>
        {
            if (value == null) return;

            if (value.status is StatusRobot robot)
            {
                player.Move.JumpMax(robot.jump);
            }
        };
    }
}
