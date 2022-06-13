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
    void Update()
    {
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
