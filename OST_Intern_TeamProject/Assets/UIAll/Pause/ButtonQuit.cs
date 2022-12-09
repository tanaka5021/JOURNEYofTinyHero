using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonQuit : MonoBehaviour
{
    public void OnClick()
    {
        closePauseMenu();
    }

    private void closePauseMenu()
    {
        Time.timeScale = 1.0f;
        Destroy(transform.parent.gameObject);
        SceneManager.LoadScene("Scenes/Title");
    }


}
