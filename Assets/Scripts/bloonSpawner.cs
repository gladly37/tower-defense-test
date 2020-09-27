using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloonSpawner : MonoBehaviour
{
    public GameObject bloon;
    public int healthOfBloon = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBloon;
            newBloon = Instantiate(bloon);
            bloonScript bloonScript;
            bloonScript = newBloon.GetComponent<bloonScript>();
            bloonScript.health = healthOfBloon;
            bloonScript.changeColorAndSize(healthOfBloon);
            if (healthOfBloon < 7)
            {
                healthOfBloon += 1;
            }
        }
    }
}
