using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;
    
    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        moveVelocity = 2f * maxSpeed / timeToFullSpeed;
        moveFriction = -2f * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2f * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (moveDirection.magnitude > 0)
        {
            rb.velocity += moveDirection * moveVelocity * Time.fixedDeltaTime;
            rb.velocity = new Vector2(
                Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x),
                Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y)
            );
        }
        else
        {
            rb.velocity += GetFriction() * Time.fixedDeltaTime;

            if (Mathf.Abs(rb.velocity.x) < stopClamp.x && Mathf.Abs(rb.velocity.y) < stopClamp.y)
            {
                rb.velocity = Vector2.zero;
            }
        }

        MoveBound();
    }

    private Vector2 GetFriction()
    {
        return moveDirection.magnitude > 0 ? moveFriction * moveDirection : stopFriction * rb.velocity.normalized;
    }

    private void MoveBound()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = mainCamera.aspect * cameraHeight;

        Vector2 position = transform.position;

        position.x = Mathf.Clamp(position.x, -cameraWidth, cameraWidth);
        position.y = Mathf.Clamp(position.y, -cameraHeight, cameraHeight);

        transform.position = position;
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 2.5f;
    }
}