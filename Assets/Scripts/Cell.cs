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
            _boardManager.startingCell = this;
        }
        else
        {
            _boardManager.ResetCells(color);
            _boardManager.player.ink = inkColors.red;
            _boardManager.startingCell = this;
        }
    }

    void OnMouseUp()
    {
        _boardManager.player.ink = inkColors.none;
    }

    void OnMouseEnter()
    {
        _boardManager.currentCell = this;

        if (_boardManager.currentCell.color == colors.red && _boardManager.player.ink == inkColors.blue)
            _boardManager.redConnection = false;
        else if (_boardManager.currentCell.color == colors.blue && _boardManager.player.ink == inkColors.red)
            _boardManager.blueConnection = false;        

        if (!isEmpty)
        {
            if (!(_boardManager.currentCell.color == colors.red && _boardManager.player.ink == inkColors.red || _boardManager.currentCell.color == colors.blue && _boardManager.player.ink == inkColors.blue))
            {
                _boardManager.player.ink = inkColors.none;
                return;
            }
        }

        if (_boardManager.currentCell != _boardManager.startingCell && _boardManager.currentCell.color == colors.red && !_boardManager.currentCell.isEmpty && _boardManager.player.ink == inkColors.red)
        {
            _boardManager.redConnection = true;
            _boardManager.player.ink = inkColors.none;
            _boardManager.CheckSolution();
        }
        else if (_boardManager.currentCell != _boardManager.startingCell && _boardManager.currentCell.color == colors.blue && !_boardManager.currentCell.isEmpty && _boardManager.player.ink == inkColors.blue)
        {
            _boardManager.blueConnection = true;
            _boardManager.player.ink = inkColors.none;
            _boardManager.CheckSolution();
        }

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
