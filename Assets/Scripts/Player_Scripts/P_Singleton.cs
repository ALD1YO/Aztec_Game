using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Singleton : MonoBehaviour
{
    public static P_Singleton instance;

    public float vida;
    public float stamina;
    public float mana;

    public int currentSpellValue;
    public int currentEnemies;

    public bool No_Spell;
    public bool Fire_Spell;
    public bool Water_Spell;
    public bool Earth_Spell;
    public bool Wind_Spell;

    public Color spellLight;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void setVida(float _vida)
    {
        vida = _vida;
    }
    public void setStamina(float _stamina)
    {
        stamina = _stamina;
    }
    public void setMana(float _mana)
    {
        mana = _mana;
    }
    public void setNoSpell(bool noSpell)
    {
        No_Spell = noSpell;
    }
    public void setFireSpell(bool fire)
    {
        Fire_Spell = fire;
    }
    public void setWindSpell(bool wind)
    {
        Wind_Spell = wind;
    }
    public void setEarthSpell(bool earth)
    {
        Earth_Spell = earth;
    }
    public void setWaterSpell(bool water)
    {
        Water_Spell = water;
    }
    public void setCurrentSpellValue(int current)
    {
        currentSpellValue = current;
    }
    public void setCurrentSpellLight(int current)
    {
        switch (current)
        {
            case 0:
                spellLight = new Color32(150, 150, 150, 255);
                break;
            case 1:
                spellLight = new Color32(255, 0, 40, 255);
                break;
            case 2:
                spellLight = new Color32(110, 75, 15, 255);
                break;
            default:
                spellLight = new Color32(150,150, 150, 255);
                break;
        }
    }
    public void setCurrentEnemiesPlusOne(int current)
    {
        currentEnemies = currentEnemies + current;
    }
    public void setCurrentEnemiesLessOne(int current)
    {
        currentEnemies = currentEnemies - current;
    }
}
