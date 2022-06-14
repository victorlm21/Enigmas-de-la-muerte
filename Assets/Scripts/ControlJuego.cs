using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    [Header("Objetos")]
    private GameObject player;
    private GameObject mano;
    private Menu controlmenu;
    private Cronometro gameControler;
    


    [Header("Codigos Sergio")]
    private Seleccionado codSeleccionado;
    private ObjetosSalaSergio codObjetosSalaSergio;
    private botonSalirCuarto codBotonSalirCuarto;
    private cogerChucky codCogerChucky;

    [Header("Codigos Javi")]
    private CogerObjeto CogerObjeto;
    private InterfazFotos codInterfazFotos;

    [Header("Codigos Victor")]
    private Detectar codDetectar;
    public Salir codSalir;
    private void Awake()
    {
        player = GameObject.Find("jugador");
        mano = GameObject.Find("Hand");


        controlmenu = GameObject.Find("Control Menu").GetComponent<Menu>();
        gameControler = GameObject.Find("Game Controller").GetComponent<Cronometro>();



        codSeleccionado = GameObject.Find("jugador").GetComponent<Seleccionado>();
        codObjetosSalaSergio = GameObject.Find("Hand").GetComponent<ObjetosSalaSergio>();
        codBotonSalirCuarto = GameObject.Find("Hand").GetComponent<botonSalirCuarto>();
        codCogerChucky = GameObject.Find("Hand").GetComponent<cogerChucky>();

        codDetectar = GameObject.Find("jugador").GetComponent<Detectar>();
        codSalir = GameObject.Find("Hand").GetComponent<Salir>();

        CogerObjeto = GameObject.Find("Hand").GetComponent<CogerObjeto>();
        codInterfazFotos = GameObject.Find("Hand").GetComponent<InterfazFotos>();
    }
    

    void Start()
    {
        codigosSergio(true);
        codigosVictor(false);
        codigosJavi(false);

        //Debug.Log("codObjetosSalaSergio: " + codObjetosSalaSergio.isActiveAndEnabled);
        //Debug.Log("codDetectar: " + codDetectar.isActiveAndEnabled);
        //Debug.Log("CogerObjeto: " + CogerObjeto.isActiveAndEnabled);
        //Debug.Log("");

    }
    private void Update()
    {
        //Debug.Log("codObjetosSalaSergio ----- destruir: " + codObjetosSalaSergio.destruir);
        //Debug.Log("codObjetosSalaSergio: " + codCogerChucky.respuestaChuky);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Habitacion Javi"))
        {
            //Debug.Log("Habitacion Javi");
            codigosSergio(false);
            codigosVictor(false);
            codigosJavi(true);
        }
        else if (other.gameObject.CompareTag("Habitacion Sergio"))
        {
            //Debug.Log("Habitacion Sergio");
            codigosSergio(true);
            codigosVictor(false);
            codigosJavi(false);
        }
        else if (other.gameObject.CompareTag("Pasillo Victor"))
        {
            //Debug.Log("Habitacion victor");
            codigosSergio(false);
            codigosVictor(true);
            codigosJavi(false);
        }        
    }

    public void codigosSergio(bool activar)
    {
        codSeleccionado.enabled = activar;
        codObjetosSalaSergio.enabled = activar;
        codBotonSalirCuarto.enabled = activar;
        codCogerChucky.enabled = activar;
    }
    public void codigosVictor(bool activar)
    {
        codDetectar.enabled = activar;
        codSalir.enabled = activar;
    }
    public void codigosJavi(bool activar)
    {
        CogerObjeto.enabled = activar;
        codInterfazFotos.enabled = activar;
    }
}
