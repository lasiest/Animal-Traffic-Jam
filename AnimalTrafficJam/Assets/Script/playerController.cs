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
    public int speedDur = 5;
    public int invisibleDur = 5;
    public Material invisibleMaterial;
    [SerializeField] private AudioClip CollectInvis;
    [SerializeField] private AudioClip CollectSpeed;

    Vector2 movement;
    private Material defaultMaterial;

    void awake()
    {
        gameObject.layer = 6;
        playerCaught = false;        
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("speedDur") == 0)
        {
            PlayerPrefs.SetInt("speedDur", 5);
        }
        else
        {
            speedDur = PlayerPrefs.GetInt("speedDur");
        }

        if (PlayerPrefs.GetInt("invisibleDUr") == 0)
        {
            PlayerPrefs.SetInt("invisibleDur", 5);
        }
        else
        {
            invisibleDur = PlayerPrefs.GetInt("speedDur");
        }

        defaultMaterial = gameObject.GetComponent<SpriteRenderer>().material;
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
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            Debug.Log("touch SpeedBoost");
            StartCoroutine(WaitSpeedBoost(speedDur));
        }

        if (collision.gameObject.CompareTag("InvisibleBoost"))
        {
            Debug.Log("touch InvisibleBoost");
            StartCoroutine(WaitInvisibleBoost(invisibleDur));
        }
    }

    public IEnumerator WaitSpeedBoost(float dur)
    {
        moveSpeed *= 2;
        SoundManager.instance.PlaySound(CollectSpeed);
        yield return new WaitForSeconds(dur);
        moveSpeed /= 2;
    }

    public IEnumerator WaitInvisibleBoost(float dur)
    {
        gameObject.GetComponent<SpriteRenderer>().material = invisibleMaterial;
        gameObject.layer = 8;
        SoundManager.instance.PlaySound(CollectInvis);
        yield return new WaitForSeconds(dur);
        gameObject.GetComponent<SpriteRenderer>().material = defaultMaterial;
        gameObject.layer = 6;
    }
}
