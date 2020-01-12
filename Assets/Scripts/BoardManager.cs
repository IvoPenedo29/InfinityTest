using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum colors { none, blue, red }

public class BoardManager : MonoBehaviour
{
    [HideInInspector]
    public Player player;

    public Cell[] cells;

    [HideInInspector]
    public Cell startingCell;
    [HideInInspector]
    public Cell currentCell;
    //[HideInInspector]
    public Cell previousCell;

    public bool redConnection = false;
    public bool blueConnection = false;
    public bool levelDone = false;

    public GameObject levelClearedPanel;

    //[HideInInspector]
    public bool mousePressed = false;

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
                    redConnection = false;
                    cells[i].color = colors.none;
                    cells[i].SwitchColor();
                }
            }
            if (color == colors.blue)
            {
                if (cells[i].isEmpty && cells[i].color == colors.blue)
                {
                    blueConnection = false;
                    cells[i].color = colors.none;
                    cells[i].SwitchColor();
                }
            }
        }
    }

    public void CheckSolution()
    {
        if (redConnection && blueConnection)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            levelDone = true;
            levelClearedPanel.SetActive(true);
        }
    }
}
