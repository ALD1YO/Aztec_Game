using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcVision_Script : MonoBehaviour
{
    public CanvasGroup target;

    float alpha;
    bool iSeeYou;

    private void Start()
    {
        iSeeYou = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (iSeeYou)
            alpha = 1;
        else
            alpha = -1;

        target.alpha = Mathf.Clamp01(target.alpha + alpha * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            iSeeYou = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            iSeeYou = false;
        }
    }
}
