using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anim4 : MonoBehaviour
{
    Animator animacion;
    public AudioSource emisor;
    public AudioClip clip;
    private bool contacto = false;
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    /*! \brief Se ejecuta cuando el collider de la mano entra en contacto con el collider de las imagenes para permitir que estas giren, tanto para ver un lado como el otro
    */
    void Update()
    {
        /**
         * @param animacion variable que almacena la animacion de la imagen
         * @param emisor variable que detecta quien es el emisor del sonido
         * @param clip variable que almacena el sonido que emitira el emisor
         * @param contacto booleano para saber si el collider de la mano esta en contacto con el collider de la imagen
         * @param texto aparece en la esquina superior derecha indicando la tecla para la interaccion con el objeto
         */
        if (contacto)
        {
            if (animacion.GetBool("girar4") == false)
            {
                texto.text = "F";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    animacion.SetBool("girar4", true);
                    animacion.SetBool("volver4", false);
                    emisor.clip = clip;
                    emisor.Play();
                }
            }
            else
            {
                texto.text = "G";
                if (Input.GetKeyDown(KeyCode.G))
                {
                    animacion.SetBool("girar4", false);
                    animacion.SetBool("volver4", true);
                    emisor.clip = clip;
                    emisor.Play();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("mano"))
        {
            contacto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("mano"))
        {
            contacto = false;
        }
    }
}
