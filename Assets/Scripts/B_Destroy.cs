using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Destroy : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(destroythisObject());
    }
    IEnumerator destroythisObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(transform.gameObject);
    }
}
