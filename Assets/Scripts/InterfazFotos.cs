using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazFotos : MonoBehaviour
{

    public GameObject interactuar;
    public Text texto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("imagen") || other.CompareTag("imagen4"))
        {
            interactuar.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("imagen") || other.CompareTag("imagen4"))
        {
            interactuar.SetActive(false);
        }
    }
}
