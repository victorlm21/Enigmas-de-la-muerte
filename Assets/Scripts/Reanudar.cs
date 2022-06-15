using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reanudar : MonoBehaviour
{
    //CRONOMETRO
    public Canvas canvasUI;
    private Text contador;
    public float tiempo;

    private void Awake()
    {
        Time.timeScale = 1f;
        contador = GameObject.Find("txtTiempo").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        contador.text = " " + tiempo;
    }


    /*! \brief Contador para que al acabar el juego regrese al menu principal despues de la pantalla final
    */
    void Update()
    {
        /**
         * @param contador es el texto en el que se mostraria el contador en caso de querer hacerlo
         * @param tiempo va restando el tiempo para volver al menu principal
         */
        tiempo -= Time.deltaTime;
        contador.enabled = true;
        contador.text = " " + tiempo.ToString("f0");
        //Perder vida        
        if (tiempo <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
