using System.Collections;
using UnityEngine;

public class SingPassPlatformIter : IPlatformIter
{
    private readonly Transform[] _wayPoints;
    private int _index;

    public Vector3 NextPoint => _wayPoints[_index].position;

    public SingPassPlatformIter(Transform[] wayPoints) => _wayPoints = wayPoints;

    public IEnumerator ChangeNextPoint()
    {
        _index++;
        if (_index >= _wayPoints.Length)
            yield break;
        yield return null;
    }
}