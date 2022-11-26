using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdColliredHandler : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private int _reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ScoreZone _))
        {
            _bird.AddScore(_reward);
        }
        else
        {
            Time.timeScale = 0;
            _bird.Die();
        }
    }
}
