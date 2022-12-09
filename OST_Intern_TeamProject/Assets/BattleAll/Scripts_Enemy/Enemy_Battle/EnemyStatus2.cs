using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus2 : MonoBehaviour
{
    //　敵のMaxHP
    [SerializeField]
    private int maxHp = 100;

    //　敵のHP
    public int hp1;
    public int hp2;
    public int hp3;

    //　敵の攻撃力
    public int attackPower = 10;
    [SerializeField]
    private BeatEnemy2 beatEnemy2;

    //　HP表示用UI
    [SerializeField]
    private GameObject HPUI1;
    [SerializeField]
    private GameObject HPUI2;
    [SerializeField]
    private GameObject HPUI3;

    //　HP表示用スライダー
    private Slider hpSlider1;
    private Slider hpSlider2;
    private Slider hpSlider3;

    public GameObject Sword;

    [SerializeField]
    private Animator EnemyAnim1;
    [SerializeField]
    private Animator EnemyAnim2;
    [SerializeField]
    private Animator EnemyAnim3;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public static bool nowHited1;
    public static bool nowHited2;
    public static bool nowHited3;

    void Start()
    {
        //マックスのHPをHPに表示する

        hp1 = maxHp;
        hp2 = maxHp;
        hp3 = maxHp;

        hpSlider1 = HPUI1.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider1.value = 1f;
        hpSlider2 = HPUI2.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider2.value = 1f;
        hpSlider3 = HPUI3.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider3.value = 1f;

        Sword = GameObject.Find("clavicle_r");
        beatEnemy2 = Sword.GetComponent<BeatEnemy2>();

    }

    void Update()
    {
        //敵を攻撃したら
        if (beatEnemy2.isAttacked1 == true)
        {
            //設定した攻撃力をHPから減らす
            hp1 = hp1 - attackPower;
            StartCoroutine("EnemyHited1");

            SetHp1(hp1);
            beatEnemy2.isAttacked1 = false;
        }

        if (beatEnemy2.isAttacked2 == true)
        {
            //設定した攻撃力をHPから減らす
            hp2 = hp2 - attackPower;
            StartCoroutine("EnemyHited2");

            SetHp2(hp2);
            beatEnemy2.isAttacked2 = false;
        }

        if (beatEnemy2.isAttacked3 == true)
        {
            //設定した攻撃力をHPから減らす
            hp3 = hp3 - attackPower;
            StartCoroutine("EnemyHited3");

            SetHp3(hp3);
            beatEnemy2.isAttacked3 = false;
        }
    }

    //HPを更新
    public void SetHp1(int hp1)
    {
        this.hp1 = hp1;

        //　HP表示用UIのアップデート
        UpdateHPValue1();

        if (hp1 <= 0)
        {
            EnemyAnim1.SetBool("isDeath", true);
            //　HP表示用UIを非表示にする
            HideStatusUI1();

        }
    }

    //HPを更新
    public void SetHp2(int hp2)
    {
        this.hp2 = hp2;

        //　HP表示用UIのアップデート
        UpdateHPValue2();

        if (hp2 <= 0)
        {
            EnemyAnim2.SetBool("isDeath", true);

            //　HP表示用UIを非表示にする
            HideStatusUI2();
        }
    }

    //HPを更新
    public void SetHp3(int hp3)
    {
        this.hp3 = hp3;

        //　HP表示用UIのアップデート
        UpdateHPValue3();

        if (hp3 <= 0)
        {
            EnemyAnim3.SetBool("isDeath", true);

            //　HP表示用UIを非表示にする
            HideStatusUI3();
        }
    }

    public int GetHp1()
    {
        return hp1;
    }

    public int GetHp2()
    {
        return hp2;
    }

    public int GetHp3()
    {
        return hp3;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    //　死んだらHPUIを非表示にする
    public void HideStatusUI1()
    {
        //コルーチンの呼び出し
        StartCoroutine("EnemyDeath1");
    }

    public void HideStatusUI2()
    {

        //コルーチンの呼び出し
        StartCoroutine("EnemyDeath2");
    }

    public void HideStatusUI3()
    {
        //コルーチンの呼び出し
        StartCoroutine("EnemyDeath3");
    }


    public void UpdateHPValue1()
    {
        hpSlider1.value = (float)GetHp1() / (float)GetMaxHp();
    }

    public void UpdateHPValue2()
    {
        hpSlider2.value = (float)GetHp2() / (float)GetMaxHp();
    }

    public void UpdateHPValue3()
    {
        hpSlider3.value = (float)GetHp3() / (float)GetMaxHp();
    }

    IEnumerator EnemyDeath1()
    {
        yield return new WaitForSeconds(2.0f); //待つ時間
        Enemy1.SetActive(false);
        HPUI1.SetActive(false);
    }

    IEnumerator EnemyDeath2()
    {
        yield return new WaitForSeconds(2.0f); //待つ時間
        Enemy2.SetActive(false);
        HPUI2.SetActive(false);
    }

    IEnumerator EnemyDeath3()
    {
        yield return new WaitForSeconds(2.0f); //待つ時間
        Enemy3.SetActive(false);
        HPUI3.SetActive(false);
    }

    IEnumerator EnemyHited1()
    {
        EnemyAnim1.SetBool("isHited", true);
        nowHited1 = true;

        yield return new WaitForSeconds(1.0f); //待つ時間
        EnemyAnim1.SetBool("isHited", false);
        nowHited1 = false;
    }

    IEnumerator EnemyHited2()
    {
        EnemyAnim2.SetBool("isHited", true);
        nowHited2 = true;

        yield return new WaitForSeconds(1.0f); //待つ時間
        EnemyAnim2.SetBool("isHited", false);
        nowHited2 = false;

    }

    IEnumerator EnemyHited3()
    {
        EnemyAnim3.SetBool("isHited", true);
        nowHited3 = true;

        yield return new WaitForSeconds(1.0f); //待つ時間
        EnemyAnim3.SetBool("isHited", false);
        nowHited3 = false;

    }
}
