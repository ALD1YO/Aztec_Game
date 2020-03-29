using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //Basicamente, dependiendo con el spawner que choque, será la dirección que tenga.
        //Si hay una colición con un gameobject que tenga este nombre haz esto:
        if (collision.gameObject.name == "Right_place")
        {
            h_speed = -h_speed;
            v_speed = 0;
        }

        if (collision.gameObject.name == "Left_place")
        {
            v_speed = 0;
        }

        if (collision.gameObject.name == "Top_place")
        {
            h_speed = 0;
            v_speed = -v_speed;
        }

        if (collision.gameObject.name == "Bottom_place")
        {
            h_speed = 0;          
        }

        //Colisión con el Centro
        if (collision.gameObject.name == "Centro_maton")
        {
            if (collision.gameObject.GetComponent<Image>().sprite != this.GetComponent<Image>().sprite)
            {
                Debug.Log("Diferente Sprite");
            }
            Destroy(gameObject);
        }


    }

}
