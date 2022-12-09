using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator anim;


    public AudioClip sound1;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Animator��IsSleep�ϐ���false�ɐݒ�
            anim.SetBool("IsSleep", false);
            audioSource.PlayOneShot(sound1);


        }
    }
}
