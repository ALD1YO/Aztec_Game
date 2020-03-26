using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Real_circle_movement : MonoBehaviour
{


    public float h_speed= 50;
    public float v_speed = 50;

    void Update()
    {
        transform.Translate(h_speed * Time.deltaTime, v_speed * Time.deltaTime, 0);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Right_place")
        {
            Debug.Log("La derecha");
            h_speed = -h_speed;
            v_speed = 0;
        }

        if (collision.gameObject.name == "Left_place")
        {
            Debug.Log("La izquierda");
            v_speed = 0;
        }

        if (collision.gameObject.name == "Top_place")
        {
            Debug.Log("Arriba");
            h_speed = 0;
            v_speed = -v_speed;
        }

        if (collision.gameObject.name == "Bottom_place")
        {
            Debug.Log("Abajo");
            h_speed = 0;
            
        }

        if (collision.gameObject.name == "Centro_maton")
        {
            Debug.Log("Centro");
            Destroy(gameObject);
        }


    }

}
