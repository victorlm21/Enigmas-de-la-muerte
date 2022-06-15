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
    public AudioSource emisor;
    //Clip de sonido
    public AudioClip clip;


    public GameObject player;
    public GameObject mano;
    public bool abierto = false;

    /*! \brief Metodo en el que se declara que el texto a enseñar al jugador este desactivado y se inicializa las variables que se van a usar.
    */
    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
        TextDetect.SetActive(false);
        minijuego.SetActive(false);
        animacion.enabled=false;
        TextoLeido.GetComponent<Text>();
    }
    /*! \brief Metodo en el que se define las características del RayCast que se va a usar y mediante una condición filtra si el objeto al que se acerca tiene la etiqueta de cajaFuerte, si es así le aparecerá 
     * al jugador el texto, y si estando en el rango del RayCast presiona la E, para el tiempo y le permita meter la combinación correspondiente. 
     */
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
    /*! \brief En este método se guarda el valor que introduce el jugador y se comprueba en una condición, si es el
     * correcto activa la animación de la puerta abriéndose sino sales de la interfaz de introducir la combinación.
     */
    public void guardarVariable()
    {
        combinacion = TextoLeido.text;
        if (combinacion.Equals("0753"))
        {
            //Hacemos que el emisor vaya a reproducir ese clip
            emisor.clip = clip;
            //hacemos que lo reproduzca
            emisor.Play();
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
