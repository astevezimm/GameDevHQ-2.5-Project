using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed = 1;
    [SerializeField] private PlatformMovementType type;

    private IPlatformIter _platformIter;

    private void Start()
    {
        wayPoints ??= new[] {platform};
        if (wayPoints.Length == 1)
            type = PlatformMovementType.SinglePass;
        _platformIter = type switch
        {
            PlatformMovementType.Loop => new LoopPlatformIter(wayPoints),
            PlatformMovementType.PingPong => new PingPongPlatformIter(wayPoints),
            _ => new SingPassPlatformIter(wayPoints)
        };
    }

    private void FixedUpdate()
    {
        if (_platformIter.Finished)
            return;
        float delta = speed * Time.deltaTime;
        platform.position =
            Vector3.MoveTowards(platform.position, _platformIter.NextPoint, delta);
        if (platform.position == _platformIter.NextPoint)
            _platformIter.ChangeNextPoint();
    }
}