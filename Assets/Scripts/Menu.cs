using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool pausado = false;
    
    public Canvas ui, pausa, opciones;
    private GameObject interactuar, coger;
    
    public AudioMixer am;
    private Slider barraSensibilidad, barraVolumen;
    public Movimiento codigo;
    private Text valorVolumen, valorSensibilidad;

    private void Awake()
    {
        valorVolumen = GameObject.Find("ValorVolumen").GetComponent<Text>();
        valorSensibilidad = GameObject.Find("ValorSensibilidad").GetComponent<Text>();
        barraSensibilidad = GameObject.Find("Slider Sensibilidad").GetComponent<Slider>();
        barraVolumen = GameObject.Find("Slider Volumen").GetComponent<Slider>();

        interactuar = GameObject.Find("INTERACTUAR");
        coger = GameObject.Find("COGER");
    }

    // Start is called before the first frame update
    void Start()
    {
        ui.enabled = true;
        pausa.enabled = false;
        opciones.enabled = false;

        interactuar.SetActive(false);
        coger.SetActive(false);

        barraSensibilidad.value = codigo.sensibilidad;
        barraSensibilidad.value = 5;

    }

    // Update is called once per frame
    void Update()
    {
        //Entrar en pausa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pausado)
            {
                Reanudar();
                pausado = false;
            }
            else
            {
                Pausa();
                pausado = true;
            }
        }
        valorSensibilidad.text = Mathf.Round(barraSensibilidad.value).ToString();
        valorVolumen.text = Mathf.FloorToInt(barraVolumen.value).ToString();
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        ui.enabled = false;
        pausa.enabled = true;
        opciones.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        ui.enabled = true;
        pausa.enabled = false;
        opciones.enabled = false;
        pausado = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Salir()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void Opciones()
    {
        ui.enabled = false;
        pausa.enabled = false;
        opciones.enabled = true;
    }
    public void ajusteVolumen()
    {
        am.SetFloat("audio", barraVolumen.value - 20);
    }
    public void ajusteSensibilidad()
    {
        codigo.sensibilidad = barraSensibilidad.value * 100;
    }
}
