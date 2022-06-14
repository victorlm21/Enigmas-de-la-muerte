using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salir : MonoBehaviour
{

    //CODIGO EN EL JUGADOR
    public float distancia = 1.5f;
    public Texture2D puntero;
    public GameObject minijuego;
    public Animator animacion;
    // Start is called before the first frame update
    public string combinacion;
    public Text TextoLeido;
    public AudioSource emisor;
    //Clip de sonido
    public AudioClip clip;

    public bool abierto = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void guardarVariable()
    {
        combinacion = TextoLeido.text;
        if (combinacion.Equals("4927"))
        {
            //Hacemos que el emisor vaya a reproducir ese clip
            emisor.clip = clip;
            //hacemos que lo reproduzca
            emisor.Play();
            animacion.enabled = true;
            minijuegoSalida();
            abierto = true;

        }
        else
        {
            minijuegoSalida();

        }
    }

    void minijuegoSalida()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        minijuego.SetActive(false);
        Time.timeScale = 1;
    }
}
