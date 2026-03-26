using UnityEngine;
using TMPro; // TextMeshPro
public class TimeManager : MonoBehaviour
{
   public TextMeshProUGUI timeText; // ลาก Text ที่จะโชว์เวลามาใส่ช่องนี้
   private float timeElapsed = 0;   // ตัวแปรเก็บวินาทีที่ผ่านไป
   void Update()
   {
       // 1. บวกเวลาเพิ่มตามวินาทีจริงที่ผ่านไป
       timeElapsed += Time.deltaTime;
       // 2. คำนวณหานาทีและวินาที
       int minutes = Mathf.FloorToInt(timeElapsed / 60); // หาร 60 เอาแต่เลขหน้าเป็นนาที
       int seconds = Mathf.FloorToInt(timeElapsed % 60); // หาเศษที่เหลือเป็นวินาที
       // 3. แสดงผลบน UI (Format ให้เป็น 00:00)
       if (timeText != null)
       {
           timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
       }
   }
}