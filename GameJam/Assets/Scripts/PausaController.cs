using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausaController : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject menuPausa;
    public GameObject menuOpciones;

    private void Start()
    {
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
    }

    public void Pausa()
    {
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void reanudar()
    {
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void reiniciar()
    {
        Debug.Log("Coquito Cherry");
        Scene Nivel_1 = SceneManager.GetActiveScene();
        SceneManager.LoadScene(Nivel_1.name);
    }
    public void opciones()
    {
        menuOpciones.SetActive(true);
    }
    public void volverOpciones()
    {
        menuOpciones.SetActive(false);
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
