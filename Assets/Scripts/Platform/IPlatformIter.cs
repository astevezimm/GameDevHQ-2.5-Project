using System.Collections;
using UnityEngine;

public interface IPlatformIter
{
    bool Finished { get; }
    Vector3 NextPoint { get; }
    void ChangeNextPoint();
}