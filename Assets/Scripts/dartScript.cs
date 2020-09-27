using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartScript : MonoBehaviour
{
    public float velocity;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bloon"))
        {
            other.GetComponentInParent<bloonScript>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
