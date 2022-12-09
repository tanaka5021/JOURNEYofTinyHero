using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class staminaBar : StatusViewer
{
    [SerializeField]
    private GameObject player;
    private PlayerStatus ps;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ps = player.GetComponent<PlayerStatus>();

        maxStatus = ps.getMaxStamina();
        currentStatus = ps.getCurrentStamina();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        currentStatus = ps.getCurrentStamina();
        base.FixedUpdate();
    }
}
