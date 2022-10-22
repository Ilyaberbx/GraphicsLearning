using System.Collections.Generic;
using UnityEngine;

public class LightBreaker : MonoBehaviour
{
    [SerializeField] private List<Light> _headLights;
    [SerializeField] private float _maxLightIntensity;
    private float _currentIntensity;

    private void Awake() => SwitchOff();

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.H)) return;

        if (_currentIntensity == _maxLightIntensity)
            SwitchOff();
        else
            SwitchOn();
    }
    private void SwitchOff()
    {
        foreach (var light in _headLights)
        {
            light.intensity = 0;
            _currentIntensity = 0;
        }
    }
    private void SwitchOn()
    {
        foreach (var light in _headLights)
        {
            light.intensity = _maxLightIntensity;
            _currentIntensity = _maxLightIntensity;
        }
    }

}
