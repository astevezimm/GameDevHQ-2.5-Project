using System.Collections;
using UnityEngine;

public class LoopPlatformIter : IPlatformIter
{
    private readonly Transform[] _wayPoints;
    private int _index;

    public bool Finished => false;
    
    public Vector3 NextPoint => _wayPoints[_index].position;

    public LoopPlatformIter(Transform[] wayPoints) => _wayPoints = wayPoints;

    public void ChangeNextPoint()
    {
        _index++;
        if (_index >= _wayPoints.Length)
            _index = 0;
    }
}