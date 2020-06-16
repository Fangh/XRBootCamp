using System;
using UniRx;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform turretTip1;
    [SerializeField] private Transform turretTip2;

    [Header("Settings")]
    [SerializeField] private float firingCooldown = 1.5f;

    void Start()
    {
        var spaceBarStream = Observable.Interval(TimeSpan.FromSeconds(firingCooldown))
            .Where(_ => Input.GetKey(KeyCode.Space));

        spaceBarStream.Subscribe(x =>
        {
            Instantiate(laserPrefab, turretTip1.position, turretTip1.rotation);
            Instantiate(laserPrefab, turretTip2.position, turretTip2.rotation);
        });
    }

}
