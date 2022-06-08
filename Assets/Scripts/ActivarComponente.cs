using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarComponente : MonoBehaviour
{
    public GameObject activador, activado;
    public AudioClip archivoSonido;
    private AudioSource emisorSonido;
    public float delay;
    public bool destruir = false;
    private bool colision;

    private void Start()
    {
        emisorSonido = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (destruir && colision)
        {
            Destroy(emisorSonido, delay);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activado.AddComponent<Rigidbody>();
            emisorSonido.clip = archivoSonido;
            emisorSonido.Play();
            colision = true;
        }
    }
}
