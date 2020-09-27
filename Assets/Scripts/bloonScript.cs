using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class bloonScript : MonoBehaviour
{
    public PathCreator path;
    public Material thisColor;
    public Color pinkColor;
    public int health = 10;
    public float speed = 1;
    public float distanceOnPath;
    // Start is called before the first frame update
    void Awake()
    {
        path = GameObject.Find("Path").GetComponent<PathCreator>();
        thisColor = GetComponent<Renderer>().material;
        changeColorAndSize(health);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = path.path.GetPointAtDistance(distanceOnPath, EndOfPathInstruction.Stop);
        distanceOnPath += speed * Time.deltaTime;
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        changeColorAndSize(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void changeColorAndSize(int currentHealth)
    {
        switch (currentHealth)
        {
            default:
                thisColor.color = Color.red;
                Debug.Log("red");
                break;
            case 1:
                thisColor.color = Color.red;
                Debug.Log("red");
                break;
            case 2:
                thisColor.color = Color.blue;
                Debug.Log("blue");
                break;
            case 3:
                thisColor.color = Color.green;
                Debug.Log("green");
                break;
            case 4:
                thisColor.color = Color.yellow;
                Debug.Log("yellow");
                break;
            case 5:
                thisColor.color = pinkColor;
                Debug.Log("pink");
                break;
            case 6:
                thisColor.color = Color.black;
                break;
            case 7:
                thisColor.color = Color.white;
                break;
        }

        this.transform.localScale = new Vector3(1f + (float)currentHealth / 10, 1f + (float)currentHealth / 10, 1f + (float)currentHealth / 10);
    }
}
