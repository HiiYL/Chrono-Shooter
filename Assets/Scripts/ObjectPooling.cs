using UnityEngine;
using System.Collections;

[System.Serializable]
public struct SpawnableObject
{
    public int spawnWeight;
    public GameObject gameObj;
}
public class ObjectPooling : MonoBehaviour
{
    public SpawnableObject[] obstacles;
    public GameObject bullet;
    public int poolSize;



    private GameObject[] pool;
    private GameObject[] bulletPool;
    private int totalWeights = 0;

    void Start()
    {

        foreach (SpawnableObject obstacle in obstacles)
        {
            totalWeights += obstacle.spawnWeight;
        }

        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            int selectedIdx = Random.Range(0, totalWeights);
            foreach (SpawnableObject obstacle in obstacles)
            {
                selectedIdx -= obstacle.spawnWeight;
                //print(selectedIdx);
                if (selectedIdx <= 1)
                {
                    pool[i] = (GameObject)Instantiate(obstacle.gameObj, transform.position,
                        obstacle.gameObj.transform.rotation);
                    pool[i].transform.parent = transform;
                    pool[i].SetActive(false);
                    break;
                }
            }
        }
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bulletPool[i] = (GameObject)Instantiate(bullet, transform.position, bullet.transform.rotation);
            bulletPool[i].transform.parent = transform;
            bulletPool[i].SetActive(false);
        }
    }

    public GameObject RetrieveInstance()
    {
        //print(pool.Length);
        foreach (GameObject go in pool)
        {
            if (go != null && !go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }

        return null;
    }
    public GameObject RetrieveBulletInstance()
    {
        foreach (GameObject go in bulletPool)
        {
            if (go != null && !go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }

        return null;

    }

    public void DevolveInstance(GameObject go)
    {
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;
        go.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        go.SetActive(false);
    }
}