using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Componentes
    private Rigidbody2D miCuerpo;
    private Animator miAnimador;
    private BoxCollider2D boxCollider;
    public Transform controladorSuelo;
    public LayerMask Suelo;
    public Vector3 dimensionesCaja;

    //Variables
    public float velCaminar = 5;
    public float fuerzaSalto = 350;

    //Bool
    public bool npcCerca;
    public bool enPiso = true;
    public bool caminando;
    public bool saltando;
    public bool cayendo;
    public bool asustado;

    //Actuales
    public float velActualHoriz;
    public float velActualVert;

    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        velActualHoriz = miCuerpo.velocity.x;
        velActualVert = miCuerpo.velocity.y;


        /*MOVIMIENTO*/
        float movHorizontal = Input.GetAxis("Horizontal");
        if (movHorizontal > 0)  //Derecha
        {
            miCuerpo.velocity = new Vector2(velCaminar, velActualVert);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movHorizontal < 0) //Izquierda
        {
            miCuerpo.velocity = new Vector2(-velCaminar, velActualVert);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            {
                miCuerpo.velocity = new Vector2(0, velActualVert);
            }
        }

        /*SALTO*/
        if (Input.GetButtonDown("Jump"))
        {
            if (enPiso == true)
            {
                miCuerpo.AddForce(new Vector3(velActualHoriz, fuerzaSalto, 0), ForceMode2D.Impulse);
            }
        }

        /*Interactuar*/
        if (npcCerca)
        {
            InteractuarNPC();
        }

        /*EN PISO*/
        enPiso = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, Suelo);


        //Animaciones
        miAnimador.SetBool("Caminando", caminando);
        miAnimador.SetBool("Saltando", saltando);
        miAnimador.SetBool("Cayendo", cayendo);
        miAnimador.SetBool("Asustado", asustado);
        miAnimador.SetBool("En Piso", enPiso);

        if (velActualHoriz > 0)
        {
            caminando = true;
        }
        else if (velActualHoriz < 0)
        {
            caminando = true;
        }
        else
        {
            caminando = false;
        }

        if (velActualVert > 0)
        {
            saltando = true;
            cayendo = false;
        }
        else if (velActualVert< 0)
        {
            saltando = false;
            cayendo = true;
        }
        else
        {
            saltando = false;
            cayendo = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    void InteractuarNPC()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Hablando");
        }
    }
}