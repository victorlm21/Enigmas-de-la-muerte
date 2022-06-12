using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{

    Animator animacion;
    public AudioSource emisor;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animacion.GetBool("girar") == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animacion.SetBool("girar", true);
                animacion.SetBool("volver", false);
                emisor.clip = clip;
                emisor.Play();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animacion.SetBool("girar", false);
                animacion.SetBool("volver", true);
                emisor.clip = clip;
                emisor.Play();
            }
        }        
    }
}
