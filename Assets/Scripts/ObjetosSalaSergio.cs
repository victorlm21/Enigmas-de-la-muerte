using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosSalaSergio : MonoBehaviour
{
    //CODIGO EN EL OBJETO MANO
    public GameObject TextDetect;
    private GameObject objeto;
    public bool destruir = false;
    public GameObject cuadro;
    public GameObject cuadro1;
    public GameObject cuadro2;
    public bool objetosCogidos = false;
    private bool cuadro1er = false;
    private bool cuadro2do = false;
    public AudioSource emisor;
    //Clip de sonido
    public AudioClip clip;

    private void Start()
    {
        TextDetect.SetActive(false);
    }

    /*! \brief Metodo que permite coger objetos e inicia la música.
    */
    private void Update()
    {
        /**
        @param destruir Se usa para validar en el Update si se puede destruir el bojeto o no.
        @param emisor Se usa para activar la música.     
        @param cuadro1er Se usan para posteriormente saber si se estan cogiendo ambos cuadros.
        @param cuadro2do Se usan para posteriormente saber si se estan cogiendo ambos cuadros.
        */
        if (Input.GetKeyDown(KeyCode.E) && destruir)
        {
            emisor.clip = clip;
            //hacemos que lo reproduzca
            emisor.Play();
            Destroy(objeto);
            destruir = false;
            TextDetect.SetActive(false);
            //Hacemos que el emisor vaya a reproducir ese clip

            switch (objeto.name)
            {
                case "gremclown":
                    cuadro1.AddComponent<Rigidbody>();
                    cuadro1er = true;
                    break;
                case "LowProf_Low":
                    cuadro2.AddComponent<Rigidbody>();
                    cuadro2do = true;
                    break;

            }
            if (cuadro1er && cuadro2do)
            {
                objetosCogidos = true;
            }
        }
    }

    /*! \brief Metodo que recoge el nombre del GameObject y activa el texto indicativo para el jugador.
    */
    private void OnTriggerEnter(Collider other)
    {
        /**
        @param destruir Se usa para validar en el Update si se puede destruir el bojeto o no.
        @param objeto Recoge el nombre del objeto con el que colisiona 
        */
        if (other.gameObject.CompareTag("muneco1") || other.gameObject.CompareTag("moneda"))
        {
            Debug.Log("colision objeto");
            objeto = other.gameObject;
            TextDetect.SetActive(true);
            destruir = true;
        }
    }

    /*! \brief Metodo que desactiva el texto.
    */
    private void OnTriggerExit(Collider other)
    {
        /**
        @param destruir Se usa para validar en el Update si se puede destruir el bojeto o no.
        
        */
        if (other.gameObject.CompareTag("muneco1") || other.gameObject.CompareTag("moneda"))
        {
            
            TextDetect.SetActive(false);
            destruir = false;
        }
    }
}
