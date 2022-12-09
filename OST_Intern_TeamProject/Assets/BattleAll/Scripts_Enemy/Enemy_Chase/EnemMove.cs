using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemMove : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        // NavMeshAgentを保持しておく
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーを目指して進む
        navMeshAgent.destination = player.transform.position;
    }
}