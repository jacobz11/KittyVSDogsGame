using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float velocity = 7f;
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime * Vector3.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FurBall"))
        {
            ScoreCounter.scoreValue += 1;
            Destroy(gameObject);
        }
    }
}
