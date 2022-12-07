using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    #region Singleton

    public static UIScript instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Start is called before the first frame update
    [SerializeField] private Text itemCount;

    public void ChangeText(int num)
    {
        string textNum = num.ToString();
        itemCount.text = textNum + " / 5";
    }
}
