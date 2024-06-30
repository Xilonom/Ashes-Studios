using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
