using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawner : MonoBehaviour
{
    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 location = new Vector3();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray,out raycastHit))
            {
                location = raycastHit.point;
                location = new Vector3(location.x, 0, location.z);
            }

            Instantiate(tower, location , Quaternion.identity);
        }
    }
}
