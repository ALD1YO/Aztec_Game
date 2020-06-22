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
        combatPunching = false;
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

        anim.SetBool("Combat", combatIdle);
        anim.SetBool("Attack", combatPunching);

    }
    void animAttack()
    {
        if (Input.GetMouseButtonDown(0) && combatIdle && combatPunching == false) 
        {
            if(currentEnemies>=6)
                P_Singleton.instance.setCurrentEnemiesLessOne(2);
            else
                P_Singleton.instance.setCurrentEnemiesLessOne(1);

            hitbox.SetActive(true);
            StartCoroutine(hitBoxOff());
            combatPunching = true;
        }
        if (combatPunching)
        {
            punchTime += .0025f + Time.deltaTime;
            if (punchTime >= 1.6f)
            {
                combatPunching = false;
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
