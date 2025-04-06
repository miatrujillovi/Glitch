using UnityEngine;

public class FallManager : MonoBehaviour
{
    [Header("Characters Locations")]
    [SerializeField] private Transform salvador;
    [SerializeField] private Transform perro;

    [Header("New Collider")]
    [SerializeField] private GameObject nextScene;
    [SerializeField] private GameObject oldCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            if (BackgroundManager.currentPart == 1)
            {
                salvador.position = new Vector3(15.44f, 3.42f, 0f);
                perro.position = new Vector3(24.57f, 3.41f, 0f);
            } 
            else if (BackgroundManager.currentPart == 2)
            {
                salvador.position = new Vector3(12.65f, 1.77f, 0f);
                perro.position = new Vector3(27.73f, 1.81f, 0f);
            } 
            else if (BackgroundManager.currentPart == 3)
            {
                salvador.position = new Vector3(14.77f, 0.5f, 0f);
                perro.position = new Vector3(24.74f, 1.51f, 0f);
            } 
            else if (BackgroundManager.currentPart == 4)
            {
                salvador.position = new Vector3(15.7f, -0.88f, 0f);
                nextScene.SetActive(true);
                oldCollider.SetActive(false);
            }
        }
    }
}
