 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteraccionMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(4);
    }
    public void QuitarJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo de la aplicación");
    }
}
