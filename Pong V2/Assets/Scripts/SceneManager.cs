using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        // Load a scene named "Level2"
        SceneManager.LoadScene("Level2");
    }
}