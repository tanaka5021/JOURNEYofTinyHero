using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    //敵のアニメーション格納
    [SerializeField]
    private Animator anim;

    //攻撃の種類
    private int AttackNumber = 0;

    //敵のリジッドボディ
    [SerializeField]
    private Rigidbody rb;

    //プレイヤーが近くにいるかどうかの判定
    private bool isNearPlayer;

    [SerializeField]
    private GameObject Enemy;

    private Vector3 Position;

    public static bool nowAttacked;

    public AudioClip sound1;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

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
                    anim.SetBool("isAttack1", true); //AnimatorのIsRun変数をtrueに設定
                    nowAttacked = true;
                    break;
                case 2:// 処理２
                    anim.SetBool("isAttack2", true); //AnimatorのIsRun変数をtrueに設定
                    nowAttacked = true;
                    break;
                default:
                    break;
            }



        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(sound1);

            isNearPlayer = true;

            anim.SetBool("inArea", isNearPlayer);

            AttackNumber = Random.Range(1, 3);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearPlayer = false;

            anim.SetBool("inArea", isNearPlayer);
            Reset();
        }
    }

    void Reset()
    {
        anim.SetBool("isAttack1", false); //AnimatorのIsRun変数をtrueに設定
        anim.SetBool("isAttack2", false); //AnimatorのIsRun変数をtrueに設定


        AttackNumber = 0;

        isNearPlayer = false;
    }
}
