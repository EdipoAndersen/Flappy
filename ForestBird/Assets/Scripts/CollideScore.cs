using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Highscore.instance.UpdateScore();
        }
    }
}
