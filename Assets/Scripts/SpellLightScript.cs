using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLightScript : MonoBehaviour
{
    Light thisLight;

    // Start is called before the first frame update
    void Start()
    {
        thisLight = GetComponent<Light>();
        if (thisLight == null)
            Debug.LogWarning("La bala no detecto luz!");
        thisLight.color = P_Singleton.instance.spellLight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
