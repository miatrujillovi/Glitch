using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class VerGlitches : MonoBehaviour
{
    [Header("Referencias")]
    [Tooltip("Prefab de la marca / glitch que se va a usar para marcar que un objeto tiene glitch")]
    [SerializeField] private GameObject marcaPrefab;

    [Header("Variables")]
    [Tooltip("Tiempo visible de la marca antes de que desaparezca.")]
    [SerializeField, Range(0, 10)] private float tiempoVisible;

    private Dictionary<GameObject, GameObject> marcasInstanciadas = new Dictionary<GameObject, GameObject>();
    private List<GameObject> objetosEnTrigger = new List<GameObject>();

    private void Awake()
    {
        GameObject[] objetosConGlitch = GameObject.FindGameObjectsWithTag("Glitcheable");
        Debug.Log("Objetos encontrados: " + objetosConGlitch.Length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Habilidad();
        }
    }

    public void Habilidad()
    {
        foreach (GameObject objeto in objetosEnTrigger)
        {
            if (!marcasInstanciadas.ContainsKey(objeto))
            {
                GameObject nuevaMarca = Instantiate(marcaPrefab, objeto.transform.position, Quaternion.identity);
                nuevaMarca.transform.SetParent(objeto.transform);
                marcasInstanciadas[objeto] = nuevaMarca;

                StartCoroutine(DesaparecerMarca(objeto, tiempoVisible));
            }
        }
    }

    private IEnumerator DesaparecerMarca(GameObject objeto, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        if (marcasInstanciadas.ContainsKey(objeto))
        {
            Destroy(marcasInstanciadas[objeto]);
            marcasInstanciadas.Remove(objeto);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Glitcheable"))
        {
            if (!objetosEnTrigger.Contains(collision.gameObject))
            {
                objetosEnTrigger.Add(collision.gameObject);
            }
        }

        /*
        if (collision.gameObject.CompareTag("Glitcheable"))
        {
            Debug.Log("Es visible el glitch de: " + collision.name);

            if (!marcasInstanciadas.ContainsKey(collision.gameObject))
            {
                GameObject nuevaMarca = Instantiate(marcaPrefab, collision.transform.position, Quaternion.identity);
                nuevaMarca.transform.SetParent(collision.transform);

                marcasInstanciadas[collision.gameObject] = nuevaMarca;
            }
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Glitcheable"))
        {
            objetosEnTrigger.Remove(collision.gameObject);

            if (marcasInstanciadas.ContainsKey(collision.gameObject))
            {
                Destroy(marcasInstanciadas[collision.gameObject]);
                marcasInstanciadas.Remove(collision.gameObject);
            }
        }

        /*
        if (collision.gameObject.CompareTag("Glitcheable"))
        {
            Debug.Log("Ya no es visible el glitch de: " + collision.name);

            if (marcasInstanciadas.ContainsKey(collision.gameObject))
            {
                Destroy(marcasInstanciadas[collision.gameObject]); 
                marcasInstanciadas.Remove(collision.gameObject); 
            }
        }
        */
    }
}


