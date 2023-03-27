using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickToMove : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float _speed;

    #endregion

    #region Unity LifeCycle
    void Start()
    {

    }

    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            GetPosition();
        }
        
        MoveToPosition();
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    private void GetPosition()
    {
        RaycastHit _hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit))
        {
            _position = _hit.point;
            Debug.Log(_position);
        }
    }

    private void MoveToPosition()
    {
        if (Vector3.Distance(transform.position, _position) > 0f)
        {
            Quaternion _newRotation = Quaternion.LookRotation(_position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, _newRotation, 0.05f);
            transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
        }
    }

    #endregion

    #region Private & Protected

    private Vector3 _position = Vector3.zero;
    
    #endregion
}
