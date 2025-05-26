using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 6f;
    public float horizontalSpeed = 3f;

    private PlayerInputActions controls;
    private Vector2 moveInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        controls = new PlayerInputActions();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void FixedUpdate()
    {
        Vector3 currentVelocity = rb.linearVelocity;

        // Apply horizontal and forward movement, keep Y (gravity) unchanged
        Vector3 targetVelocity = new Vector3(
            moveInput.x * horizontalSpeed,
            currentVelocity.y,  // Keep gravity
            forwardSpeed
        );

        rb.linearVelocity = targetVelocity;
    }
}
