using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    private float velocity = 7f;
    void Update()
    {
        Vector3 left;
        left = transform.right * -1;
        transform.Translate(velocity * Time.deltaTime * left);
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
