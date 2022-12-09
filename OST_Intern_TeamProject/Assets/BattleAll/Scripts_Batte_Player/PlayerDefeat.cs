using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDefeat : MonoBehaviour
{
    [SerializeField]
    private string targetSceneName;

    public static string sceneName;

    //�G�̃A�j���[�V�����i�[
    [SerializeField]
    private Animator anim;

    public GameObject Player;


    public AudioClip sound1;

    AudioSource audioSource;

    public static bool AudioFlag = false;



    void SetUp()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void playerDefeated()
    {
        /*
        sceneName = SceneManager.GetActiveScene().name;
        Invoke(nameof(changeScene), 1.0f);
        */

        //GetComponent��p����Animator�R���|�[�l���g�����o��(anim�Ɋi�[)
        anim = Player.GetComponent<Animator>();

        //�R���[�`���̌Ăяo��
        StartCoroutine("DieAnimation");
    }

    private void changeScene()
    {
    }

    //A�̌��2�b�҂���B������
    IEnumerator DieAnimation()
    {

        // ���߂ɂ���������(A)
        anim.SetBool("IsDie", true); //Animator��IsRun�ϐ���true�ɐݒ�

        AudioFlag = true;

        yield return new WaitForSeconds(2.0f); //�҂���

        // ���b��ɂ���������(B)
        SceneManager.LoadScene("GameOver");


    }
}
