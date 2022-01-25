using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Activator : MonoBehaviour
{
    public Sprite deactivatedSprite;
    public Sprite activatedSprite;
    public string _tag;
    public bool activated = false;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == _tag) && (!activated))
        { 
            Activation(activatedSprite, true);
        }
    }
    void Activation(Sprite _sprite, bool _bool)
    {
        spriteRenderer.sprite = _sprite;
        activated = _bool;
        Level.currentActivators++;
    }
}
