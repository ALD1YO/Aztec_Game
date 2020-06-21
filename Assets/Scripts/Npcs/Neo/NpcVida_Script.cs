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
        yield return new WaitForSeconds(0.9f);
        P_Singleton.instance.setCurrentEnemiesLessOne(3);
        Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag )
        {
            vida = vida - 20f;
            Debug.Log("Auch");
        }
    }
}
