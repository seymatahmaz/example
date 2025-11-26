using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    private TriangleActions control;
    private Rigidbody2D rb;
    void Awake()
    {
        control = new TriangleActions();
        control.Player.Jump.performed += Jump;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }   

    void Jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Jumped");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);
    }

}
