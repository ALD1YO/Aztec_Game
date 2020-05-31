using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PajaritoVolar : MonoBehaviour
{
    bool Activo;

    public GameObject Pajaro;
    public AnimationClip Volar;
    private Animation AnimacionVolar;

    float Posx;
    float Posy;
    float Posz;
    float Playerx;
    float Playerz;
    float ResMorrPajx;
    float ResMorrPajz;
    float AdelanteOAtras;
    float DerechaOIzquierda;
    float t1;
    float t2;

    private void Start()
    {
        Activo = false;
        AnimacionVolar = Pajaro.AddComponent<Animation>();
        AnimacionVolar.AddClip(Volar, "volar");
        Volar.legacy = true;
    }

    private void Update()
    {
        if (Activo)
        {
            t1 += .15f * Time.deltaTime;
            t2 += .09f * Time.deltaTime;
            this.transform.position = new Vector3(Mathf.Lerp(Posx, Posx + AdelanteOAtras, t1), Mathf.Lerp(Posy, Posy + 80, t2), Mathf.Lerp(Posz,Posz+0,t1));
            AnimacionVolar.Play("volar");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Posx = this.transform.position.x;
            Posy = this.transform.position.y;
            Posz = this.transform.position.z;
            Activo = true;
            Playerx = collision.transform.position.x;
            Playerz = collision.transform.position.z;
            ResMorrPajx = Playerx - Posx;
            ResMorrPajz = Playerz - Posz;
           
            if(ResMorrPajx<0)
            {
                AdelanteOAtras = Random.Range(1,100);
                if(ResMorrPajz<0)
                {
                    DerechaOIzquierda = Random.Range(1,100);
                }
                if(ResMorrPajz>0)
                {
                    DerechaOIzquierda = Random.Range(-1,-100);
                }
            }

            if (ResMorrPajx > 0)
            {
                AdelanteOAtras = Random.Range(-1,-100);
                if (ResMorrPajz < 0)
                {
                    DerechaOIzquierda = Random.Range(-1, -100);
                }
                if (ResMorrPajz > 0)
                {
                    DerechaOIzquierda = Random.Range(1, 100);
                }
            }
            
           
        }
    }
}


