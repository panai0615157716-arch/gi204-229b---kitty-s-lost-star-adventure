using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class HP_Player : MonoBehaviour
{
    [Header("HP Settings")]
    public int maxHP = 100;
    public int currentHP;
    [Header("UI Settings")]
    public TextMeshProUGUI hpText;
    public Image healthBarFill;
    [Header("Sound Settings")]
    public GameObject hurtSoundPrefab;
    public GameObject gameOverSoundPrefab;
    [Header("Game Over Settings")]
    public GameObject gameOverPanel;
    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;
        UpdateHPUI();

        if (currentHP <= 0)
        {
            Debug.Log("Game Over!");

            if (gameOverSoundPrefab != null)
            {
                Instantiate(gameOverSoundPrefab);
            }

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {

            if (hurtSoundPrefab != null)
            {
                Instantiate(hurtSoundPrefab);
            }
        }
    }
    void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHP;
        }
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHP / maxHP;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(20);
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GotoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }





}
