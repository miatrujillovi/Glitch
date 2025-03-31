using UnityEngine;

public class NextSceneCollider : MonoBehaviour
{
    [Header("New Positions")]
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform salvador;
    [SerializeField] private GameObject dog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            _camera.transform.position = new Vector3(20.28f, 0, -10);
            salvador.transform.position = new Vector2(12.8f, -2.56f);
            dog.SetActive(true);
        }
    }
}
