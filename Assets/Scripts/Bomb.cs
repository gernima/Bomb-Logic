using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask layerToHit;
    public GameObject explosionEffect;
    void Start()
    {
        GlobalEvents.activatingItems.AddListener(Activate);
    }
    private void OnDestroy()
    {
        GlobalEvents.activatingItems.RemoveListener(Activate);
    }
    void Activate()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);

        foreach(Collider2D obj in objects){
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        //GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //Destroy(explosionEffectIns);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
