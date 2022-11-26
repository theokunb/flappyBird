using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Screen _playScreen;
    [SerializeField] private Screen _gameOverScreen;

    private void OnEnable()
    {
        _playScreen.OnButtonClicked += OnPlayButtonClicked;
        _gameOverScreen.OnButtonClicked += OnGameOverButtonClicked;
        _bird.OnGameOver += OnBirdGameOver;
    }


    private void OnDisable()
    {
        _playScreen.OnButtonClicked -= OnPlayButtonClicked;
        _gameOverScreen.OnButtonClicked -= OnGameOverButtonClicked;
        _bird.OnGameOver-= OnBirdGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _playScreen.Open();
    }

    private void OnPlayButtonClicked()
    {
        Time.timeScale = 1;
        _playScreen.Close();
    }

    private void OnBirdGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void OnGameOverButtonClicked()
    {
        Time.timeScale = 1;
        _bird.ResetBird();
        _spawner.ResetPool();
        _gameOverScreen.Close();
    }
}
