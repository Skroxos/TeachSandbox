using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour
{
    private Grid _grid;
    private Camera _camera;
    private static readonly Plane _groundPlane = new Plane(Vector3.up, Vector3.zero);
    [SerializeField] private int _gridWidth = 100;
    [SerializeField] private int _gridHeight = 100;
    [SerializeField] private int _cellSize = 5;

    private List<ISpatialEntity> _nearbyEntities = new List<ISpatialEntity>(64);
    private void Awake()
    {
        _grid = new Grid(_gridWidth, _gridHeight, _cellSize);
        _camera = Camera.main;
    }

    private void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(0, _gridWidth * _cellSize), 0, Random.Range(0, _gridHeight * _cellSize));
            TestEntity entity = new TestEntity(randomPos);
            int cellIndex = _grid.GetCellIndex(randomPos);
            _grid.AddObjectToCell(cellIndex, entity);
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _nearbyEntities.Clear();
            _grid.GetNearbyEntitiesInCircle(GetMouseWorldPosition(), 5f, _nearbyEntities);
        }
        if (Input.GetMouseButtonDown(1))
        {
            _nearbyEntities.Clear();
            _grid.GetNearbyEntities(GetMouseWorldPosition(), 5f, _nearbyEntities);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (_groundPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }

    public  void OnDrawGizmos()
    {
        if (_cellSize == 0) return;
        Gizmos.color = Color.gray;
        for (int x = 0; x < _gridWidth; x++)
        {
            for (int z = 0; z < _gridHeight; z++)
            {
                Vector3 cellPos = new Vector3(x * _cellSize, 0, z * _cellSize);
                Gizmos.DrawWireCube(cellPos + new Vector3(_cellSize / 2f, 0, _cellSize / 2f), new Vector3(_cellSize, 0, _cellSize));
            }
        }
        for (int i = 0; i < _nearbyEntities.Count; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_nearbyEntities[i].Position, 0.5f);
        }
    }
}
