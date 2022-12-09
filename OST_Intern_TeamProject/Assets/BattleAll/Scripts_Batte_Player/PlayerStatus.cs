using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    //初期HP
    [SerializeField]
    private float maxHP;

    //初期スタミナ
    [SerializeField]
    private float maxStamina;

    //スタミナ自動回復量
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
        //スタミナ自動回復
        currentStamina += regenerationStamina;
        staminaCorrection();

    }

    //HP減少処理(負の値で回復可能)
    public void reduceHp(float hp)
    {
        currentHP -= hp;
        hpCorrection();
    }

    //スタミナ減少処理(負の値で回復可能)
    public void reduceStamina(float stamina)
    {
        currentStamina -= stamina;
        staminaCorrection();
    }

    private void hpCorrection()
    {        
        //異常な値をとらないように
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
        //異常な値をとらないように
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }


    //最大HP取得
    public float getMaxHP()
    {
        return maxHP;
    }


    //最大スタミナ取得
    public float getMaxStamina()
    {
        return maxStamina;
    }

    //現在HP取得
    public float getCurrentHP()
    {
        return currentHP;
    }

    //現在スタミナ取得
    public float getCurrentStamina()
    {
        return currentStamina;
    }

}
