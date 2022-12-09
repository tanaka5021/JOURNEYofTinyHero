using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private AudioSource audioSourceSE;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSourceSE = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

    }
}

