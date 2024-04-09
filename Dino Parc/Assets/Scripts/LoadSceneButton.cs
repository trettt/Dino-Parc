using UnityEngine;
using UnityEngine.SceneManagement; // Asigură-te că ai această linie pentru a folosi SceneManager

public class LoadSceneButton : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
