using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLife : MonoBehaviour
{
    public GameObject gameOverImg2;
    public int health;
    public GameObject explosion;
    public Color damageColor;

    private bool gameOver2 = false;
    private bool isDead = false;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (gameOver2 = true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (!isDead)
        {
            health -= damage;
            if(health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                if(this.GetComponent<Protagonista>() != null)
                {
                    GetComponent<Protagonista>().Respawn();
                }
                else
                {
                    isDead = true;
                    Destroy(gameObject);
                    GameOverFunction2();
                    
                }
            }
            else
            {
                StartCoroutine(TakingDamage());
            }
        }
    }

    IEnumerator TakingDamage()
    {
        sprite.color = damageColor;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    public void GameOverFunction2()
    {
        gameOver2 = true;
        gameOverImg2.SetActive(true);
    }

}
