using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seleccionado : MonoBehaviour
{

    //CODIGO EN EL JUGADOR
    public float distancia = 1.5f;
    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoReconocido = null;
    public GameObject minijuego;
    public Animator animacion;
    LayerMask mask;
    public InputField mainInputField;
    // Start is called before the first frame update
    public string combinacion;
    public Text TextoLeido;


    public GameObject player;
    public GameObject mano;
    public bool abierto = false;

    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
        TextDetect.SetActive(false);
        minijuego.SetActive(false);
        animacion.enabled=false;
        TextoLeido.GetComponent<Text>();
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
                    Time.timeScale = 0;
                    minijuegoEntrada();
                    minijuego.SetActive(true);
                    mainInputField.ActivateInputField();    
                }
            }
        }
        else
        {
            Deselect();
        }
        if (abierto)
        {
            player.GetComponent<Seleccionado>().enabled = false;
            mano.GetComponent<cogerChucky>().enabled = true;
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
        Time.timeScale = 1;
    }
    public void guardarVariable()
    {
        combinacion = TextoLeido.text;
        if (combinacion.Equals("0753"))
        {
            animacion.enabled = true;
            minijuegoSalida();
            abierto = true;
        }
        else
        {
            minijuegoSalida();

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("alfombra"))
        {
            player.GetComponent<Seleccionado>().enabled = false;
            mano.GetComponent<ObjetosSalaSergio>().enabled = true;
            mano.GetComponent<cogerChucky>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("alfombra"))
        {
            player.GetComponent<Seleccionado>().enabled = true;
            mano.GetComponent<ObjetosSalaSergio>().enabled = false;
            mano.GetComponent<cogerChucky>().enabled = true;
        }
    }
}
