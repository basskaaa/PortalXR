using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private MovingPlatform_WaypointPath _waypointPath;

    [SerializeField] private float _speed;

    [SerializeField] private bool isRepeating = true;
    [SerializeField] private bool isReturning = false;
    [SerializeField] private bool isActive = true;
    [SerializeField] private bool isFirstLevel = false;

    private int _targetWaypointIndex;
    private int activateCheck = 0;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    private Transform _oldParent;

    void Start()
    {
        TargetNextWaypoint();
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            _elapsedTime += Time.deltaTime;

            float elapsedPercentage = _elapsedTime / _timeToWaypoint;
            elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
            transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
            transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

            if (elapsedPercentage >= 1 && (isRepeating || isReturning))
            {
                TargetNextWaypoint();
            }
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        if (isReturning && _targetWaypointIndex == 0)
        {
            return;
        }
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Interactable"))
        {
            _oldParent = other.transform.parent; 
            other.transform.SetParent(transform);
            //Debug.Log(other.name + " " + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Interactable"))
        {
            if (_oldParent != null) 
            {
                other.transform.SetParent(_oldParent);
                //Debug.Log(other.name + " " + _oldParent.name);
                return;
            }
            other.transform.SetParent(null);
        }
    }

    public void ActivatePlatform()
    {
        if (!isFirstLevel)
        {
            activateCheck++;
            if (activateCheck != 2)
            {
                return;
            }
            else
            {
                isActive = true;
            }
            return;
        }
        else 
        {
            isActive = true;
        }
    }
}
