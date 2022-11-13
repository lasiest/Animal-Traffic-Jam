using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public bool playerCaught;
    public GameObject GameOverScene;

    Vector2 movement;

    void awake()
    {
        gameObject.layer = 6;
        playerCaught = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(x, y).normalized;

        if (playerCaught)
        {
            GameOverScene.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SpeedBoost")
        {
            Debug.Log("touch SpeedBoost");
            StartCoroutine(WaitSpeedBoost());
        }

        if (collision.gameObject.tag == "InvisibleBoost")
        {
            Debug.Log("touch InvisibleBoost");
            StartCoroutine(WaitInvisibleBoost());
        }
    }

    public IEnumerator WaitSpeedBoost()
    {
        moveSpeed = moveSpeed * 2;
        yield return new WaitForSeconds(5f);
        moveSpeed = moveSpeed / 2;
    }

    public IEnumerator WaitInvisibleBoost()
    {
        gameObject.layer = 8;
        yield return new WaitForSeconds(5f);
        gameObject.layer = 6;
    }
}
