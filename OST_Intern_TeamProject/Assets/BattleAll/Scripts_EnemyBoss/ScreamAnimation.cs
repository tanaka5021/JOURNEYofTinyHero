using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Animator‚ÌInArea•Ï”‚ğtrue‚Éİ’è
            anim.SetBool("InArea", true); 
        }
    }
}
