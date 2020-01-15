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

    private LineRenderer _line;

    void Start()
    {
        //_line = GetComponent<LineRenderer>();

        _spawnedParticles = Instantiate(particlePrefab, Vector3.zero, Quaternion.identity);
        _spawnedParticles.SetActive(false);
    }

    void Update()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = 1.5f;
        _worldPos = Camera.main.ScreenToWorldPoint(_mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            _spawnedParticles.SetActive(true);
            //_line.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _spawnedParticles.SetActive(false);
            //_line.enabled = false;
            //_line.positionCount = 1;
        }

        //_line.SetPosition(_line.positionCount - 1, _worldPos);

        _spawnedParticles.transform.position = _worldPos;
    }

    public void EnteredCell(Cell cell)
    {
        _line.SetPosition(_line.positionCount - 1, cell.transform.position);
        _line.positionCount++;
    }

    public void SetStartingCell(Cell cell)
    {
        _line.SetPosition(0, cell.transform.position);
        _line.startColor = _line.endColor = cell.GetComponent<SpriteRenderer>().color;
        _line.positionCount++;
    }
}
