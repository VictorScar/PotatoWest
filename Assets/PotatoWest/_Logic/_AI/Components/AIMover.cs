using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._AI.Components;
using UnityEngine;

namespace PotatoWest._Logic._AI
{
    public class AIMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody body;
        [SerializeField] private WaypointData _waypointData;


        private Waypoint _targetPoint;
        private Transform _moveTarget;
        private float _speed = 5f;
        private float _moveThreshold = 0.1f;
        private int _waypointNumber;
        private bool _isStopped;

        public WaypointData WaypointData
        {
            get => _waypointData;
            set
            {
                Debug.Log($"Set Waypoints {value.Waypoints != null}");
                _waypointData = value;
                _waypointNumber = 0;
            }
        }

        public bool IsMoving => _moveTarget != null || !_targetPoint.IsInvalid;

        public void Init(AICharacterParameters parameters)
        {
            Debug.Log("Init Mover");
            _speed = parameters.MoveSpeed;
            WaypointData = new WaypointData();
            _targetPoint = Waypoint.Invalid;
            _isStopped = false;
        }

        public void MoveToTarget(Transform target)
        {
            _moveTarget = target;
        }

        public void Update()
        {
            UpdateMoving();
        }

        private void UpdateMoving()
        {
            if (_moveTarget != null)
            {
                _targetPoint = new Waypoint { Point = _moveTarget.position };
            }

            if (!_targetPoint.IsInvalid)
            {
                if (Vector3.Distance(body.position, _targetPoint.Point) > _moveThreshold)
                {
                    body.position += (_targetPoint.Point - body.position).normalized * _speed * Time.deltaTime;
                    return;
                }
            }

            if(!_isStopped) GetNextPoint();
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
                else if (_waypointData.IsLooped)
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
            _moveTarget = null;
            _targetPoint = Waypoint.Invalid;
            _isStopped = true;
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