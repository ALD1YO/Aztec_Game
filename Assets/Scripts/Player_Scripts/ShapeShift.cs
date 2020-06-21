using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShift : MonoBehaviour
{
    public GameObject Mesh_Guerrero;
    public GameObject Mesh_Jaguar;
    public ThirdPerson ThirdP_script;
    private bool coolDown = false;

    public Transform _camera;
    public float posicion_camara;

    public bool EsJaguar=false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !coolDown)
        {
            EsJaguar = !EsJaguar;
            Cambiar_Forma(Mesh_Guerrero, Mesh_Jaguar);
        }
        
    }

    void Cambiar_Forma(GameObject Mesh_guerrero, GameObject Mesh_jaguar)
    {
        if (Mesh_guerrero.activeSelf==!false)
        {
            posicion_camara = -0.8f;
            print("Cambiando forma a jaguar");
            Mesh_jaguar.SetActive(true);
            Mesh_guerrero.SetActive(false);
            

        }
        else
        {
            posicion_camara = 0.354f;
            print("Cambiando forma a guerrero");
            Mesh_jaguar.SetActive(false);
            Mesh_guerrero.SetActive(true);
            //_camera.transform.Translate(0, posicion_camara, 0);
            //_camera.transform.localPosition = new Vector3(0, posicion_camara, 0);
        }
        
        StartCoroutine(Cooldown());
        
    }

    public IEnumerator Cooldown()
    {
        coolDown = true;
        yield return new WaitForSeconds(2.0f);
        coolDown = false;
    }

}
