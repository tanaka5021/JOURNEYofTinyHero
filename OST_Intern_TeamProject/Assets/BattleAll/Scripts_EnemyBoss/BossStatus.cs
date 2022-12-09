using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    //　敵のMaxHP
    [SerializeField]
    private int maxHp = 300;

    //　敵のHP
    public int hp;

    //　敵の攻撃力
    public int attackPower = 10;

    [SerializeField]
    private BeatBoss beatBoss;

    //　HP表示用UI
    [SerializeField]
    private GameObject HPUI;

    //　HP表示用スライダー
    private Slider hpSlider;

    public GameObject Sword;

    [SerializeField]
    private Animator BossAnim;

    public GameObject Boss;
    int i = 3;



    void Start()
    {
        //マックスのHPをHPに表示する

        hp = maxHp;

        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;

        Sword = GameObject.Find("clavicle_r");
        beatBoss = Sword.GetComponent<BeatBoss>();

    }

    void Update()
    {
        //敵を攻撃したら
        if (beatBoss.isAttacked == true)
        {
            //設定した攻撃力をHPから減らす
            hp = hp - attackPower;
            StartCoroutine("BossHited");

            SetHp(hp);
            beatBoss.isAttacked = false;
        }
    }

    //HPを更新
    public void SetHp(int hp)
    {
        this.hp = hp;

        //　HP表示用UIのアップデート
        UpdateHPValue();

        if (hp <= 0)
        {
            BossAnim.SetBool("isDie", true);
            //　HP表示用UIを非表示にする
            HideStatusUI();

        }
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    //　死んだらHPUIを非表示にする
    public void HideStatusUI()
    {
        //コルーチンの呼び出し
        StartCoroutine("BossDeath");
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }

    IEnumerator BossDeath()
    {
        //anim
        BossAnim.SetBool("IsDie", true);

        yield return new WaitForSeconds(2.0f); //待つ時間

        FadeManager.Instance.LoadScene("GameClear", 0.5f);

        Boss.SetActive(false);
        HPUI.SetActive(false);
    }

    IEnumerator BossHited()
    {
        BossAnim.SetBool("IsHited", true);

        yield return new WaitForSeconds(0.5f); //待つ時間
        BossAnim.SetBool("IsHited", false);

    }

}
