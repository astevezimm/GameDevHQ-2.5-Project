using System.Collections;
using UnityEngine;

public interface IPlatformIter
{
    Vector3 NextPoint { get; }
    IEnumerator ChangeNextPoint();
}