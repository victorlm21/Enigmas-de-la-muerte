using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anim2 : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (contacto)
        {
            if (animacion.GetBool("girar2") == false)
            {
                texto.text = "F";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    animacion.SetBool("girar2", true);
                    animacion.SetBool("volver2", false);
                    emisor.clip = clip;
                    emisor.Play();
                }
            }
            else
            {
                texto.text = "G";
                if (Input.GetKeyDown(KeyCode.G))
                {
                    animacion.SetBool("girar2", false);
                    animacion.SetBool("volver2", true);
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
