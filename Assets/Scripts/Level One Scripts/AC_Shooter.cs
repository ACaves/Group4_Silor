using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Shooter : MonoBehaviour
{ 
    private AC_ProjectilePools a_ProjectilePool = null;
    public GameObject a_Orbs =null;


    private void Awake()
    {
        a_ProjectilePool = new AC_ProjectilePools(a_Orbs, 10);
    }
}
