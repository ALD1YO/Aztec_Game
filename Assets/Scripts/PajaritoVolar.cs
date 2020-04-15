using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PajaritoVolar : MonoBehaviour
{

    public GameObject Pajarito;

    void Start()
    {
        Debug.Log("inicio");
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("vas bien papu");
            Pajarito.transform.position = new Vector3(2,2,1);
        }
    }
}
