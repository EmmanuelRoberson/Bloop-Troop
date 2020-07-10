using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
