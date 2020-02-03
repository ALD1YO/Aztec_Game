using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Atack : MonoBehaviour
{
    public GameObject damage;

    public float atackTimer;

    public bool ataca;
    public bool Idle;
    public bool ataca2;

    // Start is called before the first frame update
    void Start()
    {
        damage.SetActive(false);
        ataca = false;
        ataca2 = false;
        Idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (atackTimer == 0)
        {
            damage.SetActive(false);
            ataca = false;
            ataca2 = false;
            Idle = true;
        }

        if (Idle == true)
        {
            if (Input.GetMouseButton(0))
            {
                atackTimer = atackTimer + Time.deltaTime;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (atackTimer >= .7f)
                {
                    Idle = false;
                    ataca2 = true;
                    ataca = false;
                    StartCoroutine(returnIdleTimer());
                }
                else
                {
                    damage.SetActive(true);
                    ataca = true;
                    ataca2 = false;
                    Idle = false;
                    StartCoroutine(returnIdleTimer());
                }
            }
        }
        else
        {
            if (ataca == true)
            {
            }
            if (ataca2 == true)
            {
            }
        }
    }

    IEnumerator returnIdleTimer()
    {
        yield return new WaitForSeconds(.8f);
        atackTimer = 0;
    }
}
