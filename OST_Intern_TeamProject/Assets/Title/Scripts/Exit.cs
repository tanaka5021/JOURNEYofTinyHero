using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.Application;

public class Exit : MonoBehaviour
{
    public GameObject EndConfirmPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Exit�{�^���Ŋm�F�p�l���\��
    public void OnClickExitButton()
    {
        EndConfirmPanel.SetActive(true);
    }

    //Yes�ŃQ�[���I��
    public void OnClickYesButton()
    {
        /*
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��(�G�f�B�^)
#else
       Application.Quit();//�Q�[���v���C�I���i�r���h�ρj
#endif
        */

        UnityEngine.Application.Quit();//�Q�[���v���C�I���i�r���h�ρj

    }

    //No�Ńp�l����\��
    public void OnClickNoButton()
    {
        EndConfirmPanel.SetActive(false);
    }
}
