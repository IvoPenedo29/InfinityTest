﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum colors { none, blue, red }

public class BoardManager : MonoBehaviour
{
    [HideInInspector]
    public Player player;

    public Cell[] cells;

    void Start()
    {
        player = FindObjectOfType<Player>();

        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].SwitchColor();
        }
    }

    public void ResetCells(colors color)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (color == colors.red)
            {
                if (cells[i].isEmpty && cells[i].color == colors.red)
                {
                    cells[i].color = colors.none;
                    cells[i].SwitchColor();
                }
            }
            if (color == colors.blue)
            {
                if (cells[i].isEmpty && cells[i].color == colors.blue)
                {
                    cells[i].color = colors.none;
                    cells[i].SwitchColor();
                }
            }
        }
    }
}