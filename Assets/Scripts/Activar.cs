using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar : MonoBehaviour
{
    public GameObject activador, activado;
    public AudioClip archivoSonido;
    public AudioSource emisorSonido;
    public float delay;
    public bool destruir = false;
    private bool colision = false;
    
    // Start is called before the first frame update
    void Start()
    {
        activado.SetActive(false);
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
        if (other.gameObject.CompareTag("Player")){
            activado.SetActive(true);
            colision = true;
        }
    }
}
