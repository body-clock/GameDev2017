using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    public Animator anim;
    public Collider2D col;
    public float delay = 1f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        anim.Play("cash");
        StartCoroutine(KillOnAnimationEnd());
        col.enabled = false;
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(.429f);
        Destroy(gameObject);
    }
}
