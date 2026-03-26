using UnityEngine;
public class Movement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 100.0f;
    //  F = ma
    public float jumpAcceleration = 10.0f;
    private bool isGrounded = true;
    public float currentCoin = 0f;
    public GameObject itemSfxPrefab;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        float move = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(move) > 0.1f || Mathf.Abs(turn) > 0.1f)
        {
            anim.SetBool("IsWalking", true);
            transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, turn * rotationSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            if (rb != null)
            {

                float m = rb.mass;
                float a = jumpAcceleration;
                float calculatedForce = m * a;

                Debug.Log("�͡�ç���ⴴ: " + calculatedForce);

                rb.AddForce(Vector3.up * calculatedForce, ForceMode.Impulse);

                isGrounded = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;
        }
    }
    //    void OnCollisionStay(Collision collision)
    //    {
    //     if(collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded =    true;
    //     }
    //    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            currentCoin++;
            Debug.Log("Have Coin!" + currentCoin);

            Destroy(other.gameObject);
        }
    }
}