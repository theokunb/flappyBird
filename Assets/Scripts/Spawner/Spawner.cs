using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _yMinPosition;
    [SerializeField] private float _yMaxPosition;
    [SerializeField] private float _delay;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initilize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _delay)
        {
            if(TryGetObject(out GameObject item))
            {
                _elapsedTime = 0;
                float yPosition = Random.Range(_yMinPosition, _yMaxPosition);
                Vector3 spawnPosition = new Vector3(transform.position.x, yPosition, transform.position.z);
                item.SetActive(true);
                item.transform.position = spawnPosition;
                DisableObjectAfterScreen();
            }
        }
    }
}
