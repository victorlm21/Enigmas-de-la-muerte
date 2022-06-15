using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCofre : MonoBehaviour
{

    Animator anim;
    public AudioSource emisor;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*! \brief Se ejecuta cuando el collider de la llave entra en contacto con el collider del cofre, para abrir este ultimo
    */
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Objeto")
        {
            /**
             * @param anim variable que guarda la animacion del cofre
             * @param emisor variable que indica quien es el emisor del sonido
             * @param clip variable que guarda el sonido que va a emitir el emisor
             */
            anim.SetBool("AbrirCofre", true);
            emisor.clip = clip;
            emisor.Play();
        }
    }
}
