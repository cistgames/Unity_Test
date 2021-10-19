using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ref_rbody = null;
    [SerializeField] private Animator ref_animator = null;
    [SerializeField] private float speed = 0f;

    private float scale_x_start = 0f;
    private float dir;

    private void Start()
    {
        scale_x_start = transform.localScale.x;
    }

    private void Update()
    {
        dir = Input.GetAxis("Horizontal");

        if (dir != 0f)
        {
            transform.localScale = new Vector2(scale_x_start  * -1 * Mathf.Sign(dir), transform.localScale.y);
        }
        
    }

    private void FixedUpdate()
    {
        ref_rbody.AddForce(new Vector2(Time.fixedDeltaTime * speed * dir, 0f));
        ref_animator.SetFloat("speed", Mathf.Abs(ref_rbody.velocity.x));
    }
}
