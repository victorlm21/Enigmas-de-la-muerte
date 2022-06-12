using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    //Emisor de sonido
    public AudioSource emisor;
    //Clip de sonido
    public AudioClip clip;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Hacemos que el emisor vaya a reproducir ese clip
            emisor.clip = clip;
            //hacemos que lo reproduzca
            emisor.Play();
        }
    }
}
