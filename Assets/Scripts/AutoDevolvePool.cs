using UnityEngine;
using System.Collections;

public class AutoDevolvePool : MonoBehaviour
{
    public int cullRange = 5;

    private ObjectPooling pooling;
    private GameObject player;

    void Start()
    {
        pooling = GameObject.FindGameObjectWithTag("ObstaclePool").GetComponent<ObjectPooling>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (((player.transform.position.z - transform.position.z) > cullRange) ||
            (Mathf.Abs(player.transform.position.x - transform.position.x) > 30) ||
            (Mathf.Abs(player.transform.position.y - transform.position.y) > 30))
        {
            pooling.DevolveInstance(gameObject);
        }
    }
}
