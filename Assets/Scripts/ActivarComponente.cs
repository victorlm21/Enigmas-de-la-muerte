using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarComponente : MonoBehaviour
{
    public GameObject activador, activado;
    public AudioClip archivoSonido;
    public AudioSource emisorSonido;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activado.AddComponent<Rigidbody>();
        }
    }
}
