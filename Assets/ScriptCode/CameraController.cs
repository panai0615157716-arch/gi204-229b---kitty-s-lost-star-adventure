using UnityEngine;

public class CameraController : MonoBehaviour

{

    public Transform target; // ลากตัวแมวมาใส่ช่องนี้

    public Vector3 offset = new Vector3(0, 2, -5); // ระยะห่างจากตัวแมว

    public float sensitivity = 5f; // ความเร็วในการหมุน

    private float currentX = 0f;

    private float currentY = 0f;

    void LateUpdate()

    {

        // 1. เช็คว่า "คลิกขวาค้างไว้" หรือไม่

        if (Input.GetMouseButton(1)) // 1 คือปุ่มขวา

        {

            // ดึงค่าการขยับเมาส์มาสะสมไว้

            currentX += Input.GetAxis("Mouse X") * sensitivity;

            currentY -= Input.GetAxis("Mouse Y") * sensitivity;

            // จำกัดมุมก้ม-เงย ไม่ให้กล้องตีลังกา

            currentY = Mathf.Clamp(currentY, -10f, 40f);

        }

        // 2. คำนวณตำแหน่งและองศาของกล้อง

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // ให้กล้องหมุนรอบตัวแมวตามตำแหน่ง Offset

        if (target != null)

        {

            transform.position = target.position + rotation * offset;

            transform.LookAt(target.position + Vector3.up * 1.5f); // ให้กล้องมองไปที่หัวแมว

        }

    }

}
 