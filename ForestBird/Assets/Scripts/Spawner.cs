using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private int _poolSize = 5;

    private float _timer;
    private List<GameObject> _pipePool;

    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void InitializePool()
    {
        _pipePool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject pipe = Instantiate(_obstacle, Vector3.zero, Quaternion.identity);
            pipe.SetActive(false);
            _pipePool.Add(pipe);
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = _pipePool.Find(p => !p.activeSelf);

        if (pipe == null)
        {
            pipe = Instantiate(_obstacle, Vector3.zero, Quaternion.identity);
            _pipePool.Add(pipe);
        }

        Vector3 spawnPos = transform.position + new Vector3(6, Random.Range(-_heightRange, _heightRange));
        pipe.transform.position = spawnPos;
        pipe.SetActive(true);

        StartCoroutine(DeactivatePipe(pipe, 6f));
    }

    private IEnumerator DeactivatePipe(GameObject pipe, float delay)
    {
        yield return new WaitForSeconds(delay);
        pipe.SetActive(false);
    }
}