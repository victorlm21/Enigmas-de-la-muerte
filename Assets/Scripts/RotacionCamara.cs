using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCamara : MonoBehaviour
{
    public float velocidadRotacion = 0.75f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,1,0)* velocidadRotacion);
    }
}
