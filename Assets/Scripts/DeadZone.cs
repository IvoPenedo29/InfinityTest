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
        //Se o jogador sair do tabuleiro reinicializar as variáveis para que não possa pintar mais
        _boardManager.mousePressed = false;
        _boardManager.player.playerInk = colors.none;        
    }
}
