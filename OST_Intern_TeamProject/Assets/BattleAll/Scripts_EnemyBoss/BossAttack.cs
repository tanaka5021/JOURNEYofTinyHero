using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //敵のアニメーション格納
    [SerializeField]
    private Animator anim;

    //攻撃の種類
    private int AttackNumber = 0;
    public static int AttackVarsion;

    //敵のリジッドボディ
    [SerializeField]
    private Rigidbody rb;

    //プレイヤーが近くにいるかどうかの判定
    private bool isNearPlayer;

    [SerializeField]
    private GameObject Enemy;

    private Vector3 Position;


    // Start is called before the first frame update
    void Start()
    {
        //GetComponentを用いてRigidbodyコンポーネントを取り出す(rbに格納)
        rb = Enemy.gameObject.GetComponent<Rigidbody>();

        //GetComponentを用いてAnimatorコンポーネントを取り出す(animに格納)
        anim = Enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearPlayer)
        {
            Debug.Log(AttackNumber);

            switch (AttackNumber)
            {
                case 1:// 処理１
                    anim.SetBool("IsAttack1", true); //AnimatorのIsRun変数をtrueに設定
                    AttackVarsion = 1;
                    break;
                case 2:// 処理２
                    anim.SetBool("IsAttack2", true); //AnimatorのIsRun変数をtrueに設定
                    AttackVarsion = 2;
                    break;
                case 3://処理３
                    anim.SetBool("IsAttack3", true);
                    AttackVarsion = 3;
                    break;
                default:
                    AttackVarsion = 0;
                    break;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearPlayer = true;

            AttackNumber = Random.Range(1, 4);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearPlayer = false;

            Reset();
        }
    }

    void Reset()
    {
        anim.SetBool("IsAttack1", false); //AnimatorのIsRun変数をtrueに設定
        anim.SetBool("IsAttack2", false); //AnimatorのIsRun変数をtrueに設定
        anim.SetBool("IsAttack3", false); //AnimatorのIsRun変数をtrueに設定


        AttackNumber = 0;

        isNearPlayer = false;
    }

    //Aの後に2秒待ってBをする
    IEnumerator BossAnimation()
    {

        // 初めにしたいこと(A)

        yield return new WaitForSeconds(1.0f); //待つ時間

        // 数秒後にしたいこと(B)
        Reset();

    }
}
