using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStandby : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePrehub;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.Find("PauseUI(Clone)"))
        {
            Instantiate(pausePrehub);
        }
    }
}
