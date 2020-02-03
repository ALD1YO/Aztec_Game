using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    Detector Detector;
    Collider col;

    public bool punch;

    private void Start()
    {
        Detector = transform.parent.GetComponentInChildren<Detector>();
        if (Detector == null)
        {
            Debug.LogWarning("No se detecto Detector!");
        }
        col = GetComponent<Collider>();
        if (col == null)
        {
            Debug.LogWarning("No se detecto colision!");
        }
        col.enabled = false;
    }

    private void Update()
    {
        hitCheck();

        punch = Detector.close;
    }

    void hitCheck()
    {
        if (punch)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
