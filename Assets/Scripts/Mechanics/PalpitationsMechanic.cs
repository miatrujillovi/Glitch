using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PalpitationsMechanic : MonoBehaviour
{
    [Header("Object to Work with")]
    [SerializeField] private GameObject _object;
    [SerializeField] private int requiredPalpitations;
    public UnityEvent actions;

    private bool isPlayerInRange = false;
    private int palpitationsCount;

    private void Update()
    {
        if (isPlayerInRange == true && Input.GetKeyDown(KeyCode.RightControl))
        {
            palpitationsCount++;
            if (palpitationsCount >= requiredPalpitations)
            {
                palpitationsCount = 0;
                actions.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            isPlayerInRange = true;
            palpitationsCount = 0;
            _object.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            isPlayerInRange = false;
            _object.SetActive(false);
        }
    }
}
