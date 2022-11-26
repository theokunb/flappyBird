using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;

    public event Action OnGameOver;
    public event Action OnScoreChanged;

    public int Score { get; private set; }

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        ResetBird();
    }

    public void ResetBird()
    {
        Score = 0;
        OnScoreChanged?.Invoke();
        _mover.ResetPosition();
    }

    public void AddScore(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke();
    }

    public void Die()
    {
        OnGameOver?.Invoke();
    }
}
