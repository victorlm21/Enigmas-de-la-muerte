using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonSalirCuarto : MonoBehaviour
{
    public GameObject mano;
    public GameObject boton;
    public GameObject TextDetect;
    // Start is called before the first frame update
    void Start()
    {
        boton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mano.GetComponent<ObjetosSalaSergio>().objetosCogidos && mano.GetComponent<cogerChucky>().respuestaChuky)
        {
            boton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextDetect.SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("botonPared"))
        {
            boton = other.gameObject;
            TextDetect.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("botonPared"))
        {
            TextDetect.SetActive(false);
        }
    }
}
