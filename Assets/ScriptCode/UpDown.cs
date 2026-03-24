using UnityEngine;

public class AutoOscillate : MonoBehaviour
{
    [Header("การตั้งค่าการส่าย")]
    public float amplitude = 2.0f; // ระยะที่จะส่ายออกไปจากจุดกลาง (หน่วยเป็นเมตร)
    public float frequency = 1.0f; // ความเร็วในการส่าย (รอบต่อวินาที)

    private Vector3 startPos;

    void Start()
    {
        // จำตำแหน่งเริ่มวางไว้เป็นจุดศูนย์กลาง
        startPos = transform.position;
    }

    void Update()
    {
        // คำนวณค่าการส่าย
        float offset = Mathf.Sin(Time.time * frequency * Mathf.PI * 2) * amplitude;


        // startPos.x + offset (ซ้ายขวา) 
        // startPos.y + offset (ขึ้นลง)
        transform.position = new Vector3(startPos.x, startPos.y + offset, startPos.z);
    }
}