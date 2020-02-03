using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    float vida;
    float energia;
    float mana;

    bool pausa;

    public float atackTimer;

    public int currentSpellValue;

    string currentSpell;

    public Light spellLight;
    public Color spellLightValue;

    public Slider sliderEnergia;
    public Slider sliderVida;

    public Image EQIcon;
    public Image FBIcon;
    public Image NullIcon;

    public bool No_Spell;
    public bool Fire_Spell;
    public bool Water_Spell;
    public bool Earth_Spell;
    public bool Wind_Spell;

    public bool ataca;
    public bool Idle;
    public bool ataca2;

    // Start is called before the first frame update
    void Start()
    {
        EQIcon.enabled = false;
        FBIcon.enabled = false;
        NullIcon.enabled = true;

        ataca = false;
        ataca2 = false;
        Idle = true;

        G_Singleton.instance.pausa = false;
        P_Singleton.instance.currentSpellValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pausa = G_Singleton.instance.pausa;

        if (pausa == false)
        {
            mouseControll();
            checkSpells();
            updateValues();
            updateSliders();
        }
    }

    void checkSpells()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentSpellValue = currentSpellValue + 1;

            if (currentSpellValue >= 3)
            {
                currentSpellValue = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentSpellValue = currentSpellValue - 1;

            if (currentSpellValue <= -1)
            {
                currentSpellValue = 2;
            }

        }

        switch (currentSpellValue)
        {
            case 0:
                NullIcon.enabled = true;
                EQIcon.enabled = false;
                FBIcon.enabled = false;
                break;
            case 1:
                NullIcon.enabled = false;
                EQIcon.enabled = false;
                FBIcon.enabled = true;
                break;
            case 2:
                NullIcon.enabled = false;
                EQIcon.enabled = true;
                FBIcon.enabled = false;
                break;
            default:
                NullIcon.enabled = true;
                break;
        }

        spellLight.color = spellLightValue;
        P_Singleton.instance.setCurrentSpellValue(currentSpellValue);
        P_Singleton.instance.setCurrentSpellLight(currentSpellValue);


    }
    void updateSliders()
    {
        sliderEnergia.value = energia;
        sliderVida.value = vida;
    }

    void updateValues()
    {
        vida = P_Singleton.instance.vida;
        energia = P_Singleton.instance.stamina;
        mana = P_Singleton.instance.mana;
        currentSpellValue = P_Singleton.instance.currentSpellValue;
        spellLightValue = P_Singleton.instance.spellLight;
        No_Spell = P_Singleton.instance.No_Spell;
        Fire_Spell = P_Singleton.instance.Fire_Spell;
        Water_Spell = P_Singleton.instance.Water_Spell;
        Earth_Spell = P_Singleton.instance.Earth_Spell;
        Wind_Spell = P_Singleton.instance.Wind_Spell;
    }

    void mouseControll()
    {
        if (atackTimer == 0)
        {
            ataca = false;
            ataca2 = false;
            Idle = true;
        }

        if (Idle == true)
        {

            if (Input.GetMouseButton(0))
            {
                atackTimer = atackTimer + Time.deltaTime;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (atackTimer >= .7f)
                {
                    Idle = false;
                    ataca2 = true;
                    ataca = false;
                    StartCoroutine(returnIdleTimer());
                }
                else
                {
                    ataca = true;
                    ataca2 = false;
                    Idle = false;
                    StartCoroutine(returnIdleTimer());
                }
            }
        }
    }

    IEnumerator returnIdleTimer()
    {
        yield return new WaitForSeconds(.7f);
        atackTimer = 0;
    }
}
