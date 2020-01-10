using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isEmpty;

    public colors color;

    private SpriteRenderer _spriteRenderer;
    private BoardManager _boardManager;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boardManager = GetComponentInParent<BoardManager>();
    }

    void OnMouseDown()
    {
        if (isEmpty)
        {
            _boardManager.player.ink = inkColors.none;
            return;
        }
        else if (color == colors.blue)
        {
            _boardManager.ResetCells(color);
            _boardManager.player.ink = inkColors.blue;
        }
        else
        {
            _boardManager.ResetCells(color);
            _boardManager.player.ink = inkColors.red;
        }
    }

    void OnMouseUp()
    {
        _boardManager.player.ink = inkColors.none;
    }

    void OnMouseEnter()
    {
        if (!isEmpty)
            return;

        if (_boardManager.player.ink == inkColors.blue)
            color = colors.blue;
        else if (_boardManager.player.ink == inkColors.red)
            color = colors.red;

        SwitchColor();
    }

    public void SwitchColor()
    {
        switch (color)
        {
            case colors.red:
                _spriteRenderer.color = Color.red;
                break;
            case colors.blue:
                _spriteRenderer.color = Color.blue;
                break;
            case colors.none:
                _spriteRenderer.color = Color.grey;
                break;
        }
    }
}
