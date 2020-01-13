using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public colors playerInk;

    public GameObject particlePrefab;
    private GameObject _spawnedParticles;

    Vector3 mousePos;
    Vector3 worldPos;

    void Start()
    {
        _spawnedParticles = Instantiate(particlePrefab, Vector3.zero, Quaternion.identity);
        _spawnedParticles.SetActive(false);
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 1.5f;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            _spawnedParticles.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _spawnedParticles.SetActive(false);
        }

        _spawnedParticles.transform.position = worldPos;
    }
}
