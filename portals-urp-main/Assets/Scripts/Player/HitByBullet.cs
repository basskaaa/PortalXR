using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBullet : MonoBehaviour
{
    [SerializeField] GameEvent playerDead;
    [SerializeField] int maxHitCount = 20;
    private int hitCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCount++;
            //Debug.Log("Hit");
        }
    }

    private void Update()
    {
        if (hitCount > maxHitCount) 
        {
            playerDead.Raise();
            //Debug.Log(hitCount.ToString());
        }
    }

    public void ResetHitCount()
    {
        hitCount = 0;
        //Debug.Log("Hit count reset");
    }
}
