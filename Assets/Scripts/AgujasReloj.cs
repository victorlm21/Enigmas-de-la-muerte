using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgujasReloj : MonoBehaviour
{
    public GameObject horas, minutos;

    private void FixedUpdate()
    {
        minutos.transform.rotation = Quaternion.Euler(horas.transform.rotation.x + 5,
            horas.transform.rotation.y,
            horas.transform.rotation.z);
    }
}
