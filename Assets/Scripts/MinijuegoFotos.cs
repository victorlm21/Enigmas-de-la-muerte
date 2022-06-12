using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoFotos : MonoBehaviour
{

    public GameObject fotos;
    public GameObject llave;

    // Start is called before the first frame update
    void Start()
    {
        fotos.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (llave.active == false)
        {
            fotos.SetActive(true);
        }
    }
}
