using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_player_movement : MonoBehaviour
{

    public ShapeShift _shapeshift;
    public P_Anim _p_anim;
    public Animator _Menu_Camara_Animacion;
    public ThirdPerson _ThirdPerson;
    private bool JuegoEmpezado = false;
    public GameObject Camara_Principal;
    public GameObject Camara_Menu;
    public GameObject Player_Canvas;

    // Update is called once per frame
    private void Start()
    {
        //_shapeshift = _shapeshift.GetComponent<ShapeShift>();
        //_Menu_Camara_Animacion = _Menu_Camara_Animacion.GetComponent<Animator>();
    }

    void Update()
    {
        //Con esto se quita el menu e inicia el juego
        if (Input.GetKeyDown(KeyCode.Space) && !JuegoEmpezado)
        {
            JuegoEmpezado = true;

            //Activa el movimiento de la cámara e incia un countdown para activar los controles
            _Menu_Camara_Animacion.Play("Cam_Animation", -1, 0.0f);
            StartCoroutine(Activar_Movimiento());
        }

    }

     IEnumerator Activar_Movimiento()
    {
        //Codigo de empezar animacion de cámara

        yield return new WaitForSeconds(4.0f);
        print("Se inicia el juego");
        _shapeshift.enabled = true;
        _p_anim.enabled = true;
        _ThirdPerson.enabled = true;
        Player_Canvas.SetActive(true);
        //Camara_Principal.SetActive(true);
        //Camara_Menu.SetActive(false);
    }
}
