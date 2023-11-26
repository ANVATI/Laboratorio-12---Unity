using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speedX;
    public int directionX;
    public float speedY;
    public int directionY;
    private Rigidbody2D _compRigidbody;
    private SpriteRenderer _compSpriteRenderer;
    public float horizontal;
    public float vertical;

    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.position = new Vector2(transform.position.x + horizontal * speedX * Time.deltaTime, transform.position.y + vertical * speedY * Time.deltaTime);
    }

    void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(speedX * directionX, speedY * directionY);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Muro Vertical")
        {
            if (directionX == 1)
            {
                directionX = -1;

                _compSpriteRenderer.flipX = true;
            }
            else if (directionX == -1)
            {
                directionX = 1;

                _compSpriteRenderer.flipX = false;
            }
        }
        if (collision.gameObject.tag == "Muro Horizontal")
        {
            if (directionY == 1)
            {

                directionY = -1;
                _compSpriteRenderer.flipY = true;
            }
            else if (directionY == -1)
            {

                directionY = 1;
                _compSpriteRenderer.flipY = false;
            }
        }

    }


}

