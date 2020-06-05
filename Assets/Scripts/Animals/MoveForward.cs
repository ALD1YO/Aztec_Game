
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Velocidad=10;
    public GameObject venado;

    void Update()
    {
        transform.Translate(0, 0, Velocidad);
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //Velocidad = 0.2f;
        }

        if(collision.gameObject.name=="Terrain")
        {
            //venado.BoxCollider
        }
    }
}
