using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene("StartingScene");
    }

    public void Options()
    {
        //Set up options menu activate and deactivate
    }

    public void Quit()
    {
        Application.Quit();
    }
}
