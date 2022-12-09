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
            case 1:// １
                Atk1();
                break;
            case 2:// ２
                Atk2();
                break;
            case 3://３
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
        //剣コライダーをオンにする
        Head.enabled = true;

        //一定時間後にコライダーの機能をオフにする
        Invoke("ColliderReset", 0.3f);
    }

    void Atk2()
    {
        //剣コライダーをオンにする
        Head.enabled = true;
        RightHand.enable = true;
        RightLeg.enable = true;
        LeftHand.enable = true;
        LeftLeg.enable = true;

        //一定時間後にコライダーの機能をオフにする
        Invoke("ColliderReset", 0.3f);
    }

    void Atk3()
    {
        //剣コライダーをオンにする
        Head.enabled = true;

        //一定時間後にコライダーの機能をオフにする
        Invoke("ColliderReset", 0.3f);
    }

    //剣についているコライダーをオフに(リセット)する
    private void ColliderReset()
    {
        //剣コライダーをオンにする
        Head.enabled = false;
        RightHand.enable = false;
        RightLeg.enable = false;
        LeftHand.enable = false;
        LeftLeg.enable = false;
    }
    */
}
