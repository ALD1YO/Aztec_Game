using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TakeD : MonoBehaviour
{

    public Renderer rend;

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
        if (vulnerable == true)
        {
            vida = vida - damage;
            StartCoroutine(Blink(.3f, .2f));
        }
        
    }
    IEnumerator Blink(float duration, float blinkTime)
    {
        if (vulnerable == true)
        {
            P_Singleton.instance.setVida(vida);
            vulnerable = false;
            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                rend.enabled = !rend.enabled;
                yield return new WaitForSeconds(blinkTime);
            }
            rend.enabled = true;
            
            vulnerable = true;
        }
        
    }
}
