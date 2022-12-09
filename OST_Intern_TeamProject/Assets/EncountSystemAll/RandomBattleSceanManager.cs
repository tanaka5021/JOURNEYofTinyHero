using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomBattleSceanManager : MonoBehaviour
{
    [SerializeField]
    private string[] SceanName;

    [SerializeField]
    private int SceanNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�G���J�E���g�����Ȃ�
        if (EncountManager.IsEncount)
        {
            //���Ԗڂ̃V�[���������_���őI��
            SceanNumber = Random.Range(0, SceanName.Length);

            //�����_���Ɍ��߂�ꂽ�V�[���ɑJ��
            SceneManager.LoadScene(SceanName[SceanNumber]);

        }

    }
}
