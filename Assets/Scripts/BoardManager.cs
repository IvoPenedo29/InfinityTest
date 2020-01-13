using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public enum colors { none, blue, red , green, yellow, cyan }

public class BoardManager : MonoBehaviour
{
    [HideInInspector]
    public Player player;

    public Cell[] cells;

    [HideInInspector]
    public Cell startingCell;
    [HideInInspector]
    public Cell currentCell;
    [HideInInspector]
    public Cell previousCell;

    public bool redConnection;
    public bool blueConnection;
    public bool greenConnection;
    public bool yellowConnection;
    public bool cyanConnection;
    public bool levelDone = false;

    public GameObject levelClearedPanel;

    [HideInInspector]
    public bool mousePressed = false;

    private NextLevel _nextLevel;

    void Start()
    {
        player = FindObjectOfType<Player>();

        _nextLevel = FindObjectOfType<NextLevel>();

        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].SwitchColor();
        }
    }

    public void ResetCells(colors color)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            switch (color)
            {
                case colors.red:
                    if (cells[i].isEmpty && cells[i].color == colors.red)
                    {
                        redConnection = false;
                        cells[i].color = colors.none;
                        cells[i].SwitchColor();
                    }
                    break;
                case colors.blue:
                    if (cells[i].isEmpty && cells[i].color == colors.blue)
                    {
                        blueConnection = false;
                        cells[i].color = colors.none;
                        cells[i].SwitchColor();
                    }
                    break;
                case colors.green:
                    if (cells[i].isEmpty && cells[i].color == colors.green)
                    {
                        greenConnection = false;
                        cells[i].color = colors.none;
                        cells[i].SwitchColor();
                    }
                    break;
                case colors.yellow:
                    if (cells[i].isEmpty && cells[i].color == colors.yellow)
                    {
                        yellowConnection = false;
                        cells[i].color = colors.none;
                        cells[i].SwitchColor();
                    }
                    break;
                case colors.cyan:
                    if (cells[i].isEmpty && cells[i].color == colors.cyan)
                    {
                        cyanConnection = false;
                        cells[i].color = colors.none;
                        cells[i].SwitchColor();
                    }
                    break;
            }
        }
    }

    public void CheckSolution()
    {        
        if (redConnection && blueConnection && greenConnection && yellowConnection & cyanConnection)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            levelDone = true;
            levelClearedPanel.SetActive(true);

            if (_nextLevel.nextLevel > PlayerPrefs.GetInt("currentLevel"))
            {
                PlayerPrefs.SetInt("currentLevel", _nextLevel.nextLevel - 1);
            }
        }        
    }

    public void CheckLight()
    {
        if (blueConnection)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].color == colors.blue)
                {
                    cells[i].GetComponent<Light2D>().enabled = true;
                    cells[i].GetComponent<Light2D>().color = Color.blue;
                }
            }
        }
        else
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].GetComponent<Light2D>().color == Color.blue)
                {
                    cells[i].GetComponent<Light2D>().enabled = false;
                }
            }
        }
        if (redConnection)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].color == colors.red)
                {
                    cells[i].GetComponent<Light2D>().enabled = true;
                    cells[i].GetComponent<Light2D>().color = Color.red;
                }
            }
        }
        else
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].GetComponent<Light2D>().color == Color.red)
                {
                    cells[i].GetComponent<Light2D>().enabled = false;
                }
            }
        }
        if (greenConnection)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].color == colors.green)
                {
                    cells[i].GetComponent<Light2D>().enabled = true;
                    cells[i].GetComponent<Light2D>().color = Color.green;
                }
            }
        }
        else
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].GetComponent<Light2D>().color == Color.green)
                {
                    cells[i].GetComponent<Light2D>().enabled = false;
                }
            }
        }
        if (yellowConnection)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].color == colors.yellow)
                {
                    cells[i].GetComponent<Light2D>().enabled = true;
                    cells[i].GetComponent<Light2D>().color = Color.yellow;
                }
            }
        }
        else
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].GetComponent<Light2D>().color == Color.yellow)
                {
                    cells[i].GetComponent<Light2D>().enabled = false;
                }
            }
        }
        if (cyanConnection)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].color == colors.cyan)
                {
                    cells[i].GetComponent<Light2D>().enabled = true;
                    cells[i].GetComponent<Light2D>().color = Color.cyan;
                }
            }
        }
        else
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].GetComponent<Light2D>().color == Color.cyan)
                {
                    cells[i].GetComponent<Light2D>().enabled = false;
                }
            }
        }
    }
}
