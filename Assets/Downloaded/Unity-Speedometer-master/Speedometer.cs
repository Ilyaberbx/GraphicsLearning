using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Rigidbody _target;
    [SerializeField] private float _maxSpeed = 0.0f;
    [SerializeField] private float _minSpeedArrowAngle;
    [SerializeField] private float _maxSpeedArrowAngle;

    [Header("UI")]
    [SerializeField] private Text _speedLabel;
    [SerializeField] private RectTransform _arrow; 

    private float _speed = 0.0f;

    private void Update()
    {    
        _speed = _target.velocity.magnitude * 3.6f;
        DisplaySpeed(_speed);
    }

    private void DisplaySpeed(float speed)
    {
        if (_speedLabel != null)
            _speedLabel.text = ((int)speed) + " km/h";

        if (_arrow != null)
            _arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(_minSpeedArrowAngle, _maxSpeedArrowAngle, speed / _maxSpeed));
    }
}
