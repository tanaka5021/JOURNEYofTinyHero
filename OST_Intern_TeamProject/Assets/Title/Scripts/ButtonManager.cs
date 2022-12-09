using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    public Animator anim;
    public GameObject MenuPanel;
    public Fade fade;
    private float Timer;


    //Startボタンクリックで探索シーンに遷移
    public void OnClickStartButton()
    {
        fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene("map0");
        });
    }
    //Menuボタンでメニュー画面（パネル）表示
    public void OnClickMenuButton()
    {
        MenuPanel.SetActive(true);
    }

    //MenupanelのBackボタンでパネル非表示
    public void OnClickBackButton()
    {
        MenuPanel.SetActive(false);
    }

    //Retryボタンでバトルシーンに遷移
    public void OnClickRetryButton()
    {
        //anim = Player.gameObject.GetComponent<Animator>();
        //anim.SetBool("IsRetry", true);

        if (RemainField.FieldNumber == 0)
        {
            //map0

            fade.FadeIn(1f, () =>
            {
                SceneManager.LoadScene("BattleScean1");
            });

        }
        else if (RemainField.FieldNumber == 1)
        {
            //map1
            fade.FadeIn(1f, () =>
            {
                SceneManager.LoadScene("BattleScean1");
            });
        }
        else if (RemainField.FieldNumber == 2)
        {
            //map2
            fade.FadeIn(1f, () =>
            {
                SceneManager.LoadScene("BattleScean2");
            });
        }
        else if (RemainField.FieldNumber == 3)
        {
            //boss
            fade.FadeIn(1f, () =>
            {
                SceneManager.LoadScene("BossScean");
            });
        }


    }

    //Returnボタンでタイトルシーンに遷移
    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("Title");
    }
    //バトルから戻る用（仮）
    public void OnClickmodoru()
    {
        SceneManager.LoadScene("map1");
    }


}

