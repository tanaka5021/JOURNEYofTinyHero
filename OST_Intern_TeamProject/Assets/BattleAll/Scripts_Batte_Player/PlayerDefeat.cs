using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDefeat : MonoBehaviour
{
    [SerializeField]
    private string targetSceneName;

    public static string sceneName;

    //敵のアニメーション格納
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

        //GetComponentを用いてAnimatorコンポーネントを取り出す(animに格納)
        anim = Player.GetComponent<Animator>();

        //コルーチンの呼び出し
        StartCoroutine("DieAnimation");
    }

    private void changeScene()
    {
    }

    //Aの後に2秒待ってBをする
    IEnumerator DieAnimation()
    {

        // 初めにしたいこと(A)
        anim.SetBool("IsDie", true); //AnimatorのIsRun変数をtrueに設定

        AudioFlag = true;

        yield return new WaitForSeconds(2.0f); //待つ時間

        // 数秒後にしたいこと(B)
        SceneManager.LoadScene("GameOver");


    }
}
