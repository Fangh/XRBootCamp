using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);

        var updateStream = Observable.EveryUpdate();
        updateStream.Subscribe(_ => transform.Translate(transform.forward * speed * Time.deltaTime, Space.World));
    }
}
