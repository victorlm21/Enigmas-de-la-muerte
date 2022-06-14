using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    public GameObject minijuegoFinal;
    // Start is called before the first frame update
    private string combinacion;
    public Text TextoLeido;
    public GameObject interactuar;
    public Text textoInteractuar;
    private bool encontacto = false;
    private void Awake()
    {
        minijuegoFinal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (encontacto)
        {
            interactuar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("interactuar");
                pausado();
            }
        }
        else
        {
            interactuar.SetActive(false);
        }
    }

    public void ComprobarValor()
    {
        combinacion = TextoLeido.text;
        if (combinacion.Equals("4927"))
        {
            SceneManager.LoadScene("Ganar");
        }
        else
        {
            reanudar();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        textoInteractuar.text = "Pulsa la tecla E";
        if (other.CompareTag("puerta final"))
        {
            encontacto = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        encontacto = false;
    }
    void pausado()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        minijuegoFinal.SetActive(true);
        Time.timeScale = 0f;
    }
    void reanudar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        minijuegoFinal.SetActive(false);
        Time.timeScale = 1f;
    }
}
