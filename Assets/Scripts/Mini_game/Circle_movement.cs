using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle_movement : MonoBehaviour
{

    public GameObject Bola_Azul;
    public GameObject Bola_Roja;
    public GameObject Bola_Amarilla;
    public GameObject Bola_Verde;

    public Transform Arriba_spawn;
    public Transform Derecha_spawn;
    public Transform Izquierda_spawn;
    public Transform Abajo_spawn;

    public float Time_To_Start_Game;


    private Vector3 Derecha;
    private Vector3 Arriba;
    private Vector3 Abajo;
    private Vector3 Izquierda;



    private void Awake()
    {
        //Se asignan los lugares de spawn, donde aparecera, a las posiciones de los objetos vacios por medio de Vector3
        Arriba = Arriba_spawn.transform.position;
        Derecha = Derecha_spawn.transform.position;
        Izquierda = Izquierda_spawn.transform.position;
        Abajo = Abajo_spawn.transform.position;


    }

    void Start() => StartCoroutine(Tiempos()); 
 


    public IEnumerator Tiempos()
    {
        yield return new WaitForSeconds(Time_To_Start_Game);
        Instantiate(Bola_Verde, Abajo, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(Bola_Azul, Izquierda, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(Bola_Amarilla, Arriba, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(Bola_Roja, Derecha, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

        yield return new WaitForSeconds(2.0f);
        Instantiate(Bola_Amarilla, Derecha, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        yield return new WaitForSeconds(1.0f);
        Instantiate(Bola_Amarilla, Derecha, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

    }
    //Esta es la linea que hace se espere tantos segundos antes de spawnear algo
    //yield return new WaitForSeconds("Pon el tiempo aqui Yeyo");
}
