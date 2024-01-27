using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Componentes
    private Rigidbody2D miCuerpo;
    private Animator miAnimador;

    //Variables
    public float velCaminar = 5;
    public float fuerzaSalto = 350;

    //Bool
    public bool enPiso;

    //Actuales
    public float velActualHoriz;
    public float velActualVert;

    // Start is called before the first frame update
    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
        miAnimador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnPiso();
        velActualHoriz = miCuerpo.velocity.x;
        velActualVert = miCuerpo.velocity.y;

        /*MOVIMIENTO*/
        float movHorizontal = Input.GetAxis("Horizontal");
        if (movHorizontal > 0)  //Derecha
        {
            miCuerpo.velocity = new Vector2(velCaminar, velActualVert);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movHorizontal < 0) //Izquierda
        {
            miCuerpo.velocity = new Vector2(-velCaminar, velActualVert);
            transform.rotation = Quaternion.Euler(0, 180, 0);
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
    }

    void EnPiso()
    {
        enPiso = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
    }
}
