using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosSalaSergio : MonoBehaviour
{
    //CODIGO EN EL OBJETO MANO
    public GameObject TextDetect;
    private GameObject objeto;
    private bool destruir = false;
    public GameObject cuadro;
    
    private void Start()
    {
        TextDetect.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && destruir)
        {
            Destroy(objeto);
            TextDetect.SetActive(false);
            switch (objeto.name)
            {
                case "payaso":
                    cuadro.AddComponent<Rigidbody>();
                    break;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("muneco1") || other.gameObject.CompareTag("moneda"))
        {
            objeto = other.gameObject;
            TextDetect.SetActive(true);
            destruir = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("muneco1") || other.gameObject.CompareTag("moneda"))
        {
            TextDetect.SetActive(false);
            destruir = false;
        }
    }
}
