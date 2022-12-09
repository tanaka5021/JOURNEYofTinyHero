using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    //�G�̃A�j���[�V�����i�[
    [SerializeField]
    private Animator anim;

    //�U���̎��
    private int AttackNumber = 0;

    //�G�̃��W�b�h�{�f�B
    [SerializeField]
    private Rigidbody rb;

    //�v���C���[���߂��ɂ��邩�ǂ����̔���
    private bool isNearPlayer;

    [SerializeField]
    private GameObject Enemy;

    private Vector3 Position;

    public static bool nowAttacked;

    public AudioClip sound1;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

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
                    anim.SetBool("isAttack1", true); //Animator��IsRun�ϐ���true�ɐݒ�
                    nowAttacked = true;
                    break;
                case 2:// �����Q
                    anim.SetBool("isAttack2", true); //Animator��IsRun�ϐ���true�ɐݒ�
                    nowAttacked = true;
                    break;
                default:
                    break;
            }



        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(sound1);

            isNearPlayer = true;

            anim.SetBool("inArea", isNearPlayer);

            AttackNumber = Random.Range(1, 3);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearPlayer = false;

            anim.SetBool("inArea", isNearPlayer);
            Reset();
        }
    }

    void Reset()
    {
        anim.SetBool("isAttack1", false); //Animator��IsRun�ϐ���true�ɐݒ�
        anim.SetBool("isAttack2", false); //Animator��IsRun�ϐ���true�ɐݒ�


        AttackNumber = 0;

        isNearPlayer = false;
    }
}
