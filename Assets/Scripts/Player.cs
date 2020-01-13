using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public colors playerInk;

    public GameObject particlePrefab;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 1.5f;
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(particlePrefab, worldPos, Quaternion.identity);
        }
    }
}
