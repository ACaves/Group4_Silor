using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool // creates new projectiles at the start of the level
{   
    public List<T> Create<T>(GameObject prefab, int count)
        where T : MonoBehaviour
    
    {//new lists of projectile objects for the functionality of the objects
        List<T> newPool = new List<T>();
       
        for (int i = 0; i < count; i++)
        {
            GameObject projectileObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            T newProjectcile = projectileObject.GetComponent<T>();

            newPool.Add(newProjectcile);
        }

        return null;
    }





}


public class AC_ProjectilePools : Pool
{
    public List<AC_Projectiles> a_Projectile = new List<AC_Projectiles>();
    public AC_ProjectilePools(GameObject prefab, int count)
    {
        a_Projectile = Create<AC_Projectiles>(prefab, count);
    }
    public void SetAllProjectiles()
    {
        foreach (AC_Projectiles projectile in a_Projectile)
            projectile.SetInactive();
    }
}    
