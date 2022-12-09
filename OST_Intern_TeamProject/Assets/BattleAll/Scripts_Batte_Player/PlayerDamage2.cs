using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage2 : MonoBehaviour
{
    [SerializeField]
    private GameObject damageEffect;

    [SerializeField]
    private AudioClip soundDamage;

    private AudioSource audioSource;

    private PlayerStatus ps;
    private PlayerDefeat pd;

    private void Start()
    {
        ps = this.gameObject.GetComponent<PlayerStatus>();
        pd = this.gameObject.GetComponent<PlayerDefeat>();

        audioSource = this.gameObject.GetComponent<AudioSource>();
        damageEffect.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ps.getCurrentHP() <= 0)
        {
            pd.playerDefeated();
        }
    }

    //�G�ڐG��
    //TODO ��ōU�����ɒ����H
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            audioSource.PlayOneShot(soundDamage);
            damageEffect.SetActive(true);
            Invoke(nameof(eraseEffect), 0.3f);
            ps.reduceHp(10.0f);

        }
    }


    //�G�t�F�N�g������
    private void eraseEffect()
    {
        damageEffect.SetActive(false);
    }
}
