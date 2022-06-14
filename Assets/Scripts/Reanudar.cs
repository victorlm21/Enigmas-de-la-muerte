using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reanudar : MonoBehaviour
{
    //CRONOMETRO
    public Canvas canvasUI;
    private Text contador;
    public float tiempo;

    private void Awake()
    {
        Time.timeScale = 1f;
        contador = GameObject.Find("txtTiempo").GetComponent<Text>();
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
            SceneManager.LoadScene("Menu");
        }
    }
}
