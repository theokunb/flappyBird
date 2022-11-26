using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigibody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();

        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = _maxRotation;
            _rigibody.velocity = new Vector2(_speed, 0);
            _rigibody.AddForce(new Vector2(0, _tapForce));
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        _rigibody.velocity = Vector3.zero;
    }
}
