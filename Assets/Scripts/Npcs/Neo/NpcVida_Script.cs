using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcVida_Script : MonoBehaviour
{
    public float vida = 100f;

    public Image healthBar;


    private void Start()
    {
        
    }

    private void Update()
    {
        healthBar.fillAmount = vida / 100f;

        if (vida <= 0f)
        {
            StartCoroutine(goUp());
        }
    }
    IEnumerator goUp()
    {
        transform.Translate(Vector3.up * -100);
        yield return new WaitForSeconds(0.5f);
        Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hit")
        {
            vida = vida - 20f;
            Debug.Log("Auch");
        }
    }
}
