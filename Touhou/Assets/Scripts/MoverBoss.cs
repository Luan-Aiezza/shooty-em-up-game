using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.UIElements;

public class MoverBoss : MonoBehaviour
{
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    public Animator anim;
    public float speed2;
    public float dodge;
    public float speed;
    public Boundary boundary;

    private Rigidbody2D rb;
    private float target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Evade());
    }

    private void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, target, speed);
        rb.velocity = new Vector2(newManeuver, rb.velocity.y);

        anim.SetFloat("Horizontal", target);
        anim.SetFloat("Vertical", rb.position.y);
        anim.SetFloat("Speed", rb.velocity.magnitude);

    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            target = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(2);
            target = 0;
            yield return new WaitForSeconds(2);
        }
    }


}
