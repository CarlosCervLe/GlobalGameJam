using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform personaje;

    void Update()
    {
        transform.position = new Vector3(personaje.position.x, personaje.position.y + 2, -1);
    }
}