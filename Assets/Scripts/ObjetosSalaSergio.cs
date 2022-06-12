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
    public GameObject cuadro1;
    public GameObject cuadro2;
    public bool objetosCogidos = false;
    private bool cuadro1er = false;
    private bool cuadro2do = false;

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
                case "gremclown":
                    cuadro1.AddComponent<Rigidbody>();
                    cuadro1er = true;
                    break;
                case "LowProf_Low":
                    cuadro2.AddComponent<Rigidbody>();
                    cuadro2do = true;
                    break;

            }
            if (cuadro1er && cuadro2do)
            {
                objetosCogidos = true;
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
