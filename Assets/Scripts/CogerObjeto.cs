using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint;

    private GameObject pickedObject = null;

    public GameObject coger;
    public Text texto;

    private void Start()
    {
        coger.SetActive(false);
    }

    /*! \brief Esta parte se ejecuta cuando el jugador tiene la llave en la mano, para que pueda soltarla pulsando la tecla R
    */
    void Update()
    {
        /**
         * @param pickedObject es un booleano que sirve para saber si el jugador tiene la llave en la mano o no
         * @param coger es una imagen que aparece en la esquina superior derecha cuando el jugador tiene el objeto en la mano o va a cogerlo
         * @param texto aparece tambien en la esquina superior derecha indicando la tecla para la interaccion con el objeto
         */
        if (pickedObject != null)
        {
            coger.SetActive(true);
            texto.text = "R";
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;
            }
        }
        
    }

    /*! \brief Se ejecuta cuando el collider de la mano del jugador entra en contacto con el collider de la llave
    */
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            coger.SetActive(true);
            texto.text = "E";
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handPoint.transform.position;

                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        coger.SetActive(false);
    }

}
