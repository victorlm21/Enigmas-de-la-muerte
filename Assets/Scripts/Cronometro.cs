using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    //CRONOMETRO
    public Canvas canvasUI;
    private Text contador;
    public float tiempo;
    public float relojAamarillo;
    public float relojArojo;

    private void Awake()
    {
        contador = GameObject.Find("txtCronometro").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        contador.text = " " + tiempo;
    }
    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        contador.enabled = true;
        contador.text = " " + tiempo.ToString("f0");
        //Perder vida        
        if (tiempo <= 0)
        {
            SceneManager.LoadScene("");
        }
        if (contador.enabled == true)
        {
            contador.color = Color.green;
            if (tiempo <= relojAamarillo)
            {
                contador.color = Color.yellow;
            }
            if (tiempo <= relojArojo)
            {
                contador.color = Color.red;
            }
        }
    }
}
