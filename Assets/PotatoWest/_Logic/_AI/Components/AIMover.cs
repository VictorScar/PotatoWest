using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PotatoWest._Logic._AI
{
    public class AIMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody body;
        [SerializeField] private WaypointData _waypointData;
        
       
        private Waypoint _targetPoint;
        private Transform _moveTarget;
        private float _speed;
        private float _moveThreshold;
        private int _waypointNumber;
      
        public WaypointData WaypointData
        {
            get => _waypointData;
            set
            {
                _waypointData = value;
                _waypointNumber = 0;
            }
        }

        public bool IsMoving => _moveTarget != null || !_targetPoint.IsInvalid;

        public void Init()
        {
            
        }

        public void MoveToTarget(Transform target)
        {
        }

        public void UpdateMover()
        {
            UpdateMoving();
        }

        private void UpdateMoving()
        {
            if (!_targetPoint.IsInvalid)
            {
                if (Vector3.Distance(body.position, _targetPoint.Point) < _moveThreshold)
                {
                    body.position += (_targetPoint.Point - body.position).normalized * _speed * Time.deltaTime;
                }
                else
                {
                    GetNextPoint();
                }
            }
        }

        private void GetNextPoint()
        {
            if (_waypointData.IsValid)
            {
                _waypointNumber++;
                
                if (_waypointNumber < _waypointData.Waypoints.Length)
                {
                    _targetPoint = _waypointData.Waypoints[_waypointNumber];
                }
                else if(_waypointData.IsLooped)
                {
                    _waypointNumber = 0;
                    _targetPoint = _waypointData.Waypoints[_waypointNumber];
                }
                else
                {
                    _targetPoint = Waypoint.Invalid;
                }
            }
        }

        public void RotateTo(Transform target)
        {
            if (target != null)
            {
                body.rotation = Quaternion.LookRotation((target.position - body.transform.position).normalized);
            }
        }

        public void Stop()
        {
        }
    }

    [Serializable]
    public struct Waypoint
    {
        public Vector3 Point;
        public bool IsInvalid;

        public static Waypoint Invalid => new Waypoint { IsInvalid = true };
    }

    [Serializable]
    public struct WaypointData
    {
        public Waypoint[] Waypoints;
        public bool IsLooped;

        public bool IsValid => Waypoints != null && Waypoints.Length > 0;
    }
}