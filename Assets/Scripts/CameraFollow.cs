using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private float _traslationSpeed;
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        HandleRotation();
        HandleTranslation();
    }
    private void HandleTranslation()
    {
        var targetPos = _target.TransformPoint(_offset);
        transform.position = Vector3.Lerp(transform.position, targetPos, _traslationSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = _target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

}
