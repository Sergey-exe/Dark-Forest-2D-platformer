using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
