using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Playercat")
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;

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
    }
}
