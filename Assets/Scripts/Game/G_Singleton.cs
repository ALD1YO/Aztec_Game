using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Singleton : MonoBehaviour
{

    public static G_Singleton instance;

    public bool pausa;
    public int Enemigos;
    public bool orbe;

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

    public void setPausa(bool _pausa)
    {
        pausa = _pausa;
    }
    public void setEnemigos(int _enemigos)
    {
        Enemigos += _enemigos;
    }
    public void setOrbe(bool _orbe)
    {
        orbe = _orbe;
    }
}
