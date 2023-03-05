using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public void IntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("Alex");
    }
}
