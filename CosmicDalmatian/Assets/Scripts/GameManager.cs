using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // za spajanje vise Scena
using TMPro; // za koristenje teksta
using UnityEngine.UI; // za sve ostale stvari na UI, npr. za Button

public class GameManager : MonoBehaviour
{
    public int score = 0; // broj bodova
    public int life = 3; // broj zivota
    public TMP_Text scoreText;
    public TMP_Text lifeText;

    // ubacena vremenska komponenta - da se ubrzava ili usporava vrijeme -
    // ovisno o tome da li pokupimo Good ili Bad object -> posebna metoda TimeScaleObject()
    float vrijeme; 
    [SerializeField] Text timer;

    private void Update()
    {
        Debug.Log("Score je: " + score + ", a life je: " + life);
        scoreText.text = "Score is: " + score;
        lifeText.text = "Life: " + life + " /3 ";

        vrijeme += Time.deltaTime;
        timer.text = vrijeme + "\n" + Time.timeScale;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // za izlazak iz aplikacije
            Debug.Log("Izaslo je");
        }

        ScoreLifeCheck();
    }

    private void ScoreLifeCheck()
    {
        if (life <= 0)
        {
            Debug.Log("Izgubio si");
            SceneManager.LoadScene("MainMenu");
           // Application.Quit();
        }

        if (score == 0)
        {
            Debug.Log("Game started"); // ucitavamo Scenu za Level 1, igra krece
        }

        if (score == 15)
        {
            SceneManager.LoadScene("Level_02"); // ucitavamo Scenu za Level 2
            Debug.Log("You are Level 2");
        }

        if (score == 20)
        {
            SceneManager.LoadScene("Level_03"); // ucitavamo Scenu za Level 3
            Debug.Log("You are Level 3");
        }

        if (score > 30)
        {
            Debug.Log("You won the game");
        }
    }

    public void TimeScaleObject(bool isPos)
    {


        if (isPos == true)
        {
            Time.timeScale += 0.2f;
            Debug.Log("dodano 0.2 vremena");
        }
        if (isPos == false)
        {
            Time.timeScale -= 0.1f;
            Debug.Log("oduzeto 0.1 vremena");
        }
        Debug.Log(Time.timeScale);
    }

}
