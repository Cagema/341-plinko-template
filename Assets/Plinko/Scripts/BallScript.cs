using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (transform.position.y < -GameManager.Single.RightUpperCorner.y - 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            GameManager.Single.Score += collision.gameObject.GetComponent<BlockScript>().TouchScore;
            GameManager.Single.BlockTouchSound();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Single.Score += collision.GetComponent<BonusBucket>().ScoreBonus;
        GameManager.Single.BucketHitSound();
        Destroy(gameObject);
    }
}
