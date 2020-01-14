using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private BoardManager _boardManager;

    void Awake()
    {
        _boardManager = FindObjectOfType<BoardManager>();        
    }

    void OnMouseEnter()
    {
        _boardManager.mousePressed = false;
        _boardManager.player.playerInk = colors.none;
        if (_boardManager.currentCell != null)
        {
            switch (_boardManager.currentCell.color)
            {
                case colors.red:
                    if(!_boardManager.redConnection)
                        _boardManager.ResetCells(_boardManager.currentCell.color);
                    break;
                case colors.blue:
                    if (!_boardManager.blueConnection)
                        _boardManager.ResetCells(_boardManager.currentCell.color);
                    break;
                case colors.green:
                    if (!_boardManager.greenConnection)
                        _boardManager.ResetCells(_boardManager.currentCell.color);
                    break;
                case colors.yellow:
                    if (!_boardManager.yellowConnection)
                        _boardManager.ResetCells(_boardManager.currentCell.color);
                    break;
                case colors.cyan:
                    if (!_boardManager.cyanConnection)
                        _boardManager.ResetCells(_boardManager.currentCell.color);
                    break;
            }
        }            
    }
}
