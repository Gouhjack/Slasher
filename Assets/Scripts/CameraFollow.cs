using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Exposed

    [SerializeField] private Transform _target;
    [SerializeField] private float _distance, _height;

    #endregion

    #region Unity LifeCycle
    void Start()
    {
        
    }

    void Update()
    {
        TargetFollow();
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods


    private void TargetFollow()
    {
        transform.LookAt(_target);
        transform.position = new Vector3(_target.position.x, _target.position.y + _height, _target.position.z - _distance);
    }

    #endregion

    #region Private & Protected

    #endregion
}
