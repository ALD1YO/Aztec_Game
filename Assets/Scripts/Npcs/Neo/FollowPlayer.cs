using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Animator anim;

    public GameObject hitBox;

    int esteRandom;

    public float speed;
    public float stoppingDistance;

    public bool gazingPlayer;
    bool pause;

    bool walk;
    public bool attack;
    float attackTime;
    bool combat;
    bool canMove;
    bool der;
    bool izq;
    bool closeenough;
    bool directionchange;

    public GameObject target;

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        hitBox.SetActive(false);
        combat = false;
        canMove = true;
        directionchange = false;
        gazingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        pause = G_Singleton.instance.pausa;

        goToTarget();
        IA();
        anim.SetBool("Walk", walk);
        anim.SetBool("Combat", combat);
        anim.SetBool("Walk_L", izq);
        anim.SetBool("Walk_R", der);
        anim.SetBool("Attack", attack);
    }
    void goToTarget()
    {
        targetPosition = new Vector3(target.transform.position.x, transform.parent.position.y, target.transform.position.z);

        if (gazingPlayer == true)
        {
            combat = true;
            if (Vector3.Distance(transform.parent.position, target.transform.position) >= stoppingDistance)
            {
                walk = true;
                closeenough = false;
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, target.transform.position, speed * Time.deltaTime);
            }
            else
            {
                walk = false;
                closeenough = true;
            }
            transform.parent.LookAt(targetPosition);
        }
        else
            combat = false;
    }

    void IA()
    {
        if (directionchange == false)
        {
            StartCoroutine(resetDirection());
            directionchange = true;
        }
        if (closeenough && canMove)
        {
            if (der)
            {
                transform.parent.RotateAround(target.transform.position, Vector3.up, (speed * 12) * Time.deltaTime);
            }
            else if (izq)
            {
                transform.parent.RotateAround(target.transform.position, Vector3.down, (speed * 12) * Time.deltaTime);
            }

            if (attackTime >= 3.6f)
            {
                canMove = false;
                izq = false;
                der = false;
                hitBox.SetActive(true);
                StartCoroutine(hitBoxOff());
                attack = true;
                attackTime = 0f;
            }
            else
            {
                attack = false;
                attackTime += .0025f + Time.deltaTime;
            }
        }
    }

    IEnumerator resetDirection()
    {
        yield return new WaitForSeconds(1.8f);
        if (closeenough)
        {
            if (esteRandom >= 5)
            {
                izq = false;
                der = true;
            }
            else
            {
                der = false;
                izq = true;
            }
        }
        yield return new WaitForSeconds(2f);
        esteRandom = Random.Range(0, 10);
        directionchange = false;
    }

    IEnumerator hitBoxOff()
    {
        yield return new WaitForSeconds(0.05f);
        hitBox.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        canMove = true;
    }
}
