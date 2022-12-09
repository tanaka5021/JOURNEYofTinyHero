using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    ///�v���C���[�̐��܂�錴�_
    [SerializeField]
    private Vector3 FirstPlayerSpawnPoint;

    //�����G���A�̔��a
    [SerializeField]
    private int AreaRadius;

    /*
    //���������G�̃I�u�W�F�N�g
    [SerializeField]
    private GameObject Enemy;
    */

    //�������ꂽ�G�̈ʒu
    private Vector3 RandomEnemyPosition;

    //���������G�̐�
    [SerializeField]
    private int EnemyNumber;

    //�G�̃I�u�W�F�N�g�̔z��
    public GameObject[] Enemies = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        //�����������G�̐���
        for (int i = 0; i < EnemyNumber; i++)
        {
            //��������G���A���ɐ��������܂�
            while (InArea(FirstPlayerSpawnPoint, RandomEnemyPosition))
            {
                //���W���X�V����
                MakeRandomCoordinate();

                Debug.Log("�C���X�^���X�̐���");
            }

            //���܂����ʒu�ɐ�������
            //GameObject enemy = Instantiate(Enemy, RandomEnemyPosition, Quaternion.identity);
            
            if (i == 0)
            {
                Enemies[i].transform.position = RandomEnemyPosition;
                //Enemies[i].transform.position.y = -2f;

            }
            else if (i == 1)
            {
                Enemies[i].transform.position = RandomEnemyPosition;
            }
            else if (i == 2)
            {
                Enemies[i].transform.position = RandomEnemyPosition;
            }


            //���������ʒu�����Z�b�g
            RandomEnemyPosition = Vector3.zero;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�G�̈ʒu�������_���Ō��߂邽�߂̊֐�
    void MakeRandomCoordinate()
    {
        //x,z���W�̊m��
        int RandomX = Random.Range(AreaRadius * -2, AreaRadius);
        int RandomZ = Random.Range(AreaRadius * -2, AreaRadius);

        //�ʒu�̂��Ă͂�
        RandomEnemyPosition = new Vector3(RandomX, -2f, RandomZ);
    }

    //�����_���Ɍ��߂�ꂽ�G�̈ʒu���G�����܂�Ă����G���A�����ǂ����̔�������邽�߂̊֐�
    bool InArea(Vector3 PlayerPosition, Vector3 EnemyPosition)
    {
        //�O�̂��߂�Debug
        //Debug.Log(Vector3.Distance(PlayerPosition, EnemyPosition));

        //�����_���Ɍ��߂�ꂽ�ʒu�ƃv���C���[�̐��܂�錴�_�Ƃ̋��������a�����傫�����
        if (Vector3.Distance(PlayerPosition, EnemyPosition) > (float)AreaRadius)
        {
            //false ��Ԃ�
            return false;
        }
        else
        {
            //�����łȂ����true��Ԃ�
            return true;
        }
    }
}
