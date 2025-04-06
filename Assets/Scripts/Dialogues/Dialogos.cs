using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using System.ComponentModel;

public class Dialogos : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private AudioClip Voices;
    [SerializeField] private GameObject marca;
    public GameObject panelDialogo;
    public TextMeshProUGUI texto;

    [Header("Variables")]
    [Tooltip("El tiempo que hay en la impresion de cada caracter del string")]
    [SerializeField, Range(0, 0.2f)] private float typingtime;
    [Tooltip("La cantidad de caracteres que se necesitan para que se reproduzca el sonido de dialogo")]
    [SerializeField, Range(1, 10)] private int cantidadCaracteres;

    [Header("Lineas de dialogo")]
    [SerializeField, TextArea(6, 6)] private string[] Textos;

    private bool isPlayerInRange = false;
    private bool comenzoDialogo;
    private int lineaTexto;
    private AudioSource audio;


    void Start()
    {
        panelDialogo.SetActive(false);
        audio = GetComponent<AudioSource>();
        audio.clip = Voices;
    }

    void Update()
    {
        if (isPlayerInRange == true && Input.GetKeyDown("f"))
        {
            if (!comenzoDialogo)
            {
                IniciarDialogo();
            }
            else if (texto.text == Textos[lineaTexto])
            {
                SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                texto.text = Textos[lineaTexto];
            }
        }
    }

    private void IniciarDialogo()
    {
        comenzoDialogo = true;
        panelDialogo.SetActive(true);
        marca.SetActive(false);
        lineaTexto = 0;
        Time.timeScale = 0f;
        StartCoroutine(MostrarLinea());
    }

    private void SiguienteLinea()
    {
        lineaTexto++;
        if (lineaTexto < Textos.Length)
        {
            StartCoroutine(MostrarLinea());
        }
        else
        {
            comenzoDialogo = false;
            panelDialogo.SetActive(false);
            marca.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator MostrarLinea()
    {
        texto.text = string.Empty;
        int charindice = 0;

        foreach (char ch in Textos[lineaTexto])
        {
            texto.text += ch;

            if (charindice % cantidadCaracteres == 0)
            {
                audio.Play();
            }
            charindice++;
            yield return new WaitForSecondsRealtime(typingtime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            isPlayerInRange = true;
            Debug.Log("Se puede interacturar");
            marca.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            isPlayerInRange = false;
            Debug.Log("Ya no se puede interacturar");
            marca.SetActive(false);
        }
    }
}
