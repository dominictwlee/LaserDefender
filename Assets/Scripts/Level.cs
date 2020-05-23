using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Level : MonoBehaviour
{
    public enum Scenes
    {
        Game,
        StartMenu,
        GameOver,
    }
 
    private Dictionary<Scenes, string> sceneNames = new Dictionary<Scenes, string>() { 
        [Scenes.Game] = "Core Game",
        [Scenes.GameOver] = "Game Over",
        [Scenes.StartMenu] = "Start Menu",
    };

    public void LoadGameScene() => LoadScene(Scenes.Game);

    public void LoadGameOver() => LoadScene(Scenes.GameOver);

    public void LoadStartMenu() => LoadScene(Scenes.StartMenu);

    public void QuitGame() => Application.Quit();

    public void LoadScene(Scenes scenes)
    {
        SceneManager.LoadScene(sceneNames[scenes]);
    }
}
