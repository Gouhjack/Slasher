using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Exposed

    public Transform _target;
    public Vector3 offset;

    
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float yawSpeed = 100f;

    public float pitch = 2f;

    #endregion

    #region Unity LifeCycle
    void Start()
    {
        
    }

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        yawInput -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = _target.position - offset * currentZoom;
        transform.LookAt(_target.position + Vector3.up * pitch);
        transform.RotateAround(_target.position, Vector3.up, yawInput);
    }

    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    private float yawInput = 0f;
    private float currentZoom = 10f;

    #endregion
}
