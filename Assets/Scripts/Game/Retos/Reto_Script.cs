using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reto_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Tofa F para jugar");
        }
    }
}
