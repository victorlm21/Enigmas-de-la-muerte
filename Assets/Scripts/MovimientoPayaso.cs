using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPayaso : MonoBehaviour
{
    private Transform payasotr;
    public float velocidadX = 1;
    public float velocidadZ = 1;
    // Start is called before the first frame update
    void Start()
    {
        payasotr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        payasotr.position = new Vector3(payasotr.position.x + velocidadX * Time.deltaTime,
            payasotr.position.y,
            payasotr.position.z + velocidadZ * Time.deltaTime);
    }
}
