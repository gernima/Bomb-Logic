using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Button : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool activated = false;
    [SerializeField] private GameObject activatingObject;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(CheckAndPressed(collision));
    }
    IEnumerator CheckAndPressed(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Ball"))
        {
            Pressed();
            yield return new WaitForSeconds(1.5f);
            Pressed();
        }
    }
    void Pressed()
    {
        activated = !activated;
        animator.SetBool("Pressed", activated);
        activatingObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
    }
}
