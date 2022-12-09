using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Encount : MonoBehaviour
{
    public Rigidbody rb;
    private float PlayerSpeed;
    private int RateEncount;
    private float Timer = 0.0f;
    private float TimeLimit;
    public bool IsMove;
    public static bool IsEncount;
    public static Vector3 EncountPos;
    public Fade fade;
    
    [SerializeField]
    private int EncountValue; //エンカウント判定に用いる、インスペクタから入力


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        IsMove = false;
        //IsEncount = false;
        Debug.Log(IsEncount);
        TimeLimit = UnityEngine.Random.Range(7.5f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //シーンによってエンカウントするかしないか
        if (SceneManager.GetActiveScene().name != "kari_main_kamijo") 
        {
            Encounter();
        }
       
    }

    void Encounter()
    {
        PlayerSpeed = rb.velocity.magnitude;
        
        if(PlayerSpeed > 2.0f) //プレイヤーが止まっていないとき乱数発生
        {
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }

        if(IsMove)
        {
            //プレイヤーが動いている時間
            Timer += Time.deltaTime;
            if (Timer >= TimeLimit && Timer <= TimeLimit + Time.deltaTime * 1.5)
            {
                //Debug.Log(Timer);
            }
            //時間になったらエンカウント
            else if(Timer >= TimeLimit)
            {
                EncountSystem();
            }
            
        }
    }

    //時間だけでエンカウント判定してもよさそう
    void EncountSystem()
    {
        RateEncount = UnityEngine.Random.Range(0, EncountValue);
        
        if(RateEncount == 150)
        {
            Debug.Log("Encount!");
            IsEncount = true;
            Debug.Log(IsEncount);
            fade.FadeIn(1f, () =>
            {
                SceneManager.LoadScene("kari_battle");
            });
            EncountPos = this.transform.position;
            Debug.Log(EncountPos);
        }
    }

}
