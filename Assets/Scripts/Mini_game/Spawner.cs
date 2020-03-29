﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    //Son los prefabs del minijuego
    public GameObject Bola_Azul;
    public GameObject Bola_Roja;
    public GameObject Bola_Amarilla;
    public GameObject Bola_Verde;

    //Son las posiciones de los spawners
    public Transform Arriba_spawn;
    public Transform Derecha_spawn;
    public Transform Izquierda_spawn;
    public Transform Abajo_spawn;

    //Son donde se guardará la posición para no escribir un chorote al invocar los prefabs
    private Vector3 Derecha;
    private Vector3 Arriba;
    private Vector3 Abajo;
    private Vector3 Izquierda;

    public float Time_To_Start_Game;


    private void Awake()
    {
        //Se asignan los lugares de spawn, donde aparecera, a las posiciones de los objetos vacios por medio de Vector3
        //Con esto se puede ajustar la posicion de los spawners
        Arriba = Arriba_spawn.transform.position;
        Derecha = Derecha_spawn.transform.position;
        Izquierda = Izquierda_spawn.transform.position;
        Abajo = Abajo_spawn.transform.position;
    }

    //Simplemente se inicia la corutina del juego
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