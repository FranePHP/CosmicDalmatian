using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingObjects : MonoBehaviour
{
    // kada nam je bool pozitivan onda nam je i objekt koji skupljamo
    // ako nam je negativan bool onda nam je to predmet koji izbjegavamo
    [Header("True = Good prefab | False = Bad prefab")]
    public bool isPositive = true;
    GameManager gm;

    private void Start()
    {
        // dodijeliti Game manager skriptu da se povezuje sa skriptom falling object tako sto
        // Unity pretrazi hijerarhiju i nade koji objekt na sebi ima GameManager skriptu
        // sluzi za povezivanje Skripti
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // radimo prvo za predmet koji player skuplja, znaci bool isPositive nam mora biti true
        if (isPositive == true)
        {
            if (other.gameObject.tag == "Player")
            {
                //pozvali smo Skriptu GameManager i od tamo smo pozvali score i uvecali ga za 1
                gm.score++;
                gm.TimeScaleObject(true);
                Destroy(this.gameObject);                

            }
            if (other.gameObject.tag == "Floor")
            {
                if (gm.score > 0)
                {
                    gm.score--;
                }

                Destroy(this.gameObject);
            }
            
        }
        // predmet koji player izbjegava
        else if (isPositive == false) 
        {
            if (other.gameObject.tag == "Player") 
            {
                gm.life--;
                gm.TimeScaleObject(false);
                Destroy(this.gameObject);
                
            }
            if (other.gameObject.tag == "Floor")
            {
                Destroy(this.gameObject);
            }            
        }
    }
}
