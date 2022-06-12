using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    private GameObject player;
    private GameObject mano;

    private void Awake()
    {
        player = GameObject.Find("jugador");
        mano = GameObject.Find("Hand");
    }
    // Start is called before the first frame update
    void Start()
    {
        mano.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Habitacion Javi"))
        {

        }else if (other.gameObject.CompareTag("Habitacion Sergio"))
        {
            mano.SetActive(false);
        }
        else
        {
            mano.SetActive(false);
        }
    }
}
