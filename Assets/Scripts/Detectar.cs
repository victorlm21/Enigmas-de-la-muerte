using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detectar : MonoBehaviour
{
    private float maxDistance = 2.5f;

    private RaycastHit hit;
    public List<ObjetosDinamicos> objetos = new List<ObjetosDinamicos>();
    public ObjetosDinamicos puerta;

    private int contador = 0;
    private int indice = 0;
    private string objetoColisionado = "";

    public Text pista;

    private void Awake()
    {
        pista = GameObject.Find("pistas").GetComponent<Text>();
        pista.text = "";
        foreach (ObjetosDinamicos i in objetos)
        {
            if (i.visibleInicio)
            {
                i.Visible();
            }
            else
            {
                i.Invisible();
            }
            i.VisibilidadSubobjetosInicio();
        }
       
    }
    void FixedUpdate()
    {
        aparicionInicial();
        aparicionPosterior();
    }
    public void aparicionInicial()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("mostrar inicial"))
        {
            objetos[0].Visible();
            objetos[0].emisor.clip = objetos[0].clipVisible;
            objetos[0].emisor.Play();          
        }
    }


    public void aparicionPosterior()
    {
        if (Physics.Raycast(transform.position, transform.forward, maxDistance))
        {
            if (hit.collider.gameObject.CompareTag("mostrar"))
            {
                mecanicaPasillo();
            }
        }  
    }

    private void mecanicaPasillo()
    {
            //Para no repetir
            if (objetoColisionado != hit.collider.gameObject.name)
            {
                objetoColisionado = hit.collider.gameObject.name;
                contador++;
                if (contador < objetos.Count)
                {
                    objetos[contador].Visible();
                }
                indice = contador - 1;
                if (objetos[indice].sonidoVisible)
                {
                    objetos[indice].emisor.clip = objetos[indice].clipVisible;
                    objetos[indice].emisor.Play();
                }
                if (objetos[indice - 1].destruible)
                {
                    Destroy(objetos[indice - 1].obj);
                }
                objetos[indice].DestruirOaparecer();
            }
        else
        {
            if (objetos[indice].sonidoNoVisible)
            {
                objetos[indice].emisor.clip = objetos[indice].clipNoVisible;
                objetos[indice].emisor.Play();
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("mostrar inicial"))
        {
            pista.text = "Puerta cerrada";
            puerta.emisor.clip = puerta.clipVisible;
            puerta.emisor.Play();
            Destroy(pista, 1.5f);
        }
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
