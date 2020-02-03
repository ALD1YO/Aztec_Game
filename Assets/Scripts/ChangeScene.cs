using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changeScene(string sceneName)
    {
        AudioManager.instance.Stop("Intro");
        SceneManager.LoadScene(sceneName);
    }
}
