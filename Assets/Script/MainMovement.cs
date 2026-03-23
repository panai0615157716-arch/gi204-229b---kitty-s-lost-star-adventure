using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 20f;
    public float maxSpeed = 8f;

    [Header("Jump Physics (Rubric)")]
    public float jumpMultiplier = 2.5f;
    private bool isGrounded;
    private bool canDoubleJump;

    [Header("Dash Mechanic")]
    public float dashForce = 15f;
    private bool canDash = true;

    private Rigidbody rb;
    private Vector3 movementInput;

    public object GameManager { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // ป้องกันไม่ให้แมวล้มกลิ้ง
        rb.freezeRotation = true;
    }

    void Update()
    {
        // รับ Input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movementInput = new Vector3(moveX, 0, moveZ).normalized;

        // ระบบกระโดด
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                PerformPhysicsJump();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                PerformPhysicsJump();
                canDoubleJump = false; 
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            PerformDash();
        }
    }

    void FixedUpdate()
    {
        // FRICTION & MOVEMENT
        // ใช้ AddForce เพื่อให้ Physic Material (Ice, Mud) 
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(movementInput * moveForce, ForceMode.Force);
        }
    }

    private void PerformPhysicsJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // รีเซ็ตความเร็วแกน Y ก่อนกระโดด

        float gravityMagnitude = Mathf.Abs(Physics.gravity.y);
        float jumpForce = rb.mass * gravityMagnitude * jumpMultiplier;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void PerformDash()
    {
        Vector3 dashDir = movementInput == Vector3.zero ? transform.forward : movementInput;
        rb.AddForce(dashDir * dashForce, ForceMode.VelocityChange);
        canDash = false;
        Invoke(nameof(ResetDash), 2f); // คูลดาวน์ Dash 2 วินาที
    }

    private void ResetDash() => canDash = true;

    // TRIGGER & COLLISION 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(other.gameObject); // เก็บดาวแล้วดาวหายไป
        }
        else if (other.CompareTag("Water") || other.CompareTag("Void"))
        {
            object value = GameManager.Instance.TakeDamage();
        }
        else if (other.CompareTag("Goal"))
        {
            GameManager.Instance.WinGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.TakeDamage();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
