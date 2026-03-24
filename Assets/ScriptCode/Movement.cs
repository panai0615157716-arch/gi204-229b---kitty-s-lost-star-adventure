using UnityEngine;
public class PlayerControllerr : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 100.0f;
    // (ความเร่ง) F = ma
    public float jumpAcceleration = 10.0f; // ตัวแปร a (ความเร่ง)
                                           // ตัวแปรเช็คว่าแตะพื้นอยู่ไหม 
    private bool isGrounded = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // ส่วนของการเดิน 
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
        //  ส่วนของการกระโดด
        // เงื่อนไขต้องกด Spacebar และ ตัวละครต้องแตะพื้นอยู่ (isGrounded == true) ถึงจะกระโดดได้
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            if (rb != null)
            {
                // คำนวณ Force จากสูตร F = ma ก่อนใช้งาน
                float m = rb.mass;                   // m : ดึงค่ามวลมาจาก Rigidbody
                float a = jumpAcceleration;          // a : ดึงค่าความเร่งที่เราตั้งไว้
                float calculatedForce = m * a;       // F = ma : คำนวณหาแรง
                                                     // นำผลลัพธ์ calculatedForce ที่ได้ไปใช้แสดงผลฟิสิกส์
                rb.AddForce(Vector3.up * calculatedForce, ForceMode.Impulse);
                // พอกระโดดปุ๊บสถานะคือลอยอยู่กลางอากาศ
                isGrounded = false;
            }
        }
    }
    // ใช้ Collider ร่วมกับ OnCollisionEnter
    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อกล่อง Collider ของแมว หล่นลงมาชนกับกล่อง Collider ของพื้น
    void OnCollisionEnter(Collision collision)
    {
        // ถ้าวัตถุที่แมวตกลงมาชนมี Tag ว่า "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // ให้รีเซ็ตสถานะว่าเท้าแตะพื้นแล้วเพื่อให้พร้อมกระโดดครั้งต่อไป
            isGrounded = true;
        }
    }
}