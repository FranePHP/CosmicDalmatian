using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void GameScene() 
    {
        SceneManager.LoadScene("Level_01");
    }

    public void ExitGame() 
    {
        Application.Quit();
        Debug.Log("Izasao");
    }

}
