using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar : MonoBehaviour
{
    private float maxDistance = 2.5f;

    private RaycastHit hit;
    public List<ObjetosDinamicos> objetos = new List<ObjetosDinamicos>();

    private int contador = 0;
    private int indice = 0;
    private string objetoColisionado = "";


    private void Awake()
    {
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
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
