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
        else if (color == colors.red)
        {
            _boardManager.ResetCells(color);
            _boardManager.player.playerInk = colors.red;
            _boardManager.startingCell = this;
        }
        else if (color == colors.green)
        {
            _boardManager.ResetCells(color);
            _boardManager.player.playerInk = colors.green;
            _boardManager.startingCell = this;
        }
        else if (color == colors.yellow)
        {
            _boardManager.ResetCells(color);
            _boardManager.player.playerInk = colors.yellow;
            _boardManager.startingCell = this;
        }
        else
        {
            _boardManager.ResetCells(color);
            _boardManager.player.playerInk = colors.cyan;
            _boardManager.startingCell = this;
        }
    }

    void OnMouseUp()
    {
        _boardManager.player.playerInk = colors.none;

        _boardManager.previousCell = null;
        _boardManager.mousePressed = false;
        AudioManager.instance.sounds[1].source.pitch = 1.0f;
        _boardManager.CheckLight();
    }

    void OnMouseEnter()
    {
        if (_boardManager.mousePressed)
        {
            AudioManager.instance.Play("Marimba");

            if (AudioManager.instance.sounds[1].source.pitch < 3.0f)
                AudioManager.instance.sounds[1].source.pitch += 0.2f;
            else
                AudioManager.instance.sounds[1].source.pitch = 3.0f;

            _boardManager.currentCell = this;

            if (_boardManager.currentCell.color == colors.red && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
                _boardManager.redConnection = false;
            else if (_boardManager.currentCell.color == colors.blue && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
                _boardManager.blueConnection = false;
            else if (_boardManager.currentCell.color == colors.green && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
                _boardManager.greenConnection = false;
            else if (_boardManager.currentCell.color == colors.yellow && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
                _boardManager.yellowConnection = false;
            else if (_boardManager.currentCell.color == colors.cyan && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
                _boardManager.cyanConnection = false;

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
                else if (_boardManager.player.playerInk == colors.green)
                    _boardManager.greenConnection = true;
                else if (_boardManager.player.playerInk == colors.yellow)
                    _boardManager.yellowConnection = true;
                else if (_boardManager.player.playerInk == colors.cyan)
                    _boardManager.cyanConnection = true;

                _boardManager.mousePressed = false;
                _boardManager.player.playerInk = colors.none;
                _boardManager.CheckSolution();
                _boardManager.CheckLight();
                _boardManager.CameraShake();
            }

            if (_boardManager.player.playerInk == colors.blue)
                color = colors.blue;
            else if (_boardManager.player.playerInk == colors.red)
                color = colors.red;
            else if (_boardManager.player.playerInk == colors.green)
                color = colors.green;
            else if (_boardManager.player.playerInk == colors.yellow)
                color = colors.yellow;
            else if (_boardManager.player.playerInk == colors.cyan)
                color = colors.cyan;

            SwitchColor();
        }              
    }

    void OnMouseExit()
    {
        if(isEmpty && _boardManager.mousePressed && _boardManager.player.playerInk != colors.none)
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
            case colors.green:
                _spriteRenderer.color = Color.green;
                break;
            case colors.yellow:
                _spriteRenderer.color = Color.yellow;
                break;
            case colors.cyan:
                _spriteRenderer.color = Color.cyan;
                break;
            case colors.none:
                _spriteRenderer.color = Color.grey;
                break;
        }        
    }
}
