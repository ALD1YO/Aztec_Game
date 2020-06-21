using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    public bool gazingPlayer;
    bool pause;

    public GameObject target;

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        gazingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        pause = G_Singleton.instance.pausa;

        goToTarget();
        
    }
    void goToTarget()
    {
        targetPosition = new Vector3(target.transform.position.x, transform.parent.position.y, target.transform.position.z);

        if (gazingPlayer == true)
        {
            if (Vector3.Distance(transform.parent.position, target.transform.position) > stoppingDistance)
            {
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, target.transform.position, speed * Time.deltaTime);
            }
            transform.parent.LookAt(targetPosition);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("I see you");
            gazingPlayer = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Now I don't");
            gazingPlayer = false;
        }
    }*/
}
