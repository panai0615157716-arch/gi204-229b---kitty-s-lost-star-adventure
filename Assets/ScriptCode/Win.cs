using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] GameObject gameOverPanel;
    [Header("Sound Settings")]
    public GameObject winSoundPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Playercat")
        {
            if (winSoundPrefab != null)
            {
                Instantiate(winSoundPrefab);
            }
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Debug.Log("°¥ÕÕ°®“°‡°¡·≈È«®È“!");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}