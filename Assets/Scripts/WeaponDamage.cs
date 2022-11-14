using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{

    public int damage;
    public GameObject bloodParticle;
    private GameObject hitPoint;

    // Start is called before the first frame update
    void Start()
    {
        hitPoint = transform.Find("Hit Point").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (bloodParticle != null && hitPoint != null)
            {
                Destroy( Instantiate(bloodParticle, hitPoint.transform.position,
                 hitPoint.transform.rotation),0.25f);
            }
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

        }
    }

}
