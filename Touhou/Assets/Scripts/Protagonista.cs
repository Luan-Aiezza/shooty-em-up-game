using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Protagonista : MonoBehaviour
{


    public GameObject gameOverImg;
    public Animator anim;
    public float speed;
    public GameObject bullet;
    public Transform[] shootSpawns;
    public float fireRate;
    public int lives = 3;
    public float spawnTime;
    public float invencibilityTime;

    private bool gameOver = true;
    private Rigidbody2D rb;
    private float nextFire;
    private bool isDead = false;
    private SpriteRenderer sprite;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver = false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (!isDead)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Destroy(Instantiate(bullet, shootSpawns[0].position, shootSpawns[0].rotation), 1.5f);
            }
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

    }

    public void Respawn()
    {
        lives--;
        if(lives > 0)
        {
            StartCoroutine(Spawning());
        }
        else
        {
            lives = 0;
            isDead = true;
            sprite.enabled = false;
            GameOverFunction();
        }
    }

    IEnumerator Spawning()
    {
        isDead = true;
        sprite.enabled = false;
        gameObject.layer = 10;
        yield return new WaitForSeconds(spawnTime);
        isDead = false;
        for(float i = 0; i <invencibilityTime; i+= 0.1f)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.layer = 8;
        sprite.enabled = true;
    }

    public void GameOverFunction()
    {
        gameOver = false;
        gameOverImg.SetActive(true);
        Destroy(gameObject);
    }
}
