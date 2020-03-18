using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Velocidad=10;


    void Update()
    {

        transform.Translate(0, 0, Velocidad);
    }
}
