using UnityEngine;

public class SonidoDePlataforma : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private AudioClip Nota;
    public VerificacionDePuzzle verificador;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = Nota;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            audio.Play();
            verificador.RegisterTrigger(gameObject);
        }
    }
}
