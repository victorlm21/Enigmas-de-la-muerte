using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar : MonoBehaviour
{
    public GameObject activador, activado;
    public AudioClip archivoSonido;
    private AudioSource emisorSonido;
    public float delay;
    public bool destruir = false;
    private bool colision = false;
    
    // Start is called before the first frame update
    void Start()
    {
        activado.SetActive(false);
        emisorSonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destruir && colision)
        {
            Destroy(activado, delay);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && colision == false)
        {
            activado.SetActive(true);
            colision = true;
            emisorSonido.PlayOneShot(archivoSonido);
        }
    }
}
