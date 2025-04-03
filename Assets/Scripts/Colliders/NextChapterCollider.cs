using UnityEngine;
using UnityEngine.Events;

public class NextChapterCollider : MonoBehaviour
{
    [Header("Scene Management")]
    public UnityEvent actions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            actions.Invoke();
        }
    }
}
