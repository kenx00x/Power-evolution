using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            SceneManager.LoadScene("StartMenu");
    }
}