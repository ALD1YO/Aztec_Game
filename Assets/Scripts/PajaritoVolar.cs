using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PajaritoVolar : MonoBehaviour
{
    bool Vuela;
    float Posx;
    float Posy;

    private void Start()
    {
        Vuela = false;   
    }

    private void Update()
    {
        if(Vuela==true)
        {
            this.transform.position = new Vector3(Posx, Posy, this.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Posx = this.transform.position.x;
            Posy = this.transform.position.y;
            Vuela = true;
            Volar();
        }
    }

    void Volar()
    {
        Debug.Log(Posx + ","+Posy);
        for(float i=0; i<=1000; i+=.01f)
        {
            Posx += .0001f;
            Posy += .0001f;
            if(i>=1000)
            {
                Vuela = false;
                Debug.Log(Vuela);
            }
        }
    }
}
