using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Exposed

    public Transform _target;
    public Vector3 offset;
    private float currentZoom = 10f;
    public float pitch = 2f;

    #endregion

    #region Unity LifeCycle
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = _target.position - offset * currentZoom;
        transform.LookAt(_target.position + Vector3.up * pitch);
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    #endregion
}
