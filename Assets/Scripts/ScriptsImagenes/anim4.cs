using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim4 : MonoBehaviour
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
        if (animacion.GetBool("girar4") == false)
        {
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                animacion.SetBool("girar4", false);
                animacion.SetBool("volver4", true);
                emisor.clip = clip;
                emisor.Play();
            }
        }
    }
}
