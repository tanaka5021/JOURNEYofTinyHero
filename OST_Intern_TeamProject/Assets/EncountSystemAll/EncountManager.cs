using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EncountManager : MonoBehaviour
{
    //Rigidbody
    public Rigidbody rb;

    //
    private float PlayerSpeed;

    //
    private int RateEncount;


    private float Timer = 0.0f;
    private float TimeLimit;

    public bool IsMove;

    public static bool IsEncount;
    public static Vector3 EncountPos = new Vector3(34, 0, 36);

    [SerializeField]
    private int EncountValue; //エンカウント判定に用いる、インスペクタから入力


    // Start is called before the first frame update
    void Start()
    {
        //rb = this.gameObject.GetComponent<Rigidbody>();
        IsMove = false;
        //IsEncount = false;
        //Debug.Log(IsEncount);
        TimeLimit = UnityEngine.Random.Range(3.0f, 5.0f);

        this.gameObject.transform.position = EncountPos;
    }

    // Update is called once per frame
    void Update()
    {
        //シーンによってエンカウントするかしないか
        //if(SceneManager.GetActiveScene().name != "kari_main_murakami")
        //{
        Encounter();
        //}

    }

    void Encounter()
    {
        PlayerSpeed = rb.velocity.magnitude;

        //プレイヤーが止まっていないとき乱数発生
        if (PlayerSpeed > 2.0f)
        {
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }

        //止まってないとき
        if (IsMove)
        {
            //プレイヤーが動いている時間を増加
            Timer += Time.deltaTime;

            ////もし
            ///動いてる時間が最初に決められた乱数以上
            ///且つ
            ///動いてる時間が最初に決められた時間に1.5増加した数以下
            /////なら
            if (Timer >= TimeLimit && Timer <= TimeLimit + Time.deltaTime * 1.5)
            {
                //Debug.Log(Timer);
            }
            //時間になったらエンカウント
            else if (Timer >= TimeLimit)
            {
                EncountSystem();
            }

        }
    }

    //時間だけでエンカウント判定してもよさそう
    void EncountSystem()
    {
        //エンか率はインスペクタで指定した数未満の乱数
        RateEncount = UnityEngine.Random.Range(0, EncountValue);

        //それが150なら
        if (RateEncount == 150)
        {
            //ポジションの獲得、代入
            EncountPos = this.transform.position;

            Debug.Log(EncountPos);
            Debug.Log("Encount!");

            //エンカウントしたことにする
            IsEncount = true;

            //Field記憶
            RemainField.FieldNumber = 0;

            //Debug.Log(IsEncount);

            //バトルシーンを読み込む
            SceneManager.LoadScene("BattleScean1");
        }
    }

}
