using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool pausado = false;
    
    public Canvas ui, pausa, opciones, cronometro;
    private GameObject interactuar, coger;
    
    public AudioMixer am;
    private Slider barraSensibilidad, barraVolumen;
    public Movimiento codigo;
    private Text valorVolumen, valorSensibilidad;

    public AudioSource[] allAudioSources;


    /*! \brief Tomamos el control de los componentes directamentes sin enlazarlos en la interfaz de unity
    */
    private void Awake()
    {
        valorVolumen = GameObject.Find("ValorVolumen").GetComponent<Text>();
        valorSensibilidad = GameObject.Find("ValorSensibilidad").GetComponent<Text>();
        barraSensibilidad = GameObject.Find("Slider Sensibilidad").GetComponent<Slider>();
        barraVolumen = GameObject.Find("Slider Volumen").GetComponent<Slider>();

        allAudioSources = FindObjectsOfType<AudioSource>();

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

        barraVolumen.value = 60;

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
            Cambiar_AudioSource();
        }
        valorSensibilidad.text = Mathf.Round(barraSensibilidad.value).ToString();
        valorVolumen.text = Mathf.FloorToInt(barraVolumen.value).ToString();
    }
    /*! \brief Pausamos el juego y desbloqueamos el cursor
    */
    public void Pausa()
    {
        Time.timeScale = 0f;
        ui.enabled = false;
        pausa.enabled = true;
        opciones.enabled = false;
        cronometro.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //StopAllAudio();
    }
    /*! \brief Invertimos los cambios realizados en el metodo Pausa()
    */
    public void Reanudar()
    {
        Time.timeScale = 1f;
        ui.enabled = true;
        pausa.enabled = false;
        opciones.enabled = false;
        cronometro.enabled = true;
        pausado = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    /*! \brief Salimos a la escena principal
    */
    public void Salir()
    {
        SceneManager.LoadScene("Menu Principal");
    }
    /*! \brief Invertimos los cambios realizados en el metodo Pausa()
    */
    public void Opciones()
    {
        ui.enabled = false;
        pausa.enabled = false;
        opciones.enabled = true;
    }
    /*! \brief Modificamos el volumen general
    */
    public void ajusteVolumen()
    {
        am.SetFloat("audio", barraVolumen.value - 80);
    }
    /*! \brief Modificamos los valores de las variables contenidas en el script Movimiento
    */
    public void ajusteSensibilidad()
    {
        codigo.sensibilidad = barraSensibilidad.value * 100;
    }
    public void Cambiar_AudioSource()
    {
        foreach (AudioSource a in allAudioSources)
        {
            if (a.isActiveAndEnabled == true)
            {
                if (a.isPlaying) a.Pause();
                else a.UnPause();
            }
        }
    }
}
