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

    //private enum Place_spawn { Red, Blue, Green, Yellow }
    //private Place_spawn Color_Del_Centro;
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

    

}
