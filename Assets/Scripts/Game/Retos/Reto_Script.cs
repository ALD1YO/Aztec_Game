using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reto_Script : MonoBehaviour
{
    public CanvasGroup CGP;

    bool activador;

    float alpha;

    private void Start()
    {
        activador = false;
        alpha = -1f;
    }

    private void Update()
    {
        activate_Orbe();
        show_Player();
    }

    void show_Player()
    {
        if (activador)
        {
            alpha = 1f;
        }
        else
        {
            alpha = -1f;
        }

        CGP.alpha = Mathf.Clamp01(CGP.alpha + alpha * Time.deltaTime);
    }
    void activate_Orbe()
    {
        if (activador)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                G_Singleton.instance.setOrbe(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            activador = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            activador = false;
        }
    }
}
