using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenadoHuyendo : MonoBehaviour
{

    bool Activo;

    float Posx;
    float Posz;
    float t1;
    float t2;

    void Start()
    {
        Activo = false;
    }

    void Update()
    {
        if (Activo)
        {
            t1 += .4f * Time.deltaTime;
            t2 += .1f * Time.deltaTime;
            this.transform.position = new Vector3(Mathf.Lerp(Posx, Posx + 20, t1), this.transform.position.y, Mathf.Lerp(Posz,Posz+20,t2));
        }
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Posx = this.transform.position.x;
            Posz = this.transform.position.z;
            Activo = true;
            Debug.Log(Activo);
        }
    }
}
