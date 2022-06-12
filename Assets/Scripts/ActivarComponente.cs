using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarComponente : MonoBehaviour
{
    public GameObject activador, activado;
    public AudioClip archivoSonido;
    public AudioSource emisorSonido;
    public float delay;
    public bool destruir = false;
    private bool colision;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && colision == false)
        {
            activado.AddComponent<Rigidbody>();
            emisorSonido.clip = archivoSonido;
            emisorSonido.Play();
            colision = true;
        }
    }
}
