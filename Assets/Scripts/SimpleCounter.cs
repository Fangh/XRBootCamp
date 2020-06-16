using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SimpleCounter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var timeStream = Observable.Interval(TimeSpan.FromSeconds(1)).Timestamp();
        timeStream.Subscribe(x => Debug.Log($"Hello {x.Timestamp}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
