using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level1";

    public void LoadNewGame() 
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
