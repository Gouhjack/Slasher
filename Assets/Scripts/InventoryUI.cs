using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Exposed
    Inventory inventory;
    #endregion

    #region Unity LifeCycle
    void Start()
    {
   //     inventory = Inventory.instance;
   //     inventory.onItemChangedCallBack += UpdateUI();
    }

    void Update()
    {
        
    }
    void UpdateUI()
    {
        Debug.Log("UPDATING UI");
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
