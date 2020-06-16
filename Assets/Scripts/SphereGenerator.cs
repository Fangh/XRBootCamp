using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject spherePrefab;

    [Header("Settings")]
    [SerializeField] private float generationCooldown = 1.3f;

    bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        var inputStream = Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Return));

        inputStream.Buffer(inputStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(x => x.Count >= 2)
            .Subscribe(x =>
            {
                canSpawn = true;
                Debug.Log($"multiple enter detected. count={x.Count}");
            });

        var generatorStream = Observable.Interval(TimeSpan.FromSeconds(generationCooldown));

        generatorStream.Subscribe(x =>
        {
            if (canSpawn)
            {
                Instantiate(spherePrefab, transform.position, Quaternion.identity);
            }
        });
    }
}
