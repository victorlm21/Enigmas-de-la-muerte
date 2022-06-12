using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint;

    private GameObject pickedObject = null;

    public GameObject coger;
    public Text texto;

    private void Start()
    {
        coger.SetActive(false);
    }

    void Update()
    {
        if (pickedObject != null)
        {
            coger.SetActive(true);
            texto.text = "R";
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            coger.SetActive(true);
            texto.text = "E";
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handPoint.transform.position;

                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        coger.SetActive(false);
    }

}
