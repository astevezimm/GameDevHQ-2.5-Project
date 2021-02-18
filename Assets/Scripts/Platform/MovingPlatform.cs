using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed = 1;
    [SerializeField] private bool pingPong = true;

    private Vector3 _nextPoint;
    private bool _forward = true;

    private void Start()
    {
        if (wayPoints == null)
            wayPoints = new[] {transform};
        _nextPoint = wayPoints[0].position;
    }

    private void Update()
    {
        float delta = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _nextPoint, delta);
        if (transform.position == _nextPoint)
        {
            
        }
    }
}