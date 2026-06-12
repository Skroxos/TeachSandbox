using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public class Centralized_TestCase_Rotater : MonoBehaviour
{
    [SerializeField] private Transform[] _cubes;

    [Header("Rotation Settings")]
    [SerializeField] private float _rotationSpeedX = 10f;
    [SerializeField] private float _rotationSpeedY = 10f;
    [SerializeField] private float _rotationSpeedZ = 10f;

    [Header("Wave Settings")]
    [SerializeField] private float _waveSpeed = 2f;
    [SerializeField] private float _waveFrequency = 0.5f;
    [SerializeField] private float _waveAmplitude = 2f;

    private TransformAccessArray _transformAccessArray;
    private JobHandle _waveAndRotateJobHandle;

    private void Start()
    {
        _transformAccessArray = new TransformAccessArray(_cubes);
    }

    private void Update()
    {
        WaveAndRotateCubesJob job = new WaveAndRotateCubesJob
        {
            ElapsedTime = Time.time,     
            DeltaTime = Time.deltaTime,
            RotationX = _rotationSpeedX,
            RotationY = _rotationSpeedY,
            RotationZ = _rotationSpeedZ,
            WaveSpeed = _waveSpeed,
            WaveFrequency = _waveFrequency,
            WaveAmplitude = _waveAmplitude
        };

        _waveAndRotateJobHandle = job.Schedule(_transformAccessArray);
    }

    private void LateUpdate()
    {
        _waveAndRotateJobHandle.Complete();
    }

    private void OnDestroy()
    {
        _waveAndRotateJobHandle.Complete();

        if (_transformAccessArray.isCreated)
        {
            _transformAccessArray.Dispose();
        }
    }
}

[BurstCompile]
public struct WaveAndRotateCubesJob : IJobParallelForTransform
{
    public float DeltaTime;
    public float RotationX;
    public float RotationY;
    public float RotationZ;

    public float ElapsedTime;
    public float WaveSpeed;
    public float WaveFrequency;
    public float WaveAmplitude;

    public void Execute(int index, TransformAccess transform)
    {
        float3 pos = transform.position;

        float waveY = math.sin((pos.x * WaveFrequency) + (ElapsedTime * WaveSpeed)) * WaveAmplitude;
        waveY += math.cos((pos.z * WaveFrequency) + (ElapsedTime * WaveSpeed)) * WaveAmplitude;

        pos.y = waveY;
        transform.position = pos;

        quaternion currentRotation = transform.localRotation;

        float deltaX = RotationX * DeltaTime;
        float deltaY = RotationY * DeltaTime;
        float deltaZ = RotationZ * DeltaTime;

        quaternion rotationDelta = quaternion.Euler(math.radians(new float3(deltaX, deltaY, deltaZ)));

        transform.localRotation = math.mul(currentRotation, rotationDelta);
    }
}