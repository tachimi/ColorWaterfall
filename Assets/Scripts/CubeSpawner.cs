using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timePerSpawn;
    [SerializeField] private Transform _cubesParent;

    public UnityEvent IsAllCubesSpawned;

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        for (int i = 20; i > 0; i--)
        {
            for (int j = 0; j < 20; j++)
            {
                var position = new Vector3(j, 0, i);
                Instantiate(_prefab, position, Quaternion.identity, _cubesParent);
                yield return new WaitForSeconds(_timePerSpawn);
            }
        }

        IsAllCubesSpawned.Invoke();
    }
}