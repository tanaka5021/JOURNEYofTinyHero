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

        // NavMeshAgent��ێ����Ă���
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[��ڎw���Đi��
        navMeshAgent.destination = player.transform.position;
    }
}