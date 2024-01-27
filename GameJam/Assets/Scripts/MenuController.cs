using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel_1");
    }

    public void Opciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Salir()
    {
        Debug.Log("Has salido del Juego");
        Application.Quit();
    }
}