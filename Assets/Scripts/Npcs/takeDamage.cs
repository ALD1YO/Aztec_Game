using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{

    //public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            Destroy(transform.parent.gameObject);
            //Destroy(thisObject);
            Debug.Log("Auch");
        }
        else if (other.gameObject.tag == "Bullet" && transform.parent.gameObject.tag == "EnemyD")
        {
            G_Singleton.instance.setEnemigos(1);
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bullet" && P_Singleton.instance.currentSpellValue == 1
            && transform.parent.gameObject.tag == "EnemyW")
        {
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bullet" && P_Singleton.instance.currentSpellValue == 2
            && transform.parent.gameObject.tag == "EnemyA")
        {
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bullet" && P_Singleton.instance.currentSpellValue == 4
            && transform.parent.gameObject.tag == "EnemyE")
        {
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
        }
    }
}
