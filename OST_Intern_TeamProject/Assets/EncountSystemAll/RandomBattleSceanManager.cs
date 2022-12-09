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
        //エンカウントしたなら
        if (EncountManager.IsEncount)
        {
            //何番目のシーンかランダムで選択
            SceanNumber = Random.Range(0, SceanName.Length);

            //ランダムに決められたシーンに遷移
            SceneManager.LoadScene(SceanName[SceanNumber]);

        }

    }
}
