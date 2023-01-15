using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance; // practice to get instance in Unity
    public static GameAssets GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }

    //public Sprite waste;
    public GameObject Waste;
    public GameObject NuclearSign;
    public GameObject Enemy;
    public Sprite[] Wastes;
    public Sprite[] Enemies;

   
}
 