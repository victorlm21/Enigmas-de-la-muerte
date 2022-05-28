using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad, correr, gravedad;
    public float sensibilidad;
    public CharacterController playercc;
    public Transform playertr;
    private Vector3 caida;
    float xRotacion = 0f;
    private Camera camara;

    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camara.GetComponent<Camera>();
        camara.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    // Update is called once per frame
    void Update()
    {        
        MovimientoJugador();
        MovimientoCamara();
    }


    /*! \brief Metodo que permite la rotacion vertical de la camara y la rotacion horizontal del jugador
    */
    private void MovimientoCamara()
    {

        /**
         * @param mouseX Controla la rotacion horizontal.
         * @param mouseY Controla la rotacion vertical.
         * @see Input.GetAxis() Obtiene el control de los ejes predefinidos por unity (para el teclado o mando)
         * @see Time.deltaTime permite que los calculos se produzcan con la misma frecuencia entre frames
         * @see Mathf.Clamp() limita los valores de una variable entre 2 limites
         * @see Quaternion.Euler() Modificar la rotacion de la camara
         * @see Rotate() metodo del Characater Controller para modificar la rotacion
         */
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime; 

        //Giro de la camara vertical
        xRotacion -= mouseY;
        //Limite de giro vertical
        xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);
        //Apolicamos el giro a la camara
        transform.localRotation = Quaternion.Euler(xRotacion, 0f, 0f);

        //Giramos el jugador entero horizontalmente
        playertr.Rotate(Vector3.up * mouseX);
    }
    private void MovimientoJugador()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 mov = transform.right * movX + transform.forward * movZ;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playercc.Move(mov * correr * Time.deltaTime);
        }
        else
        {
            playercc.Move(mov * velocidad * Time.deltaTime);
        }
        caida.y = -gravedad * Time.deltaTime;
        playercc.Move(caida);
    }
    
}
