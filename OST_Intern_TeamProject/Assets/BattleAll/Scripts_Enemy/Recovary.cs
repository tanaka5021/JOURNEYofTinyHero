using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovary : MonoBehaviour
{
    private GameObject[] item;

    public int itemNum;
    public GameObject items;


    public GameObject Window;

    public bool isNear;

    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.FindGameObjectsWithTag("item");
        itemNum = item.Length;
    }

    // Update is called once per frame
    void Update()
    {
        item = GameObject.FindGameObjectsWithTag("item");
        itemNum = item.Length;

        if (itemNum == 0)
        {
            Window.SetActive(false);
        }

        if(isNear){
            if (Input.GetKeyDown(KeyCode.E))
            {
                items.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Window.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        Window.SetActive(false);
    }
}
