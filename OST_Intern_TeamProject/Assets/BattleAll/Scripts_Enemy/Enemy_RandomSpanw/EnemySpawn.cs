using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    ///プレイヤーの生まれる原点
    [SerializeField]
    private Vector3 FirstPlayerSpawnPoint;

    //作られるエリアの半径
    [SerializeField]
    private int AreaRadius;

    /*
    //生成される敵のオブジェクト
    [SerializeField]
    private GameObject Enemy;
    */

    //生成された敵の位置
    private Vector3 RandomEnemyPosition;

    //生成される敵の数
    [SerializeField]
    private int EnemyNumber;

    //敵のオブジェクトの配列
    public GameObject[] Enemies = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        //生成したい敵の数分
        for (int i = 0; i < EnemyNumber; i++)
        {
            //しっかりエリア内に生成されるまで
            while (InArea(FirstPlayerSpawnPoint, RandomEnemyPosition))
            {
                //座標を更新する
                MakeRandomCoordinate();

                Debug.Log("インスタンスの生成");
            }

            //決まった位置に生成する
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


            //生成される位置をリセット
            RandomEnemyPosition = Vector3.zero;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //敵の位置をランダムで決めるための関数
    void MakeRandomCoordinate()
    {
        //x,z座標の確定
        int RandomX = Random.Range(AreaRadius * -2, AreaRadius);
        int RandomZ = Random.Range(AreaRadius * -2, AreaRadius);

        //位置のあてはめ
        RandomEnemyPosition = new Vector3(RandomX, -2f, RandomZ);
    }

    //ランダムに決められた敵の位置が敵が生まれていいエリア内かどうかの判定をするための関数
    bool InArea(Vector3 PlayerPosition, Vector3 EnemyPosition)
    {
        //念のためのDebug
        //Debug.Log(Vector3.Distance(PlayerPosition, EnemyPosition));

        //ランダムに決められた位置とプレイヤーの生まれる原点との距離が半径よりも大きければ
        if (Vector3.Distance(PlayerPosition, EnemyPosition) > (float)AreaRadius)
        {
            //false を返す
            return false;
        }
        else
        {
            //そうでなければtrueを返す
            return true;
        }
    }
}
