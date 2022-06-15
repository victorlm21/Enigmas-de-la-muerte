using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazFotos : MonoBehaviour
{

    public GameObject interactuar;
    public Text texto;

    /*! \brief Se ejecuta cuando el collider de la mano entra en contacto con el collider de las imagenes
    */
    private void OnTriggerEnter(Collider other)
    {
        /**
         * @param interactuar es una imagen que aparece en la esquina superior derecha cuando el collider de la mano entra en contacto con el collider de alguna imagen
         */
        if (other.CompareTag("imagen"))
        {
            interactuar.SetActive(true);
        }
    }
    /*! \brief Se ejecuta cuando el collider de la mano no esta en contacto con el collider de las imagenes
    */
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("imagen"))
        {
            interactuar.SetActive(false);
        }
    }
}
