using TMPro;
using System.Collections;
using UnityEngine;


public class Interactuar : MonoBehaviour
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
        if (isPlayerInRange == true && Input.GetKeyDown("f") || Input.GetKeyDown("r"))
        {
            if (!comenzoDialogo)
            {
                IniciarDialogo();
            }
            else if (texto.text == Textos[lineaTexto])
            {
                SiguienteLinea();
                if (lineaTexto == Textos.Length && Input.GetKeyDown("r"))
                {
                    Accion();
                }
            }
            else
            {
                StopAllCoroutines();
                texto.text = Textos[lineaTexto];
                if (lineaTexto == Textos.Length  && Input.GetKeyDown("r"))
                {
                    Accion();
                }
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

    public void Accion() 
    {
        Debug.Log("Se acciono el Boton");
        // Logica del boton
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
