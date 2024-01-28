using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float distanciaAgro = 5;
    public bool playerCerca = false;

    private Animator miAnimador;
    private Rigidbody2D miCuerpo;
    private GameObject player;
    private PlayerController protaJuego;

    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        protaJuego = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector3 miPos = this.transform.position;
        Vector3 posHeroe = player.transform.position;
        float distanciaHeroe = (miPos - posHeroe).magnitude;

        if (distanciaHeroe < distanciaAgro)
        {
            playerCerca = true;

            if (player.transform.position.x < this.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            playerCerca = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otro = collision.gameObject;
        if (otro.CompareTag("Player"))
        {
            playerCerca = true;
            PlayerController prota = otro.GetComponent<PlayerController>();
            prota.npcCerca = playerCerca;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject otro = collision.gameObject;
        if (otro.CompareTag("Player"))
        {
            playerCerca = false;
            PlayerController prota = otro.GetComponent<PlayerController>();
            prota.npcCerca = playerCerca;
        }
    }

}
