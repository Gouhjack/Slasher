using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickToMove : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float _speed;
    [SerializeField] Interactable _focus;
    [SerializeField] private LayerMask _movementMask;

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

        if (Input.GetMouseButton(0))
        {
            RemoveFocus();
        }
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
        if (Physics.Raycast(ray, out _hit, 100, _movementMask))
        {
            _position = _hit.point;
            //Debug.Log(_position);
            Interactable interactable = _hit.collider.GetComponent<Interactable>();
            if (interactable != null) 
            {
                Debug.Log("INTERACTABLE");
                SetFocus(interactable);
            }
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

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != _focus)
        {
            if (_focus != null) 
            { 
            _focus.OnDefocused();
            _focus = newFocus;
            
            }
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        _focus.OnDefocused();
        _focus = null;
    }

    public void FollowTarget (Interactable newTarget)
    {

    }
    #endregion

    #region Private & Protected

    private Vector3 _position = Vector3.zero;
    
    #endregion
}
