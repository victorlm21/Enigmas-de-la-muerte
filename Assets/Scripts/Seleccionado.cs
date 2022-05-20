using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seleccionado : MonoBehaviour
{
    public float distancia = 1.5f;
    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoReconocido = null;
    public GameObject minijuego;
    public Animator animacion;
    LayerMask mask;
    // Start is called before the first frame update

    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
        TextDetect.SetActive(false);
        minijuego.SetActive(false);
        animacion.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deselect();
            SelectObject(hit.transform);
            if (hit.collider.tag == "cajaFuerte")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    minijuego.SetActive(true);
                    minijuegoEntrada();
                    animacion.enabled = true;
                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        minijuegoSalida();
                    }

                        
                }
            }
        }
        else
        {
            Deselect();
        }
    }
    void SelectObject(Transform transform)
    {
        ultimoReconocido = transform.gameObject;
    }
    void Deselect()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido = null;
        }
    }
    void OnGUI()
    {
        if (ultimoReconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }
    void minijuegoEntrada()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void minijuegoSalida()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        minijuego.SetActive(false);
    }
}
