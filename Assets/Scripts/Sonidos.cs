using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public AudioSource emisor;
    public AudioClip clip;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            emisor.clip = clip;
            emisor.Play();
        }
    }
}
