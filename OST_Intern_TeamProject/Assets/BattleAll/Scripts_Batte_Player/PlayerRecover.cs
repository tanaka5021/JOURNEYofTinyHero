using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecover : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public GameObject recovery;
    private bool IsRecoverApproach;

    [SerializeField]
    private GameObject KeyGuide;

    public AudioClip sound1;
    AudioSource audioSource;

    private PlayerStatus ps;

    // Start is called before the first frame update
    void Start()
    {

        KeyGuide.SetActive(false); //始めはキーガイドのポップアップを非表示にしておく

        audioSource = GetComponent<AudioSource>();

        ps = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        //近づいたら
        if (IsRecoverApproach)
        {
            KeyGuide.SetActive(true); //キーガイドのポップアップを表示

            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("IsRecovery", true); //AnimatorのIsRecovery変数にtrueを設定

                //音を鳴らす
                //audioSource.PlayOneShot(sound1);

                //HPを回復
                ps.reduceHp(-100.0f);
                ps.reduceStamina(-100.0f);

                recovery.SetActive(false);
                IsRecoverApproach = false;
            }
        }
        else
        {
            KeyGuide.SetActive(false); //キーガイドのポップアップを非表示

            anim.SetBool("IsRecovery", false); //AnimatorのIsRecovery変数にfalseを設定
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Approach"))
        {
            IsRecoverApproach = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Approach"))
        {
            IsRecoverApproach = false;
        }
    }
}
