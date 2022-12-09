using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Mura : MonoBehaviour
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

    public Rigidbody rb;

    public GameObject Camera; //MainCameraを格納
    private Vector3 CameraForward; //カメラの正面を3次元座標で格納
    private Vector3 moveDirection; //プレイヤーが向く方向


    public AudioClip sound1;

    AudioSource audioSource;

    private bool canRang = true;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentを用いてRigidbodyコンポーネントを取り出す(rbに格納)
        rb = this.gameObject.GetComponent<Rigidbody>();

        //GetComponentを用いてAnimatorコンポーネントを取り出す(animに格納)
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();  //プレイヤーの移動

        //Attack(); //プレイヤーの攻撃

    }


    void Move() //矢印キー入力からプレイヤーを移動(カメラの正面を基準に移動方向を確定)
    {
        /* 矢印キーとカメラの向きにより移動方向を決定し、予め設定したスピードで移動 */
        InputHorizontal = Input.GetAxis("Horizontal"); //横方向の矢印キーの入力を受け取る
        InputVertical = Input.GetAxis("Vertical"); //縦方向の矢印キーの入力を受け取る

        CameraForward = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized; //カメラの正面
        moveDirection = CameraForward * InputVertical + Camera.transform.right * InputHorizontal; //カメラの正面を基準に矢印キーからプレイヤーの向きを確定



        /* 矢印キーの入力により通常走り(小走り)へアニメーションを遷移 */
        if (moveDirection != Vector3.zero) //向きに変更が加わっている時
        {
            this.transform.rotation = Quaternion.LookRotation(moveDirection); //プレイヤーの向きを変更
            moveSpeed = runSpeed; //小走り
            rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0); //向きとスピードを使ってプレイヤーを移動
            anim.SetBool("IsRun", true); //AnimatorのIsRun変数をtrueに設定

            if (canRang)
            {
                audioSource.PlayOneShot(sound1);
                //コルーチンの呼び出し
                StartCoroutine("WalkSpane");
            }
        }
        else
        {
            anim.SetBool("IsRun", false); //AnimatorのIsRun変数をfalseに設定
            audioSource.Stop();
            canRang = true;
        }


        /* 矢印キー長押しにより速い走りへアニメーションを遷移 */
        if (rb.velocity.magnitude > 1.9f) //矢印キーから受け取る値(押す時間が長いと1に近づく)が0.1より大きかったら
        {

            anim.SetBool("IsFastRun", true); //アニメーション遷移のフラグを立てる
            moveSpeed = fastRunSpeed;　//速い走り
            rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0); //速さの更新
            anim.SetFloat("upgradeSpeed", rb.velocity.magnitude); //矢印キーから受け取る値をSpeedに設定する
        }
        else //矢印キーを押さなかったら/矢印キーから受け取る値が0.1より小さかったら
        {
            anim.SetBool("IsFastRun", false);
            anim.SetFloat("upgradeSpeed", 0f); //矢印キーから受け取る値をSpeedに設定する
        }
    }

    //Aの後に2秒待ってBをする
    IEnumerator WalkSpane()
    {

        // 初めにしたいこと(A)
        canRang = false;

        yield return new WaitForSeconds(6.0f); //待つ時間

        // 数秒後にしたいこと(B)
        canRang = true;
    }




}
