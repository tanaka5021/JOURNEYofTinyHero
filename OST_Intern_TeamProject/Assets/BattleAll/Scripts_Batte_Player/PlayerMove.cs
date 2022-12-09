using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private float InputHorizontal; //キーの横入力の値を格納する(-1~1)
    private float InputVertical; //キーの縦入力の値を格納する(-1~1)

    private float moveSpeed; //プレイヤーの移動速度
    [SerializeField]
    private float runSpeed; //小走りの速度
    [SerializeField]
    private float fastRunSpeed; //速い走りの速度
    [SerializeField]
    private float avokeSpeed;//回避スピード

    public Rigidbody rb;

    public GameObject Camera; //MainCameraを格納
    private Vector3 CameraForward; //カメラの正面を3次元座標で格納
    private Vector3 moveDirection; //プレイヤーが向く方向

    //剣のコライダー
    private Collider swordCollider;

    private PlayerStatus playerStatus;

    //回避状態
    private bool isAvoke;

    public AudioClip sound1;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentを用いてRigidbodyコンポーネントを取り出す(rbに格納)
        rb = this.gameObject.GetComponent<Rigidbody>();

        //GetComponentを用いてAnimatorコンポーネントを取り出す(animに格納)
        anim = GetComponent<Animator>();

        //剣のコライダーを取得
        swordCollider = GameObject.Find("clavicle_r").GetComponent<SphereCollider>();

        playerStatus = this.gameObject.GetComponent<PlayerStatus>();

        isAvoke = false;

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Bキーで回避の関数呼び出し
        if (Input.GetKeyDown(KeyCode.B) && !isAvoke && playerStatus.getCurrentStamina() > 30.0f)
        {
            anim.SetTrigger("AvokeTrigger"); //AnimatorのIsAvoke変数をtrueに設定
            playerStatus.reduceStamina(30.0f);
            AvoidMove();
        }

        Move();  //プレイヤーの移動
        Attack(); //プレイヤーの攻撃
    }


    void Move() //矢印キー入力からプレイヤーを移動(カメラの正面を基準に移動方向を確定)
    {
        /* 矢印キーとカメラの向きにより移動方向を決定し、予め設定したスピードで移動 */
        InputHorizontal = Input.GetAxis("Horizontal"); //横方向の矢印キーの入力を受け取る
        InputVertical = Input.GetAxis("Vertical"); //縦方向の矢印キーの入力を受け取る

        //回避中は方向固定
        if (!isAvoke)
        {
            CameraForward = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized; //カメラの正面
            moveDirection = Vector3.Normalize(CameraForward * InputVertical + Camera.transform.right * InputHorizontal); //カメラの正面を基準に矢印キーからプレイヤーの向きを確定
        }

        moveSpeed = runSpeed; //小走り


        /* 矢印キーの入力により通常走り(小走り)へアニメーションを遷移 */
        if (moveDirection != Vector3.zero) //向きに変更が加わっている時
        {
            this.transform.rotation = Quaternion.LookRotation(moveDirection); //プレイヤーの向きを変更
            anim.SetBool("IsRun", true); //AnimatorのIsRun変数をtrueに設定
        }
        else
        {
            anim.SetBool("IsRun", false); //AnimatorのIsRun変数をfalseに設定
        }


        /* 矢印キー長押しにより速い走りへアニメーションを遷移 */
        if (rb.velocity.magnitude > 0.9f) //矢印キーから受け取る値(押す時間が長いと1に近づく)が0.1より大きかったら
        {
            moveSpeed = fastRunSpeed; 
            anim.SetFloat("upgradeSpeed", rb.velocity.magnitude); //矢印キーから受け取る値をSpeedに設定する

            /**/
            audioSource.PlayOneShot(sound1);

        }
        else //矢印キーを押さなかったら/矢印キーから受け取る値が0.1より小さかったら
        {
            anim.SetFloat("upgradeSpeed", 0f); //矢印キーから受け取る値をSpeedに設定する
        }

        //回避中の移動速度増加
        if (isAvoke)
        {
            moveSpeed = avokeSpeed;
        }

        rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0); //向きとスピードを使ってプレイヤーを移動
    }


    void Attack() //数字キーの入力から攻撃アニメーションへ遷移
    {
        /* キーが押されたら攻撃をする */
        if (Input.GetKeyDown("1")) //番号キー1が押されたら
        {
            anim.SetBool("IsAttack1", true); //AnimatorのIsAttack1変数にtrueを設定

            //剣コライダーをオンにする
            swordCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.3f);
        }
        else if (Input.GetKeyDown("2")) //番号キー2が押されたら
        {
            anim.SetBool("IsAttack2", true);　//AnimatorのIsAttack2変数にtrueを設定

            //剣コライダーをオンにする
            swordCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.3f);

            //剣コライダーをオンにする
            swordCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.3f);
        }
        else if (Input.GetKeyDown("3")) //番号キー3が押されたら
        {
            anim.SetBool("IsAttack3", true);　//AnimatorのIsAttack3変数にtrueを設定

            //剣コライダーをオンにする
            swordCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.3f);
        }


        /* キーが離されたら攻撃を終える */
        if (Input.GetKeyUp("1")) //番号キー1が離されたら
        {
            anim.SetBool("IsAttack1", false); //AnimatorのIsAttack1変数にfalseを設定
        }
        else if (Input.GetKeyUp("2")) //番号キー2が離されたら
        {
            anim.SetBool("IsAttack2", false);　//AnimatorのIsAttack2変数にfalseを設定
        }
        else if (Input.GetKeyUp("3")) //番号キー3が離されたら
        {
            anim.SetBool("IsAttack3", false);　//AnimatorのIsAttack3変数にfalseを設定
        }
    }

    //剣についているコライダーをオフに(リセット)する
    private void ColliderReset()
    {
        swordCollider.enabled = false;
    }

    void AvoidMove() //Bキーの入力から回避アニメーションへ遷移
    {
        CancelInvoke(nameof(AvokeEnd));
        isAvoke = true;
        Invoke(nameof(AvokeEnd), 0.4f);
    }


    //invoke用関数
    private void AvokeEnd()
    {
        isAvoke = false;
    }
}
