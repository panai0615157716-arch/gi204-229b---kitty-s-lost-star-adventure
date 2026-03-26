using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuController : MonoBehaviour
{
   
    public void PlayGame()
    {
      
        SceneManager.LoadScene(1); 
    }

   
    public void QuitGame()
    {
        Debug.Log("ปิดเกมแล้วจ้า ปิดหน้าต่างเมนู!"); 

          Application.Quit(); 

              #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
