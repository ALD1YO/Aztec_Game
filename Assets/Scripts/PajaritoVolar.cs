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
            t1 += .4f * Time.deltaTime;
            t2 += .1f * Time.deltaTime;
            this.transform.position = new Vector3(Mathf.Lerp(Posx, Posx + 20, t1), Mathf.Lerp(Posy, Posy + 20, t2), this.transform.position.z);
            AnimacionVolar.Play("volar");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Posx = this.transform.position.x;
            Posy = this.transform.position.y;
            Activo = true;
            Debug.Log("entramos");
        }
    }
}


