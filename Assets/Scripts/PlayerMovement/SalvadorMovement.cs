using UnityEngine;

public class SalvadorMovement : MonoBehaviour
{
    [Header("Movement Specifications")]
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private GameObject groundDetector;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool playerDog;

    [Header("Sprite Specifications")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite runSprite;
    [SerializeField] private Sprite jumpSprite;

    private Rigidbody2D playerRB;
    private bool isGrounded;
    private float groundRadius = 0.5f;
    private bool jumpPressed = false;
    private bool aPressed = false;
    private bool dPressed = false;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        //Sprite and Animation Renderers (?
    }

    private void Update()
    {
        if (playerDog)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) jumpPressed = true;
            if (Input.GetKey(KeyCode.LeftArrow)) aPressed = true;
            if (Input.GetKey(KeyCode.RightArrow)) dPressed = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W)) jumpPressed = true;
            if (Input.GetKey(KeyCode.A)) aPressed = true;
            if (Input.GetKey(KeyCode.D)) dPressed = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundDetector.transform.position, groundRadius, groundLayer);

        //Horizontal Movement
        if (aPressed)
        {
            playerRB.linearVelocity = new Vector2(-walkSpeed, playerRB.linearVelocity.y); //Moving the RigidBody of the Character to the Left
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); // Rotating the Character to the Left
            aPressed = false;
        }
        else if (dPressed)
        {
            playerRB.linearVelocity = new Vector2(walkSpeed, playerRB.linearVelocity.y); // Moving the RigidBody of the Character to the Right
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); // Rotating the Character to the Right
            dPressed = false;
        }
        else playerRB.linearVelocity = new Vector2(0, playerRB.linearVelocity.y);

        // Jumping
        if (jumpPressed && isGrounded)
        {
            playerRB.linearVelocity = new Vector2(0, jumpForce);
            jumpPressed = false;
        }

        // Setting jump sprite
        /*if (!isGrounded)
        {
            animator.enabled = false; // Turning off animation.
            sr.sprite = jumpSprite; // Setting the sprite.
        }
        else animator.enabled = true; // Turning on animation.*/
    }
}
