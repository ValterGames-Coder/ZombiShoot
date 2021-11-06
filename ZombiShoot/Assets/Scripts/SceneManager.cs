using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void SwitchScene(int scene) => UnityEngine.SceneManagement.SceneManager.LoadScene(scene);

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
