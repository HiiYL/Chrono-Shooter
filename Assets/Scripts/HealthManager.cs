using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HealthManager : MonoBehaviour {

    public GameObject healthHUD;

    public int Health
    {
        get { return currentHealth; }
        set {
            if (value == 0)
            {
                // death!
                return;
            }

            hearts.ForEach(h => Destroy(h));
            hearts.Clear();

            // add hearts to HUD
            for (int i = 1; i <= value; i++)
            {
                GameObject heart = Instantiate(healthHUD, gameObject.transform);
                heart.transform.position = new Vector3(50*i, 50);
                hearts.Add(heart);
            }

            currentHealth = value;
        }
    }
    private List<GameObject> hearts;

    // for use in Unity editor only; do not change from code! Use Health instead
    public int currentHealth;

	// Use this for initialization
	void Start () {
        hearts = new List<GameObject>();
        Health = currentHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
