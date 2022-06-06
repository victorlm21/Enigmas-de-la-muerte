using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarComponente : MonoBehaviour
{
    public GameObject activador, activado;
    public AudioClip archivoSonido;
    private AudioSource emisorSonido;

    private void Start()
    {
        emisorSonido = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activado.AddComponent<Rigidbody>();
            emisorSonido.clip = archivoSonido;
            emisorSonido.Play();
        }
    }
}
