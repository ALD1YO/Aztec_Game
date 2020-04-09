using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaritoVolar : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name== "sinsonte_idle")
        {
            Debug.Log("vas bien papu");
        }
    }
}
