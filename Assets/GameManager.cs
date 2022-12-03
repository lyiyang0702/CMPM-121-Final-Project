using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<items> items = new List<items> ();
    public delegate void OnItemsChanged();
    public OnItemsChanged onItemsChanged;
    public bool Add(items item)
    {
        if (onItemsChanged != null)
        {
            onItemsChanged.Invoke();
        }
        if (item)
        {
            items.Add(item);
            return true;
        }

        return false;
    }

    public void GameEnd()
    {
        Debug.Log("Game End");
        // call game end scene if we have one
    }

}
