using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextStage : MonoBehaviour
{

    [SerializeField]
    string NextStage;
    Transform PlayerTransform;

    public Fade fade;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        SceneManager.LoadScene("map1");

    }
}
