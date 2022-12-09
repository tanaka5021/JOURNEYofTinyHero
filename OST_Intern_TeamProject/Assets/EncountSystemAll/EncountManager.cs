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
    private int EncountValue; //�G���J�E���g����ɗp����A�C���X�y�N�^�������


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
            EncountPos = this.transform.position;

            Debug.Log(EncountPos);
            Debug.Log("Encount!");

            //�G���J�E���g�������Ƃɂ���
            IsEncount = true;

            //Field�L��
            RemainField.FieldNumber = 0;

            //Debug.Log(IsEncount);

            //�o�g���V�[����ǂݍ���
            SceneManager.LoadScene("BattleScean1");
        }
    }

}
