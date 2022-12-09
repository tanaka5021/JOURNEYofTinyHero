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
    private int EncountValue; //�G���J�E���g����ɗp����A�C���X�y�N�^�������


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
        //�V�[���ɂ���ăG���J�E���g���邩���Ȃ���
        if (SceneManager.GetActiveScene().name != "kari_main_kamijo") 
        {
            Encounter();
        }
       
    }

    void Encounter()
    {
        PlayerSpeed = rb.velocity.magnitude;
        
        if(PlayerSpeed > 2.0f) //�v���C���[���~�܂��Ă��Ȃ��Ƃ���������
        {
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }

        if(IsMove)
        {
            //�v���C���[�������Ă��鎞��
            Timer += Time.deltaTime;
            if (Timer >= TimeLimit && Timer <= TimeLimit + Time.deltaTime * 1.5)
            {
                //Debug.Log(Timer);
            }
            //���ԂɂȂ�����G���J�E���g
            else if(Timer >= TimeLimit)
            {
                EncountSystem();
            }
            
        }
    }

    //���Ԃ����ŃG���J�E���g���肵�Ă��悳����
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
