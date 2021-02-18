using System;
using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed = 1;
    [SerializeField] private PlatformMovementType type;

    private IPlatformIter _platformIter;

    private void Start()
    {
        wayPoints ??= new[] {transform};
        _platformIter = type switch
        {
            PlatformMovementType.Loop => new LoopPlatformIter(wayPoints),
            PlatformMovementType.PingPong => new PingPongPlatformIter(wayPoints),
            _ => new SingPassPlatformIter(wayPoints)
        };
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            float delta = speed * Time.deltaTime;
            transform.position =
                Vector3.MoveTowards(transform.position, _platformIter.NextPoint, delta);
            if (transform.position == _platformIter.NextPoint)
                yield return _platformIter.ChangeNextPoint();
            yield return null;
        }
    }
}