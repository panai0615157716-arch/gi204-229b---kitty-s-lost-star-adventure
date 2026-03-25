using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HP_Player : MonoBehaviour
{
    [Header("HP Settings")]
    public int maxHP = 100;
    public int currentHP;
    [Header("UI Settings")]
    public TextMeshProUGUI hpText;
    public Image healthBarFill; 
    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;
        UpdateHPUI();
        Debug.Log("เลือดลด! เหลือ: " + currentHP);
        if (currentHP <= 0)
        {
            Debug.Log("Game Over!");
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
}