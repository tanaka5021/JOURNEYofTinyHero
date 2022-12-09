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

    //Exitボタンで確認パネル表示
    public void OnClickExitButton()
    {
        EndConfirmPanel.SetActive(true);
    }

    //Yesでゲーム終了
    public void OnClickYesButton()
    {
        /*
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了(エディタ)
#else
       Application.Quit();//ゲームプレイ終了（ビルド済）
#endif
        */

        UnityEngine.Application.Quit();//ゲームプレイ終了（ビルド済）

    }

    //Noでパネル非表示
    public void OnClickNoButton()
    {
        EndConfirmPanel.SetActive(false);
    }
}
