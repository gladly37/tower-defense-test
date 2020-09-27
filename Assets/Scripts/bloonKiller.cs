using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloonKiller : MonoBehaviour
{
    public float rateOfFire = 1;
    public float shootPower = 5;
    public float range = 5f;
    public int damage = 1;
    public float cooldownTimer;
    public float cooldown = 1;
    public GameObject target;
    public GameObject dartPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask bloonMask = LayerMask.GetMask("bloonLayer");
        Collider[] bloonsInRangeCol = Physics.OverlapSphere(transform.position, range, bloonMask);
        List<bloonScript> bloonsInRangeList = new List<bloonScript>(); 
        for (int i = 0; i < bloonsInRangeCol.Length; i++)
        {
            bloonsInRangeList.Add(bloonsInRangeCol[i].gameObject.GetComponent<bloonScript>());
        }
        bloonScript[] bloonsInRange = bloonsInRangeList.ToArray();
        target = null;
        for (int i = 0; i < bloonsInRange.Length; i++)
        {
            if(i == 0)
            {
                target = bloonsInRange[0].gameObject;
            }
            else
            {
                if (bloonsInRange[i].distanceOnPath > target.GetComponent<bloonScript>().distanceOnPath)
                {
                    target = bloonsInRange[i].gameObject;
                }
            }
        }

        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y);

            if (cooldownTimer <= 0)
            {
                shootAtTarget();
                cooldownTimer = cooldown;
            }
        }

        cooldownTimer -= Time.deltaTime;

        try
        {
            Debug.DrawLine(transform.position, target.transform.position, Color.red);
        }
        catch { };
    }

    public void shootAtTarget()
    {
        GameObject dart;
        dart = Instantiate(dartPrefab,transform.position, transform.rotation);
        dartScript dartScript = dart.GetComponent<dartScript>();
        dartScript.velocity = shootPower;
        dartScript.lifetime = shootPower / 10;
        dartScript.damage = damage;
    }
}
