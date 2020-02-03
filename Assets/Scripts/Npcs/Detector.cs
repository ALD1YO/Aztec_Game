using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Animator anim;

    public float speed;
    float waitTime;
    float searchTime;
    public float attackTime;
    public float returnAttackTime;
    public float startWaitTime;
    public float stoppingDistance;

    bool gazingPlayer;
    public bool isPatrol;
    bool patroling;
    bool detection;
    bool moving;
    [HideInInspector]
    public bool close;
    bool searching;
    bool punch;
    [HideInInspector]
    public bool punched;

    public GameObject target;

    Vector3 targetPosition;

    public Transform[] movespots;
    int randomSpot;

    private void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        if (anim == null)
        {
            Debug.LogWarning("No detecta animador!!");
        }

        if (isPatrol == true)
        {
            patroling = true;
        }
        else
        {
            patroling = false;
        }
        waitTime = startWaitTime;
        searching = false;
        punched = false;
        randomSpot = Random.Range(0, movespots.Length);
    }

    private void Update()
    {
        goToTarget();
        patrolling();
        searchTarget();
        attackTarget();

        anim.SetBool("Patroling", patroling);
        anim.SetBool("Detection", detection);
        anim.SetBool("Searching", searching);
        anim.SetBool("Punch", punch);
        anim.SetBool("Combat", close);
    }

    void patrolling()
    {
        if (patroling == true)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, movespots[randomSpot].position, speed * Time.deltaTime);
            transform.parent.LookAt(movespots[randomSpot].position);

            if (Vector3.Distance(transform.parent.position, movespots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, movespots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }        
    }
    void goToTarget()
    {
        targetPosition = new Vector3(target.transform.position.x, transform.parent.position.y, target.transform.position.z);

        if (gazingPlayer == true)
        {
            if (Vector3.Distance(transform.parent.position, target.transform.position) > stoppingDistance)
            {
                close = false;
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, target.transform.position, speed * Time.deltaTime);
            }
            else
            {
                close = true;
            }
            transform.parent.LookAt(targetPosition);
        }
    }
    void searchTarget()
    {
        if (searching)
        {
            searchTime += Time.deltaTime;
            if (searchTime >= 4f)
            {
                searching = false;
                searchTime = 0f;
            }
        }
    }
    void attackTarget()
    {
        if (close)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= 0.8f)
            {
                punch = true;
                returnAttackTime += Time.deltaTime;
                if (returnAttackTime >= 1.25f)
                {
                    punched = true;
                    transform.parent.position = Vector3.MoveTowards(transform.parent.position,
                    -target.transform.forward, speed * Time.deltaTime);
                }
            }
        }
        else
        {
            returnAttackTime = 0f;
            attackTime = 0f;
            punch = false;
            punched = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("I see you");
            gazingPlayer = true;
            detection = true;
            searching = false;
            

            if (isPatrol == true)
            {
                patroling = false;
            }
            //transform.position = other.transform.position;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Now I don't");
            gazingPlayer = false;
            detection = false;
            searching = true;

            if (isPatrol == true)
            {
                patroling = true;
            }
            
        }
    }
}
