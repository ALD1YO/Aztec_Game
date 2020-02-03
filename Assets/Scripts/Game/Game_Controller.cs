using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{

    public GameObject Pausa;
    public CanvasGroup target;

    int enemigos;

    bool pause;

    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Stop("Intro");
        AudioManager.instance.Play("Ambiente");
        Pausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        G_Singleton.instance.Enemigos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemigos = G_Singleton.instance.Enemigos;
        pause = G_Singleton.instance.pausa;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            G_Singleton.instance.setPausa(pause);
        }
        if (enemigos >= 4)
        {
            alpha = 1f;
            StartCoroutine(goToMenu());
        }
        else
        {
            if (pause == true)
            {
                Pausa.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Pausa.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            alpha = -1f;
        }
            

        target.alpha = Mathf.Clamp01(target.alpha + alpha * Time.deltaTime);

    }

    public void backToGame()
    {
        pause = !pause;
        G_Singleton.instance.setPausa(pause);
    }

    IEnumerator goToMenu()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Menu");
    }
}
