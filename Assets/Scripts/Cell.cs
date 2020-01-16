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
        //Inicialização de variáveis
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boardManager = GetComponentInParent<BoardManager>();
    }

    void OnMouseDown()
    {
        _boardManager.mousePressed = true;

        //Quando uma célula deteta que o mouse down verifica a sua cor e se for uma das células que possuem de facto cor então passam essa variável ao player
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
        //Verificar se a célula na qual foi detetada o mouse up não é uma das células inicialmente pintadas e não sendo reiniciar as células que já foram pintadas com essa cor
        if (_boardManager.currentCell.isEmpty)
        {
            _boardManager.ResetCells(_boardManager.currentCell.color);
        }

        //Reinicialização de variáveis
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
            //Tocar o som cada vez que entra numa nova célula e aumentar o pitch do mesmo
            if (_boardManager.player.playerInk != colors.none)
            {
                AudioManager.instance.Play("Marimba");

                if (AudioManager.instance.sounds[1].source.pitch < 3.0f)
                    AudioManager.instance.sounds[1].source.pitch += 0.2f;
                else
                    AudioManager.instance.sounds[1].source.pitch = 3.0f;
            }            

            //Definir a célula na qual o jogador se encontra
            _boardManager.currentCell = this;

            //Verificar se alguma conexão foi intersetada por outra e se for reinicializar as células da cor intersetada
            if (_boardManager.currentCell.color == colors.red && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
            {
                _boardManager.redConnection = false;
                _boardManager.ResetCells(colors.red);
            }
            else if (_boardManager.currentCell.color == colors.blue && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
            {
                _boardManager.blueConnection = false;
                _boardManager.ResetCells(colors.blue);
            }
            else if (_boardManager.currentCell.color == colors.green && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
            {
                _boardManager.greenConnection = false;
                _boardManager.ResetCells(colors.green);
            }
            else if (_boardManager.currentCell.color == colors.yellow && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
            {
                _boardManager.yellowConnection = false;
                _boardManager.ResetCells(colors.yellow);
            }
            else if (_boardManager.currentCell.color == colors.cyan && _boardManager.player.playerInk != _boardManager.currentCell.color && _boardManager.player.playerInk != colors.none)
            {
                _boardManager.cyanConnection = false;
                _boardManager.ResetCells(colors.cyan);
            }

            //Verificar se o jogador entrou numa das células iniciais que não sejam da mesma cor do jogador e se for reinicializar as células da cor atual do jogador
            if (!isEmpty && _boardManager.currentCell.color != _boardManager.player.playerInk)
            {
                _boardManager.ResetCells(_boardManager.player.playerInk);
                _boardManager.player.playerInk = colors.none;
                return;
            }

            //Verificar se o jogador está a entrar numa célula que já tenha sido pintada pela cor atual e se for reinicializar as células dessa cor
            if (color == _boardManager.player.playerInk && _boardManager.currentCell.isEmpty)
            {                
                _boardManager.player.playerInk = colors.none;
                _boardManager.mousePressed = false;
                _boardManager.ResetCells(_boardManager.currentCell.color);
            }

            //Verificar se o jogador conseguiu com sucesso fazer uma conexão e ligar as luzes e fazer o camera shake de acordo com o resultado
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
                _boardManager.startingCell = null;
                _boardManager.player.playerInk = colors.none;
                _boardManager.CheckSolution();
                _boardManager.CheckLight();
                _boardManager.CameraShake();
            }

            //Pintar a célula na qual se entra da cor atual do jogador
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

            //Aplicar a troca de cores necessária
            SwitchColor();
        }
    }

    void OnMouseExit()
    {
        //Detetar qual a célula de onde se saiu para guarda numa variável
        if(isEmpty && _boardManager.mousePressed && _boardManager.player.playerInk != colors.none)
            _boardManager.previousCell = this;        
    }

    public void SwitchColor()
    {
        //Função para aplicar as cores necessárias a cada célula
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
