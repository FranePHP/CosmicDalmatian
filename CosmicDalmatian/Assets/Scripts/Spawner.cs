using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] prefabs; // predmet koji se stvara
    public float timer = 1f; // vremenski period za spawnanje objekata
    float timerReset; // vracanje timera na pocetak
    int spawnCount; // broj koliko smo prefaba stvorili

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            // varijabla u koju ce se spremati nasumicni broj (random number)
            float randomPozicijaX = Random.Range(-18f, 18f); // naredba koja uzima random number od -18 do 18 jer smo tako odredili
            int randomIndex = Random.Range(0, prefabs.Length); // odabir slucajnog indeksa iz polja
            GameObject selectPrefab = prefabs[randomIndex]; // 

            // stvaramo nas prefab na X poziciji na broju koji dobijemo od Random range
            // na Y poziciji nas prefab stvaramo na 15 jer treba biti visoko
            // z pozicija je 0, stavljamo quaternion.identity jer rotacija ostaje ista
            Instantiate(selectPrefab, new Vector3(randomPozicijaX, 15, 0), Quaternion.identity);
            spawnCount++;
            timer = timerReset;
        }

        // svakih 13 stvorenih mi ubrzavamo vrijeme za 10%
        if (spawnCount == 13 && timerReset > 0.7f) 
        {
            timerReset *= 0.9f;
            spawnCount = 0;
        }
    }
}
