using UnityEngine;
using TMPro; // สำหรับแสดงผลเลือดบน UI
public class HP_Player : MonoBehaviour
{
    [Header("HP Settings")]
    public int maxHP = 100;
    public int currentHP;

    [Header("UI Settings")]
    public TextMeshProUGUI hpText; // ลาก Text UI ในหน้าจอมาใส่ช่องนี้

    void Start()
    {

        currentHP = maxHP;
        UpdateHPUI();

    }

    // ฟังก์ชันรับความเสียหาย (เรียกใช้จากสคริปต์อื่น หรือจากการชน)

    public void TakeDamage(int damage)

    {

        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;
        UpdateHPUI();
        Debug.Log("เลือดลด! เหลือ: " + currentHP);
        if (currentHP <= 0)
        {

            Debug.Log("Game Over!");

            // น้องปลาลอยสามารถเพิ่มคำสั่ง Restart เกมตรงนี้ได้ครับ

        }
    }
    // ฟังก์ชันอัปเดตตัวเลขบนจอ
    void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHP;
        }
    }

    // ตรวจสอบการชนกับสิ่งของอันตราย (หัวข้อ A: Collision)
    private void OnCollisionEnter(Collision collision)
    {
        // ถ้าตัวแมวไปชนวัตถุที่ตั้ง Tag ว่า Spike
        if (collision.gameObject.CompareTag("Spike"))
        {

            TakeDamage(20); // ลดเลือดครั้งละ 20

        }

    }



}
