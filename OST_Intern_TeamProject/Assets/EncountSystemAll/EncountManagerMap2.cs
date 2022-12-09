using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EncountManagerMap2 : MonoBehaviour
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
    public static Vector3 EncountPosMap2 = new Vector3(7f, 0.31f, 7f);

    [SerializeField]
    private int EncountValue; //�G���J�E���g����ɗp����A�C���X�y�N�^�������

    public Fade fade;



    // Start is called before the first frame update
    void Start()
    {
        //rb = this.gameObject.GetComponent<Rigidbody>();
        IsMove = false;
        //IsEncount = false;
        //Debug.Log(IsEncount);
        TimeLimit = UnityEngine.Random.Range(7.5f, 10.0f);

        this.gameObject.transform.position = EncountPosMap2;
    }

    // Update is called once per frame
    void Update()
    {
        //�V�[���ɂ���ăG���J�E���g���邩���Ȃ���
        //if(SceneManager.GetActiveScene().name != "kari_main_murakami")
        //{
        Encounter();
        //}

    }

    void Encounter()
    {
        PlayerSpeed = rb.velocity.magnitude;

        //�v���C���[���~�܂��Ă��Ȃ��Ƃ���������
        if (PlayerSpeed > 2.0f)
        {
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }

        //�~�܂��ĂȂ��Ƃ�
        if (IsMove)
        {
            //�v���C���[�������Ă��鎞�Ԃ𑝉�
            Timer += Time.deltaTime;

            ////����
            ///�����Ă鎞�Ԃ��ŏ��Ɍ��߂�ꂽ�����ȏ�
            ///����
            ///�����Ă鎞�Ԃ��ŏ��Ɍ��߂�ꂽ���Ԃ�1.5�����������ȉ�
            /////�Ȃ�
            if (Timer >= TimeLimit && Timer <= TimeLimit + Time.deltaTime * 1.5)
            {
                //Debug.Log(Timer);
            }
            //���ԂɂȂ�����G���J�E���g
            else if (Timer >= TimeLimit)
            {
                EncountSystem();
            }

        }
    }

    //���Ԃ����ŃG���J�E���g���肵�Ă��悳����
    void EncountSystem()
    {
        //�G�������̓C���X�y�N�^�Ŏw�肵���������̗���
        RateEncount = UnityEngine.Random.Range(0, EncountValue);

        //���ꂪ150�Ȃ�
        if (RateEncount == 150)
        {
            //�|�W�V�����̊l���A���
            EncountPosMap2 = this.transform.position;

            Debug.Log(EncountPosMap2);
            Debug.Log("Encount!");

            //�G���J�E���g�������Ƃɂ���
            IsEncount = true;

            //Field�L��
            RemainField.FieldNumber = 2;

            //Debug.Log(IsEncount);

            //�o�g���V�[����ǂݍ���

            fade.FadeIn(1f, () =>
            {
                SceneManager.LoadScene("BattleScean2");
            });
        }
    }

}