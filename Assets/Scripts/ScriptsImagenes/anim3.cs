using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim3 : MonoBehaviour
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
        if (animacion.GetBool("girar3") == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animacion.SetBool("girar3", true);
                animacion.SetBool("volver3", false);
                emisor.clip = clip;
                emisor.Play();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animacion.SetBool("girar3", false);
                animacion.SetBool("volver3", true);
                emisor.clip = clip;
                emisor.Play();
            }
        }
    }
}
