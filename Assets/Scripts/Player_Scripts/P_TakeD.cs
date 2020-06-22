using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TakeD : MonoBehaviour
{
    bool vulnerable;
    float vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = P_Singleton.instance.vida;
        vulnerable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        if (vulnerable)
        {
            vida = vida - damage;
            StartCoroutine(Blink(.3f, .2f));
        }
        
    }
    IEnumerator Blink(float duration, float blinkTime)
    {
        if (vulnerable)
        {
            P_Singleton.instance.setVida(vida);
            vulnerable = false;
            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return new WaitForSeconds(blinkTime);
            }
            vulnerable = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyHit")
        {
            takeDamage(15);
        }
    }
}
