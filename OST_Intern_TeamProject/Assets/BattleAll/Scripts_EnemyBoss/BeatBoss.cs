using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BeatBoss : MonoBehaviour
{
    [SerializeField]
    private Animator PlayerAnim;

    private GameObject[] enemies;
    [SerializeField]
    private GameObject enemy;

    private int enemiesNum;

    public bool isAttacked;

    [SerializeField]
    private BossStatus bossStatus;

    public static bool canDeath = false;

    public AudioClip sound1;

    AudioSource audioSource;

    public Fade fade;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesNum = enemies.Length;

        if (enemiesNum <= 0)
        {
            StartCoroutine("WinAnimation");
        }
        else
        {
            PlayerAnim.SetBool("IsVictory", false); //AnimatorのIsVictory変数をfalseに設定
        }
    }


    //オブジェクトと接触した瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(sound1);

            //EnemyStatusスクリプトのHPが0より小さくなったら
            if (bossStatus.hp - bossStatus.attackPower <= 0)
            {
                canDeath = true;
            }
            isAttacked = true;

        }
    }

    //Aの後に2秒待ってBをする
    IEnumerator WinAnimation()
    {

        // 初めにしたいこと(A)
        PlayerAnim.SetBool("IsVictory", true); //AnimatorのIsRun変数をtrueに設定

        yield return new WaitForSeconds(2.0f); //待つ時間

        fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene("GameClear");
        });
    }
}
