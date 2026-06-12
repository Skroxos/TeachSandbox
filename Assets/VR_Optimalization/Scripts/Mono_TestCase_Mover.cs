using UnityEngine;

public class Mono_TestCase_Mover : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float _rotationSpeedX = 10f;
    [SerializeField] private float _rotationSpeedY = 10f;
    [SerializeField] private float _rotationSpeedZ = 10f;

    [Header("Wave Settings")]
    [SerializeField] private float _waveSpeed = 2f;
    [SerializeField] private float _waveFrequency = 0.5f;
    [SerializeField] private float _waveAmplitude = 2f;

    private void Update()
    {
        Vector3 pos = transform.position;

        float waveY = Mathf.Sin((pos.x * _waveFrequency) + (Time.time * _waveSpeed)) * _waveAmplitude;
        waveY += Mathf.Cos((pos.z * _waveFrequency) + (Time.time * _waveSpeed)) * _waveAmplitude;

        pos.y = waveY;

        transform.position = pos;

        transform.Rotate(_rotationSpeedX * Time.deltaTime, _rotationSpeedY * Time.deltaTime, _rotationSpeedZ * Time.deltaTime, Space.Self);
    }
}