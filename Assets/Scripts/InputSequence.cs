using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class InputSequence : MonoBehaviour
{
    private Collider myCollider;

    private List<Collider> enteredColliders = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        var inputStream = Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3));

        var oneStream = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Alpha1));
        var twoStream = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Alpha2));
        var threeStream = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Alpha3));
        var fourStream = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Alpha4));

        var numberStream = Observable.ZipLatest(oneStream, twoStream, threeStream, fourStream).Subscribe(_ =>
        {
            Debug.Log("numbers !");
        });


        var triggerEnterStream = myCollider.OnTriggerEnterAsObservable();
        triggerEnterStream.Subscribe(c =>
        {
            enteredColliders.Add(c);
            if(enteredColliders.Count == 4)
            {
                Debug.Log("hello");
            }
        });
    }

    
}
