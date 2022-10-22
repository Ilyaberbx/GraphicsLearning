using UnityEngine;
using UnityEngine.Events;

public class Engine : MonoBehaviour
{
    public UnityAction OnBraked;

    [SerializeField] private float _motorForce;
    [SerializeField] private float _breakForce;
    [SerializeField] private float _maxSteerAngle;
    [SerializeField] private PlayerInput _playerInput;
    

    [SerializeField] private WheelCollider _frontLeftWheelCollider;
    [SerializeField] private WheelCollider _frontRightWheelCollider;
    [SerializeField] private WheelCollider _backLeftWheelCollider;
    [SerializeField] private WheelCollider _backRightWheelCollider;

    [SerializeField] private Transform _frontLeftWheel;
    [SerializeField] private Transform _frontRightWheel;
    [SerializeField] private Transform _backLeftWheel;
    [SerializeField] private Transform _backRightWheel;

    private void FixedUpdate()
    {
        if (_playerInput.IsBreaking)
        {
            ApplyBreaking(_breakForce);
            OnBraked?.Invoke();
            return;
        }
        else
        {
            ApplyBreaking(0);
        }

        Move();
        Steer();
        UpdateWheels();
    }

    private void Move()
    {
        float movement = _motorForce * _playerInput.VerticalInput;
        _frontRightWheelCollider.motorTorque = movement;
        _frontLeftWheelCollider.motorTorque = movement;
        Debug.Log(_frontRightWheelCollider.motorTorque);
    }
   
    private void ApplyBreaking(float breakForce)
    {
        _frontLeftWheelCollider.brakeTorque = breakForce;
        _frontRightWheelCollider.brakeTorque = breakForce;
        _backLeftWheelCollider.brakeTorque = breakForce;
        _backRightWheelCollider.brakeTorque = breakForce;
    }
    private void Steer()
    {
        _frontLeftWheelCollider.steerAngle = _maxSteerAngle * _playerInput.HorizontalInput;
        _frontRightWheelCollider.steerAngle = _maxSteerAngle * _playerInput.HorizontalInput;
    }
    private void UpdateWheels()
    {
        UpdateSingeWheel(_frontLeftWheel, _frontLeftWheelCollider);
        UpdateSingeWheel(_frontRightWheel, _frontRightWheelCollider);
        UpdateSingeWheel(_backLeftWheel, _backLeftWheelCollider);
        UpdateSingeWheel(_backRightWheel, _backRightWheelCollider);
    }
    private void UpdateSingeWheel(Transform wheelTransform ,WheelCollider wheelCollider) 
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }

}
