using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] GameObject gameOverPanel; // หน้าจอตอนชนะ
    [SerializeField] GameObject warningText;   // ลาก WarningText มาใส่ช่องนี้

    [Header("Sound Settings")]
    public GameObject winSoundPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Playercat"))
        {
            Movement playerScript = other.GetComponent<Movement>();

            if (playerScript != null)
            {
                if (playerScript.currentCoin >= 3)
                {
                    // ถ้าครบ 3 อัน -> ชนะ
                    WinGame();
                }
                else
                {
                    // ถ้าไม่ครบ -> โชว์ข้อความเตือน
                    if (warningText != null)
                    {
                        warningText.SetActive(true);
                    }
                    Debug.Log("เหรียญยังไม่ครบ!");
                }

            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Playercat"))
        {
            if (warningText != null)
            {
                warningText.SetActive(false);
            }
        }
    }

    void WinGame()
    {
        if (warningText != null) warningText.SetActive(false);
        if (winSoundPrefab != null) Instantiate(winSoundPrefab);
        if (gameOverPanel != null) gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("Win!");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
