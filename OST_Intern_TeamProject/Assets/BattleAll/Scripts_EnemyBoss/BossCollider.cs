using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    [SerializeField]
    private Collider Head;//1,3
    [SerializeField]
    private Collider LeftHand;//2
    [SerializeField]
    private Collider RightHand;//2
    [SerializeField]
    private Collider LeftLeg;//2
    [SerializeField]
    private Collider RightLeg;//2

    // Start is called before the first frame update
    void Start()
    {
        //ColliderReset();
    }

    // Update is called once per frame
    void Update()
    {/*
        switch (BossAttack.AttackVarsion)
        {
            case 1:// �P
                Atk1();
                break;
            case 2:// �Q
                Atk2();
                break;
            case 3://�R
                Atk3();
                break;
            default:
                ColliderReset();
                break;
        }
        */
    }

    /*
    void Atk1()
    {
        //���R���C�_�[���I���ɂ���
        Head.enabled = true;

        //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
        Invoke("ColliderReset", 0.3f);
    }

    void Atk2()
    {
        //���R���C�_�[���I���ɂ���
        Head.enabled = true;
        RightHand.enable = true;
        RightLeg.enable = true;
        LeftHand.enable = true;
        LeftLeg.enable = true;

        //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
        Invoke("ColliderReset", 0.3f);
    }

    void Atk3()
    {
        //���R���C�_�[���I���ɂ���
        Head.enabled = true;

        //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
        Invoke("ColliderReset", 0.3f);
    }

    //���ɂ��Ă���R���C�_�[���I�t��(���Z�b�g)����
    private void ColliderReset()
    {
        //���R���C�_�[���I���ɂ���
        Head.enabled = false;
        RightHand.enable = false;
        RightLeg.enable = false;
        LeftHand.enable = false;
        LeftLeg.enable = false;
    }
    */
}
