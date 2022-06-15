using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoFotos : MonoBehaviour
{

    public GameObject fotos;
    public GameObject llave;

    // Start is called before the first frame update
    void Start()
    {
        fotos.SetActive(false);

    }

    /*! \brief Cuando la llave no este activa, que significaria que el cofre esta abierto, se habilitaran las fotos para el segundo minijuego
    */
    void Update()
    {
        /**
         * @param fotos variable que guarda un objeto que incluye todas las imagenes para mostrarlas cuando la llave se oculte
         * @param llave variable que almacena la llave para que cuando este oculta se muestren las imagenes
         */
        if (llave.active == false)
        {
            fotos.SetActive(true);
        }
    }
}
