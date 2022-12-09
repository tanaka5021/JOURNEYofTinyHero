using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResume : MonoBehaviour
{
    public void OnClick()
    {
        closePauseMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closePauseMenu();
        }
    }

    private void closePauseMenu()
    {
        Time.timeScale = 1.0f;
        Destroy(transform.parent.gameObject);
        Debug.Log("Pushed");
    }

}
