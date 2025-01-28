using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    //the main menu should basically be a start and quit button
    [SerializeField] private string SceneName;

    public void LaunchGame()
    {
        LaunchScene(SceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void LaunchScene(string sceneName)
    {
        Debug.Log($"Loading scene {SceneName}")
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
