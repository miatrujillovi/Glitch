using UnityEngine;
using UnityEngine.Events;

public class Puzzle3SoloPerro : MonoBehaviour
{
    [Header("Scene Management")]
    public UnityEvent actions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PerroJugador"))
        {
            actions.Invoke();
        }
    }
}
