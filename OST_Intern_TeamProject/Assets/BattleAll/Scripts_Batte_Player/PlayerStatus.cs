using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    //����HP
    [SerializeField]
    private float maxHP;

    //�����X�^�~�i
    [SerializeField]
    private float maxStamina;

    //�X�^�~�i�����񕜗�
    [SerializeField]
    public float regenerationStamina;

    private float currentHP;
    private float currentStamina;

    private void Start()
    {
        currentHP = maxHP;
        currentStamina = maxStamina;
    }

    private void FixedUpdate()
    {
        //�X�^�~�i������
        currentStamina += regenerationStamina;
        staminaCorrection();

    }

    //HP��������(���̒l�ŉ񕜉\)
    public void reduceHp(float hp)
    {
        currentHP -= hp;
        hpCorrection();
    }

    //�X�^�~�i��������(���̒l�ŉ񕜉\)
    public void reduceStamina(float stamina)
    {
        currentStamina -= stamina;
        staminaCorrection();
    }

    private void hpCorrection()
    {        
        //�ُ�Ȓl���Ƃ�Ȃ��悤��
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        else if (currentHP <= 0)
        {
            currentHP = 0;

        }
    }

    private void staminaCorrection()
    {        
        //�ُ�Ȓl���Ƃ�Ȃ��悤��
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }


    //�ő�HP�擾
    public float getMaxHP()
    {
        return maxHP;
    }


    //�ő�X�^�~�i�擾
    public float getMaxStamina()
    {
        return maxStamina;
    }

    //����HP�擾
    public float getCurrentHP()
    {
        return currentHP;
    }

    //���݃X�^�~�i�擾
    public float getCurrentStamina()
    {
        return currentStamina;
    }

}
