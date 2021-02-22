using UnityEngine;

public class SingPassPlatformIter : IPlatformIter
{
    private readonly Transform[] _wayPoints;
    private int _index;

    public bool Finished => _index >= _wayPoints.Length;
    
    public Vector3 NextPoint => _wayPoints[_index].position;

    public SingPassPlatformIter(Transform[] wayPoints) => _wayPoints = wayPoints;

    public void ChangeNextPoint() => _index++;
}