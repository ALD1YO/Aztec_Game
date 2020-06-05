using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orbe_Controller : MonoBehaviour
{
    public CanvasGroup target;

    float alpha;

    bool pausa;
    bool orbe;

    // Start is called before the first frame update
    void Start()
    {
        alpha = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        show_orbe();
        orbe = G_Singleton.instance.orbe;
    }

    void show_orbe()
    {
        if (orbe)
        {
            alpha = 1f;
        }
        else
        {
            alpha = -1f;
        }
        target.alpha = Mathf.Clamp01(target.alpha + alpha * Time.deltaTime);
    }
}
