using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Bird _bird;

    private void OnEnable()
    {
        _bird.OnScoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        _bird.OnScoreChanged -= ScoreChanged;
    }

    private void ScoreChanged()
    {
        _text.text = _bird.Score.ToString();
    }
}
