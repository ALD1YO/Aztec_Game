using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mini_game_Inputs : MonoBehaviour
{
    //Se traen los sprites para cambiar de color
    public Sprite Color_Rojo;
    public Sprite Color_Azul;
    public Sprite Color_Amarillo;
    public Sprite Color_Verde;
    //public AudioSource Turntable_turnabout;

    //private enum Place_spawn { Red, Blue, Green, Yellow }
    //private Place_spawn Color_Del_Centro;
    private void Awake()
    {
        //Turntable_turnabout.Play();
    }
    void Start() => StartCoroutine(Escala());
    void Update()
    {
        //Con los inputs cambia el sprite
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<Image>().sprite = Color_Rojo;          
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            this.GetComponent<Image>().sprite = Color_Azul;           
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<Image>().sprite = Color_Verde;         
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<Image>().sprite = Color_Amarillo;          
        }
    }


    void Small_to_big()
    {
        transform.localScale = new Vector3(1.1f,1.1f,1);
    }

    void Big_to_small()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    public IEnumerator Escala()
    {
        Small_to_big();
        yield return new WaitForSeconds(0.3f);
        Big_to_small();
        yield return new WaitForSeconds(0.3f);
        Start();

        Debug.Log("Entrando");
    }




}
