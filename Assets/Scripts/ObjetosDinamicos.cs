using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjetosDinamicos
{
    public GameObject obj;    
    public ObjetosDinamicos[] objetos;
    public bool visibleInicio, destruible, sonidoVisible = false, sonidoNoVisible = false;
    public AudioSource emisor;
    public AudioClip clipVisible, clipNoVisible;

    public void Visible()
    {
        obj.SetActive(true);
    }
    public void Invisible()
    {
        obj.SetActive(false);
    }
    public void VisibilidadSubobjetosInicio()
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
        }
    }

    public void DestruirOaparecer()
    {
        foreach (ObjetosDinamicos i in objetos)
        {
            if (i.destruible)
            {
                i.Invisible();
            }
            else
            {
                i.Visible();
            }
        }
    }
}
