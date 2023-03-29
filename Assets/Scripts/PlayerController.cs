using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    #region Exposed

    private Camera cam;
    PlayerMotor motor;

    #endregion

    #region Unity LifeCycle
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit _hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, 100))
            {
                motor.MoveToPoint(_hit.point);
                //_position = _hit.point;
                //Debug.Log(_position);
                Interactable interactable = _hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("INTERACTABLE");
                    SetFocus(interactable);
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            RaycastHit _hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, 100))
            {

            }
                RemoveFocus();
        }
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
