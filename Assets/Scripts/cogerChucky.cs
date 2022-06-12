using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogerChucky : MonoBehaviour
{
    public GameObject TextDetect;
    public GameObject mano;
    public GameObject chuky;
    private bool destruir = false;
    public GameObject player;
    public GameObject cuadro3;
    public bool respuestaChuky = false;

    // Update is called once per frame
    void Update()
    {
        if (destruir && player.GetComponent<Seleccionado>().abierto)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(chuky);
                TextDetect.SetActive(false);
                cuadro3.AddComponent<Rigidbody>();
                respuestaChuky = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Colision");
        if (other.CompareTag("chuky"))
        {
            chuky = other.gameObject;
            TextDetect.SetActive(true);
            destruir = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("chuky"))
        {
            TextDetect.SetActive(false);
        }
    }
}