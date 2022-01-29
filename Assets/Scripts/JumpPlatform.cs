using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumpPlatform : MonoBehaviour
{
    [SerializeField] private float bounceForce=3;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Ball"))
        {
            StartCoroutine(Jump(collision));
        }
    }
    IEnumerator Jump(Collision2D collision)
    {
        animator.SetBool("activation", true);
        collision.rigidbody.AddForce(bounceForce * transform.up * 100);
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("activation", false);
    }
}
