using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�G���J�E���g���Ă����
        if(Encount.IsEncount)
        {
            //�v���C���[�̃X�|�[���ʒu���A�G���J�E���g����O�̈ʒu�ɐݒ�
            this.transform.position = Encount.EncountPos;

            //Debug.Log(Encount.IsEncount);
            
            //�G���J�E���g�̌o����Y���
            Encount.IsEncount = false;

            //Debug.Log(Encount.IsEncount);
        }
    }
}
