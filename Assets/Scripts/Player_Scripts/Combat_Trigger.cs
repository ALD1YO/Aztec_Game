using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Trigger : MonoBehaviour
{
    public GameObject hitbox;

    bool combatIdle;
    bool combatPunch1;
    bool combatPunch2;
    bool combatPunch3;
    bool combatPunching;
    bool pausa;

    public float punchTime;

    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        hitbox.SetActive(false);
    }
    private void Update()
    {
        if (anim == null)
            Debug.LogError("No se encontro animator");
        else
            Debug.Log("Se encontro animator");

        pausa = G_Singleton.instance.pausa;

        if (pausa == false)
        {
            animAttack();
        }

        anim.SetBool("Combat Idle", combatIdle);
        anim.SetBool("Punching", combatPunching);
        anim.SetBool("Punch1", combatPunch1);
        anim.SetBool("Punch2", combatPunch2);
        anim.SetBool("Punch3", combatPunch3);
    }
    void animAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitbox.SetActive(true);
            combatPunching = true;
            if (combatPunch1)
            {
                if (combatPunch2)
                {
                    combatPunch3 = true;
                    punchTime = 0f;
                }
                combatPunch2 = true;
                punchTime = 0f;
            }
            combatPunch1 = true;
        }
        if (combatPunching)
        {
            punchTime += .0025f + Time.deltaTime;
            if (punchTime >= 1.6f)
            {
                combatPunching = false;
                combatPunch1 = false;
                combatPunch2 = false;
                combatPunch3 = false;
                hitbox.SetActive(false);
                punchTime = 0f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyD")
        {
            combatIdle = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyD")
        {
            combatIdle = false;
        }
    }
}
