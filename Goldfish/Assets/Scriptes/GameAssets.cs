using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets Instance; 
    public static GameAssets GetInstance()
    {
        return Instance;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //public Sprite waste;
    public GameObject Waste;
    public GameObject NuclearSign;
    public GameObject Enemy;
    public Sprite[] WasteCollection;
    public Sprite[] Enemies;

   
}
 