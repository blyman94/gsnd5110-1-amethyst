using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Allows the game to restart by reloading the current scene.
/// </summary>
[CreateAssetMenu]
public class ApplicationManager : ScriptableObject
{
    /// <summary>
    /// Restarts the game by reloading the current scene.
    /// </summary>
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
