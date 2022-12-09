using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //エンカウントしていれば
        if(Encount.IsEncount)
        {
            //プレイヤーのスポーン位置を、エンカウントする前の位置に設定
            this.transform.position = Encount.EncountPos;

            //Debug.Log(Encount.IsEncount);
            
            //エンカウントの経験を忘れる
            Encount.IsEncount = false;

            //Debug.Log(Encount.IsEncount);
        }
    }
}
