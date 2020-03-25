using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    bool walking;
    bool backwards;
    bool walking_L;
    bool walking_R;
    bool run;
    bool fireMagicAttack;
    bool earthMagicAttack;
    bool pausa;
    bool Combat;

    int spellLightValue;

    [HideInInspector]
    public bool puedeCorrer;
    [HideInInspector]
    public bool puedeAtacar;
    [HideInInspector]
    public bool estaAtacando;
    [HideInInspector]
    public bool puedeCaminar;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        puedeCaminar = true;
        estaAtacando = false;
        puedeAtacar = true;
        walking = false;
        backwards = false;
        walking_L = false;
        walking_R = false;
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        pausa = G_Singleton.instance.pausa;

        if (pausa == false)
        {
            animMoves();
            animAttacks();
        }

        anim.SetBool("Walking", walking);
        anim.SetBool("Backwards", backwards);
        anim.SetBool("Walking_L", walking_L);
        anim.SetBool("Walking_R", walking_R);
        anim.SetBool("Fire_Magic_Attack", fireMagicAttack);
        anim.SetBool("Earth_Magic_Attack", earthMagicAttack);
        anim.SetBool("Run", run);

        spellLightValue = P_Singleton.instance.currentSpellValue;
    }
    
    void animMoves()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //AudioManager.instance.Play("Pisadas");
            walking = true;
            backwards = false;
            walking_L = false;
            walking_R = false;
            puedeAtacar = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //AudioManager.instance.Play("Pisadas");
            walking = false;
            backwards = true;
            walking_L = false;
            walking_R = false;
            puedeAtacar = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //AudioManager.instance.Play("Pisadas");
            walking = false;
            backwards = false;
            walking_L = true;
            walking_R = false;
            puedeAtacar = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //AudioManager.instance.Play("Pisadas");
            walking = false;
            backwards = false;
            walking_L = false;
            walking_R = true;
            puedeAtacar = false;
        }
        else
        {
            //AudioManager.instance.Stop("Pisadas");
            walking_R = false;
            walking_L = false;
            walking = false;
            backwards = false;
            puedeAtacar = true;
        }
            
        if (Input.GetKey(KeyCode.LeftShift) && puedeCorrer)
        {
            if (walking)
                run = true;
        }
        else
            run = false;
    }
    void animAttacks()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (puedeAtacar && estaAtacando == false && spellLightValue == 1)
            {
                puedeCaminar = false;
                estaAtacando = true;
                fireMagicAttack = true;
                puedeAtacar = false;
                StartCoroutine(stopMagicAttack());
            }
            if (puedeAtacar && estaAtacando == false && spellLightValue == 2)
            {
                puedeCaminar = false;
                estaAtacando = true;
                earthMagicAttack = true;
                puedeAtacar = false;
                StartCoroutine(stopMagicAttack());
            }
        }
    }
    IEnumerator stopMagicAttack()
    {
        yield return new WaitForSeconds(2.1f);
        fireMagicAttack = false;
        earthMagicAttack = false;
        estaAtacando = false;
        puedeAtacar = true;
        puedeCaminar = true;
    }
}
