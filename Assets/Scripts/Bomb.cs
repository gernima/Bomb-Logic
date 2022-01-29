using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask layerToHit;
    public GameObject explosionEffect;
    public float time=1f;
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
        StartCoroutine(Boom());
    }
    IEnumerator Boom()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);
        yield return new WaitForSeconds(time);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosionEffectIns, explosionEffectIns.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length ); 
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
