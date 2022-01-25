using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void Activate()
    {
        Debug.Log("activate door");
        isOpen = !isOpen;
        animator.SetBool("Open", isOpen);
        boxCollider2D.enabled = !boxCollider2D.enabled;
    }
}
