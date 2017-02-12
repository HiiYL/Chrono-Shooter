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

	public int bulletPoolSize = 100;



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
					pool[i] = (GameObject)Instantiate(obstacle.gameObj, obstacle.gameObj.transform.position,
                        obstacle.gameObj.transform.rotation);
                    pool[i].transform.parent = transform;
                    pool[i].SetActive(false);
                    break;
                }
            }
        }
		bulletPool = new GameObject[bulletPoolSize];
		for (int i = 0; i < bulletPoolSize; i++)
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
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }
		print ("ran out of objects");
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
		if (go.GetComponent<TrailRenderer>())
		{
			go.GetComponent<TrailRenderer>().Clear();
		}
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;
        go.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        go.SetActive(false);
    }
}