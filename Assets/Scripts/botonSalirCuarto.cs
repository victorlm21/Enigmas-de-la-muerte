using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonSalirCuarto : MonoBehaviour
{
    public GameObject mano;
    public GameObject boton;
    public GameObject TextDetect;
    public Animator animacion;
    public AudioSource emisor;
    //Clip de sonido
    public AudioClip clip;
    private bool puerta = false;
    
    // Start is called before the first frame update
    void Start()
    {
        boton.SetActive(false);
        animacion.enabled = false;
    }

    // Update is called once per frame

    /*! \brief Metodo que permite cargar la animación de la apertura de la puerta si los tres objetos se han cogido y selecciona la tecla E durante la colisión.
    */
    void Update()
    {
        /**
         * @param boton Activa el GameObject para que aparezca en la escena.
         * @param animacion Recoge el estado de la animación de la puerta.
         */
        if (mano.GetComponent<ObjetosSalaSergio>().objetosCogidos && mano.GetComponent<cogerChucky>().respuestaChuky)
        {
            boton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && puerta)
            {
                TextDetect.SetActive(false);
                animacion.enabled = true;
                //Hacemos que el emisor vaya a reproducir ese clip
                emisor.clip = clip;
                //hacemos que lo reproduzca
                emisor.Play();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("botonPared"))
        {
            puerta = true;
            boton = other.gameObject;
            TextDetect.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("botonPared"))
        {
            TextDetect.SetActive(false);
        }
    }
}
