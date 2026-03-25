using UnityEngine;
public class SlideLeft : MonoBehaviour
{
    [Header("Kinematics Settings (s = v * t)")]
    public float velocity = 3.0f;
    public float maxDistance = 5.0f;
    private Vector3 startPos;
    private int direction = 1;
    // เอาไว้จำตำแหน่งเก่าและจำว่าแมวเกาะอยู่ไหม
    private Vector3 lastPosition;
    private Transform playerTransform;
    void Start()
    {
        startPos = transform.position;
        lastPosition = transform.position; // จำตำแหน่งตั้งต้นไว้
    }
    void Update()
    {
        // 1. คำนวณระยะทาง s = v * t
        float s = velocity * Time.deltaTime;
        // 2. ขยับแท่น
        transform.Translate(Vector3.left * direction * s);
        // 3. คำนวณว่าเฟรมนี้แท่นขยับไปเป็นระยะทางเท่าไหร่ (Delta Position)
        Vector3 deltaMove = transform.position - lastPosition;
        // 4. ถ้ามีแมวยืนอยู่บนแท่นให้บวกระยะทางนั้นเข้ากับตัวแมวด้วย
        if (playerTransform != null)
        {
            playerTransform.position += deltaMove;
        }
        // อัปเดตตำแหน่งล่าสุดของแท่นเตรียมไว้ใช้รอบหน้า
        lastPosition = transform.position;
        // เช็คระยะสูงสุดเพื่อกลับตัว
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if (currentDistance >= maxDistance)
        {
            direction *= -1;
            startPos = transform.position;
        }
    }
    // เมื่อแมวกระโดดมาเหยียบให้จำตัวแมวไว้
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Playercat"))
        {
            playerTransform = collision.transform;
        }
    }
    // เมื่อแมวกระโดดออกไปให้ลืมตัวแมว
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Playercat"))
        {
            if (playerTransform == collision.transform)
            {
                playerTransform = null;
            }
        }
    }
}