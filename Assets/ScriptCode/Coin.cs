using UnityEngine;
using TMPro; // สำหรับแสดงคะแนนบน UI

public class CoinCollector : MonoBehaviour
{
    public int score = 0;          // คะแนนปัจจุบัน
    public TextMeshProUGUI scoreText; // ลาก Text UI มาใส่ช่องนี้

    // ใช้ OnTriggerEnter เพราะเราติ๊ก Is Trigger ที่เหรียญไว้
    private void OnTriggerEnter(Collider other)
    {
        // ถ้าสิ่งที่แมวเดินทะลุเข้าไปมี Tag ว่า Coin
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 1;            // เพิ่มคะแนน 1 แต้ม
            UpdateScoreUI();       // อัปเดตตัวเลขบนจอ

            Destroy(other.gameObject); // สั่งให้เหรียญหายไปจากฉาก
            Debug.Log("เก็บเหรียญได้แล้ว! คะแนนตอนนี้: " + score);
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score;
        }
    }
}