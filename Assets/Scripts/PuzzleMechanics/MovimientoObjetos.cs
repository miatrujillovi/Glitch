using UnityEngine;

public class MovimientoObjetos : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Vector2 posicionOriginal;
    [SerializeField] private Vector2 posicionAMover;
    [SerializeField, Range(0, 10f)] private float velocidad;

    private Vector2 objetivo;
    private bool enMovimiento = false;

    void Start()
    {
        transform.position = posicionOriginal;
        objetivo = posicionOriginal;
    }

    void Update()
    {
        if (enMovimiento)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

            if ((Vector2)transform.position == objetivo)
            {
                if (objetivo == posicionAMover)
                {
                    objetivo = posicionOriginal;
                }
                else
                {
                    enMovimiento = false;
                }
            }
        }

        /*if (Input.GetKeyDown(KeyCode.N))
        {
            moverobjetos();
        }*/

    }

    public void moverobjetos()
    {
        if (!enMovimiento)
        {
            enMovimiento = true;
            objetivo = posicionAMover;
        }
    }
}

