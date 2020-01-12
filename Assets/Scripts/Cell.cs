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
        _boardManager.mousePressed = true;

        if (isEmpty)
        {
            _boardManager.player.playerInk = colors.none;
            return;
        }
        else if (color == colors.blue)
        {
            _boardManager.ResetCells(color);
            _boardManager.player.playerInk = colors.blue;
            _boardManager.startingCell = this;
        }
        else
        {
            _boardManager.ResetCells(color);
            _boardManager.player.playerInk = colors.red;
            _boardManager.startingCell = this;
        }
    }

    void OnMouseUp()
    {
        _boardManager.player.playerInk = colors.none;

        _boardManager.previousCell = null;
        _boardManager.mousePressed = false;
    }

    void OnMouseEnter()
    {
        _boardManager.currentCell = this;

        if (_boardManager.currentCell.color == colors.red && _boardManager.player.playerInk == colors.blue)
            _boardManager.redConnection = false;
        else if (_boardManager.currentCell.color == colors.blue && _boardManager.player.playerInk == colors.red)
            _boardManager.blueConnection = false;

        if (!isEmpty)
        {
            if (_boardManager.currentCell.color != _boardManager.player.playerInk)
            {
                _boardManager.player.playerInk = colors.none;
                return;
            }
        }

        if (_boardManager.previousCell != null && _boardManager.currentCell.color == _boardManager.player.playerInk && (_boardManager.currentCell.isEmpty || _boardManager.currentCell == _boardManager.startingCell))
        {
            _boardManager.previousCell.color = colors.none;
            _boardManager.previousCell.SwitchColor();
        }

        if (_boardManager.currentCell != _boardManager.startingCell && !_boardManager.currentCell.isEmpty && _boardManager.currentCell.color == _boardManager.player.playerInk)
        {
            if (_boardManager.player.playerInk == colors.red)
                _boardManager.redConnection = true;
            else if (_boardManager.player.playerInk == colors.blue)
                _boardManager.blueConnection = true;

            _boardManager.player.playerInk = colors.none;
            _boardManager.CheckSolution();
        }

        if (_boardManager.player.playerInk == colors.blue)
            color = colors.blue;
        else if (_boardManager.player.playerInk == colors.red)
            color = colors.red;

        SwitchColor();        
    }

    void OnMouseExit()
    {
        if(isEmpty && _boardManager.mousePressed)
            _boardManager.previousCell = this;
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
