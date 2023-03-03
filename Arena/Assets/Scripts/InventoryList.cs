using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList<T>
{
    private T _item;
    private T item
    {
        get { return _item;  }
    }
    public InventoryList()
    {
        Debug.Log("Generic list initialized...");
    }
    public void SetItem(T newItem)
    {
        _item = newItem;
        Debug.Log("New item added...");
    }
}
public class InventoryList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
