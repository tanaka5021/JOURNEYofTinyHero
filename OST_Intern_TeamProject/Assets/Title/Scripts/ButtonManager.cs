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


    //Start�{�^���N���b�N�ŒT���V�[���ɑJ��
    public void OnClickStartButton()
    {
        fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene("map0");
        });
    }
    //Menu�{�^���Ń��j���[��ʁi�p�l���j�\��
    public void OnClickMenuButton()
    {
        MenuPanel.SetActive(true);
    }

    //Menupanel��Back�{�^���Ńp�l����\��
    public void OnClickBackButton()
    {
        MenuPanel.SetActive(false);
    }

    //Retry�{�^���Ńo�g���V�[���ɑJ��
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

    //Return�{�^���Ń^�C�g���V�[���ɑJ��
    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("Title");
    }
    //�o�g������߂�p�i���j
    public void OnClickmodoru()
    {
        SceneManager.LoadScene("map1");
    }


}

