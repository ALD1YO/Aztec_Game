using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mini_game_Inputs : MonoBehaviour
{
    public Sprite Color_Rojo;
    public Sprite Color_Azul;
    public Sprite Color_Amarillo;
    public Sprite Color_Verde;


    [SerializeField]
    private Place_spawn Color_Del_Centro;
    private enum Place_spawn { Red, Blue, Green, Yellow }

    void Start()
    {
       
    }


    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            
            this.GetComponent<Image>().sprite = Color_Rojo;
            Color_Del_Centro = Place_spawn.Red;
            print("space key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<Image>().sprite = Color_Rojo;
            Color_Del_Centro = Place_spawn.Red;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            this.GetComponent<Image>().sprite = Color_Azul;
            Color_Del_Centro = Place_spawn.Blue;

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<Image>().sprite = Color_Verde;
            Color_Del_Centro = Place_spawn.Green;

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<Image>().sprite = Color_Amarillo;
            Color_Del_Centro = Place_spawn.Yellow;

        }

    }

    

}
