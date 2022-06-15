using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogerChucky : MonoBehaviour
{
    public GameObject TextDetect;
    public GameObject mano;
    public GameObject chuky;
    private bool destruir = false;
    public GameObject player;
    public GameObject cuadro3;
    public bool respuestaChuky = false;
    public AudioSource Emisor;
    //Clip de sonido
    public AudioClip Clip;

    // Update is called once per frame

    /*! \brief Metodo que permite coger el muñeco, añadir Rigibody al cuadro y activar la música.
    */
    void Update()
    {

        /**
         * @param respuestaChuky Permite guardar si el objeto ha sido recogido o no.
         * @param cuadro3 GameObject que se encuentra en la sala.
         */
        if (destruir && player.GetComponent<Seleccionado>().abierto)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(chuky);
                TextDetect.SetActive(false);
                cuadro3.AddComponent<Rigidbody>();
                respuestaChuky = true;
                //Hacemos que el emisor vaya a reproducir ese clip
                Emisor.clip = Clip;
                //hacemos que lo reproduzca
                Emisor.Play();
                Destroy(Emisor,5f);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("chuky"))
        {
            chuky = other.gameObject;
            TextDetect.SetActive(true);
            destruir = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("chuky"))
        {
            TextDetect.SetActive(false);
        }
    }
}
