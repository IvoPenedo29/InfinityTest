using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public colors playerInk;

    public GameObject particlePrefab;
    private GameObject _spawnedParticles;

    private Vector3 _mousePos;
    private Vector3 _worldPos;

    void Start()
    {
        //Inicializar a variável de partículas
        _spawnedParticles = Instantiate(particlePrefab, Vector3.zero, Quaternion.identity);
        _spawnedParticles.SetActive(false);
    }

    void Update()
    {
        //Colocar as partículas na posição do input do jogador
        _mousePos = Input.mousePosition;
        _mousePos.z = 1.5f;
        _worldPos = Camera.main.ScreenToWorldPoint(_mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            _spawnedParticles.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _spawnedParticles.SetActive(false);
        }

        _spawnedParticles.transform.position = _worldPos;
    }
}
