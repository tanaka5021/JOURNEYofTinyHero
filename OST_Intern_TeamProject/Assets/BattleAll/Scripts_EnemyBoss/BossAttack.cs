using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //�G�̃A�j���[�V�����i�[
    [SerializeField]
    private Animator anim;

    //�U���̎��
    private int AttackNumber = 0;
    public static int AttackVarsion;

    //�G�̃��W�b�h�{�f�B
    [SerializeField]
    private Rigidbody rb;

    //�v���C���[���߂��ɂ��邩�ǂ����̔���
    private bool isNearPlayer;

    [SerializeField]
    private GameObject Enemy;

    private Vector3 Position;


    // Start is called before the first frame update
    void Start()
    {
        //GetComponent��p����Rigidbody�R���|�[�l���g�����o��(rb�Ɋi�[)
        rb = Enemy.gameObject.GetComponent<Rigidbody>();

        //GetComponent��p����Animator�R���|�[�l���g�����o��(anim�Ɋi�[)
        anim = Enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearPlayer)
        {
            Debug.Log(AttackNumber);

            switch (AttackNumber)
            {
                case 1:// �����P
                    anim.SetBool("IsAttack1", true); //Animator��IsRun�ϐ���true�ɐݒ�
                    AttackVarsion = 1;
                    break;
                case 2:// �����Q
                    anim.SetBool("IsAttack2", true); //Animator��IsRun�ϐ���true�ɐݒ�
                    AttackVarsion = 2;
                    break;
                case 3://�����R
                    anim.SetBool("IsAttack3", true);
                    AttackVarsion = 3;
                    break;
                default:
                    AttackVarsion = 0;
                    break;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearPlayer = true;

            AttackNumber = Random.Range(1, 4);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearPlayer = false;

            Reset();
        }
    }

    void Reset()
    {
        anim.SetBool("IsAttack1", false); //Animator��IsRun�ϐ���true�ɐݒ�
        anim.SetBool("IsAttack2", false); //Animator��IsRun�ϐ���true�ɐݒ�
        anim.SetBool("IsAttack3", false); //Animator��IsRun�ϐ���true�ɐݒ�


        AttackNumber = 0;

        isNearPlayer = false;
    }

    //A�̌��2�b�҂���B������
    IEnumerator BossAnimation()
    {

        // ���߂ɂ���������(A)

        yield return new WaitForSeconds(1.0f); //�҂���

        // ���b��ɂ���������(B)
        Reset();

    }
}
