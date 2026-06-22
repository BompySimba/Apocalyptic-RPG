using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDir;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 5.0f;
    [SerializeField] float jumpForce = 3f;
    float currentSpeed;

    bool isGrounded;
    float groundCheckDistance = 0.2f;
    [SerializeField] Transform groundCheckObj;
    [SerializeField] LayerMask groundLayer;

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        moveDir.x = movementInput.x;
        moveDir.z = movementInput.y;
        if(moveDir.magnitude > 1f)
        {
            moveDir.Normalize();
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            currentSpeed = runSpeed;
        }
        else if(context.canceled)
        {
            currentSpeed = speed;
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, lookInput.x * rotationSpeed * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheckObj.position, groundCheckDistance, groundLayer);
        rb.linearVelocity = (transform.forward * moveDir.z + transform.right * moveDir.x) * currentSpeed + Vector3.up * rb.linearVelocity.y;
    }
}
