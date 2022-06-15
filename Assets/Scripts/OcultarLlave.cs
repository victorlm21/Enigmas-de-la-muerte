using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultarLlave : MonoBehaviour
{

    public GameObject llave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*! \brief Se ejecuta cuando el collider del cofre entra en contacto con el de la llave para ocultar esta
    */
    void OnCollisionEnter(Collision col)
    {
        /**
         * @param llave variable que almacena la llave para ocultarla al entrar en contacto con el collider del cofre
         */
        if (col.gameObject.tag == "Cofre")
        {
            llave.SetActive(false);
        }
    }
}
