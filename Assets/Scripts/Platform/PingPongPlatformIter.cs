using System.Collections;
using UnityEngine;

public class PingPongPlatformIter : IPlatformIter
{
    private readonly Transform[] _wayPoints;
    private int _index;
    private bool _forward = true;
    
    public Vector3 NextPoint => _wayPoints[_index].position;

    public PingPongPlatformIter(Transform[] wayPoints) => _wayPoints = wayPoints;

    public IEnumerator ChangeNextPoint()
    {
        if (_forward)
        {
            _index++;
            if (_index == _wayPoints.Length)
            {
                _index -= 2;
                _forward = false;
            }
        }
        else
        {
            _index--;
            if (_index < 0)
            {
                _index = 1;
                _forward = true;
            }
        }
        yield return null;
    }
}