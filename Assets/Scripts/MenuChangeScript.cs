using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuChangeScript : MonoBehaviour
{
    public Text text;
    public Slider slider;
    public GameObject PanelOptions;
    public GameObject PanelMenu;

    public GameObject target;

    private void Start()
    {
        target.SetActive(false);
    }
    public void ve_a_ensamblador(string scene)
    {
        target.SetActive(true);
        text.text = "Loading...";
        Debug.Log("Voy a cambiar puto");
        StartCoroutine(CargandoxD(scene));
    }
    IEnumerator CargandoxD(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void ActivePanelOpcion()
    {
        PanelMenu.gameObject.SetActive(false);
        PanelOptions.gameObject.SetActive(true);
    }

    public void ActivePanelMenu()
    {
        PanelMenu.gameObject.SetActive(true);
        PanelOptions.gameObject.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
