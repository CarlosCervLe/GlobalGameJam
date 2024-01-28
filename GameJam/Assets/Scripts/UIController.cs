using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public PlayerController player;
    public GameObject textoBotonInteract;

    void Start()
    {
        textoBotonInteract.SetActive(false);
    }

    void Update()
    {
        //Texto NPC
        if (player.npcCerca == true)
        {
            textoBotonInteract.SetActive(true);
        }
        else if (player.npcCerca == false)
        {
            textoBotonInteract.SetActive(false);
        }
    }
}