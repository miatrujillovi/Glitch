using UnityEngine;

public class Puzzle3Solution : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField, Range (0f, 5f)] private float velocidadSe�oraBuenosDias;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocidadSe�oraBuenosDias, 0f);
    }
}
