using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Lever : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool activated=false;
    [SerializeField] private int direction=0;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private GameObject activatingObject;
    private SpriteRenderer spriteRenderer;
    private bool isLeft = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Ball"))
        {
            StartCoroutine(ChangeActivation());
        }
    }
    IEnumerator ChangeActivation()
    {
        direction = (direction + 1) % 3;
        animator.SetInteger("direction", direction);
        if (direction == 1)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else
        {
            spriteRenderer.sprite = rightSprite;
        }
        activated = !activated;
        activatingObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
        yield return null;
        
    }
}
