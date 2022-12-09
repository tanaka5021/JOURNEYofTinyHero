using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    //移動させたいプレイヤーのobj
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //エンカウントしていれば
        if(Encount.IsEncount)
        {
            //プレイヤーのスポーン位置を、エンカウントする前の位置に設定
            Player.transform.position = Encount.EncountPos;

            //Debug.Log(Encount.IsEncount);
            //エンカウントの経験を忘れる
            Encount.IsEncount = false;
            //Debug.Log(Encount.IsEncount);
        }
    }
}
