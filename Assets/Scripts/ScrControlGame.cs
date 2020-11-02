using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrControlGame : MonoBehaviour
{
    public static int punts = 0;
    public static int pickupsRestants;

    [SerializeField] Text fi;


    private void Update()
    {
        if (pickupsRestants == 0) FiDelJoc();
        ControlEntradaUsuari();
    }

    void FiDelJoc()
    {
        // print("LEVEL COMPLETED");
        fi.text = "LEVEL COMPLETE";
        Time.timeScale = 0;
    }
    void ControlEntradaUsuari()
    {
        if (Input.GetKeyDown(KeyCode.X)) EliminaPickups();
    }

    void EliminaPickups()
    {
        // pickupsRestants = 0;
        GameObject[] picks;
        picks = GameObject.FindGameObjectsWithTag("pickup");
        foreach (GameObject p in picks)
        {

            punts += p.GetComponent<ScrPickup>().valor;
            Destroy(p);
            pickupsRestants--;
        }
    }
}

