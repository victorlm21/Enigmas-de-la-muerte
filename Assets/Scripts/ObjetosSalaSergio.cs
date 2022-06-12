using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosSalaSergio : MonoBehaviour
{

    GameObject ultimoReconocido = null;
    public float distancia = 1.5f;
    LayerMask mask;
    public GameObject TextDetect;
    public GameObject payaso; 
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("RayCast");
        TextDetect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("muneco1"))
        {
            TextDetect.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(payaso);
            }
        }
    }
}
