using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Trigger : MonoBehaviour
{
    public GameObject hitbox;

    public bool combatIdle;
    bool combatPunch1;
    bool combatPunch2;
    bool combatPunch3;
    bool combatPunching;
    bool pausa;

    public float punchTime;

    int currentEnemies;

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

        currentEnemies = P_Singleton.instance.currentEnemies;
        pausa = G_Singleton.instance.pausa;

        if (pausa == false)
        {
            animAttack();
            inCombat();
        }

        anim.SetBool("Combat Idle", combatIdle);
        anim.SetBool("Punching", combatPunching);
        anim.SetBool("Punch1", combatPunch1);
        anim.SetBool("Punch2", combatPunch2);
        anim.SetBool("Punch3", combatPunch3);
    }
    void animAttack()
    {
        if (Input.GetMouseButtonDown(0) && combatIdle) 
        {
            P_Singleton.instance.setCurrentEnemiesLessOne(1);
            hitbox.SetActive(true);
            StartCoroutine(hitBoxOff());
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
    void inCombat()
    {
        if(currentEnemies >= 1)
        {
            combatIdle = true;
        }
        else
        {
            combatIdle = false;
        }
    }
    IEnumerator hitBoxOff()
    {
        yield return new WaitForSeconds(0.05f);
        hitbox.SetActive(false);
        if (combatPunch3)
        {
            yield return new WaitForSeconds(0.5f);
            combatPunching = false;
            combatPunch1 = false;
            combatPunch2 = false;
            combatPunch3 = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyD")
        {
            P_Singleton.instance.setCurrentEnemiesPlusOne(1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyD")
        {
            P_Singleton.instance.setCurrentEnemiesLessOne(1);
        }
    }
}
