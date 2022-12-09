using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BeatEnemy2 : MonoBehaviour
{
    [SerializeField]
    private Animator PlayerAnim;

    private GameObject[] enemies;
    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;
    [SerializeField]
    private GameObject enemy3;

    private int enemiesNum;

    public bool isAttacked1;
    public bool isAttacked2;
    public bool isAttacked3;

    [SerializeField]
    private EnemyStatus2 enemyStatus1;

    [SerializeField]
    private EnemyStatus2 enemyStatus2;

    [SerializeField]
    private EnemyStatus2 enemyStatus3;

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

        if (enemiesNum == 0)
        {
            StartCoroutine("WinAnimation");
        }
        else
        {
            PlayerAnim.SetBool("IsVictory", false); //AnimatorのIsAvoke変数をtrueに設定
        }
    }


    //オブジェクトと接触した瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(sound1);

            if (other.name == "Enemy2_1")
            {
                //EnemyStatusスクリプトのHPが0より小さくなったら
                if (enemyStatus1.hp1 - enemyStatus1.attackPower <= 0)
                {
                    canDeath = true;
                }
                isAttacked1 = true;
            }
            else if (other.name == "Enemy2_2")
            {
                //EnemyStatusスクリプトのHPが0より小さくなったら
                if (enemyStatus2.hp2 - enemyStatus2.attackPower <= 0)
                {
                    canDeath = true;

                }
                isAttacked2 = true;
            }
            else if (other.name == "Enemy2_3")
            {
                //EnemyStatusスクリプトのHPが0より小さくなったら
                if (enemyStatus3.hp3 - enemyStatus3.attackPower <= 0)
                {
                    canDeath = true;

                }
                isAttacked3 = true;

            }
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
            SceneManager.LoadScene("map2");
        });
        // 数秒後にしたいこと(B)

    }
}
