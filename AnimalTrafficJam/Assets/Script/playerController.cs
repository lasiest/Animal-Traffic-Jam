using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public bool playerCaught;
    public GameObject GameOverScene;
    public Animator animator;
    public float speedDur = 5f;
    public float invisibleDur = 5f;
    [SerializeField] private AudioClip CollectInvis;
    [SerializeField] private AudioClip CollectSpeed;

    Vector2 movement;

    void awake()
    {
        gameObject.layer = 6;
        playerCaught = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        speedDur = PlayerPrefs.GetInt("speedDur");
        invisibleDur = PlayerPrefs.GetInt("invisibleDur");
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x != 0 || y != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if(x > 0){
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
        if (x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

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
            StartCoroutine(WaitSpeedBoost(speedDur));
        }

        if (collision.gameObject.tag == "InvisibleBoost")
        {
            Debug.Log("touch InvisibleBoost");
            StartCoroutine(WaitInvisibleBoost(invisibleDur));
        }
    }

    public IEnumerator WaitSpeedBoost(float dur)
    {
        moveSpeed = moveSpeed * 2;
        SoundManager.instance.PlaySound(CollectSpeed);
        yield return new WaitForSeconds(dur);
        moveSpeed = moveSpeed / 2;
    }

    public IEnumerator WaitInvisibleBoost(float dur)
    {
        gameObject.layer = 8;
        SoundManager.instance.PlaySound(CollectInvis);
        yield return new WaitForSeconds(dur);
        gameObject.layer = 6;
    }
}
