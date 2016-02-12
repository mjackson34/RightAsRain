using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtil {

    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();

    //takes a prefab, position, and rotation
    public static GameObject Instantiate(GameObject prefab, Vector2 pos, Quaternion rotation)
    {
        GameObject instance = null;

        //sets the variable to be a component recyclegameobject of the object to test whether or not the object has the component
        var recycleScript = prefab.GetComponent<RecycleGameObject>();
        if (recycleScript != null)
        {
            //gets one of the already created versions of the prefab
            var pool = GetObjectPool(recycleScript);
            instance = pool.NextObject(pos).gameObject;
        }
        else
        {
            //creates a new clone of the prefab
            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
            instance.transform.rotation = rotation;
        }

        return instance;
    }

    //destroys the game ojbect
    public static void Destroy(GameObject gameObject)
    {
        var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();
        //checks to see if gameobject is null
        if (recycleGameObject != null)
        {
            recycleGameObject.Shutdown();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }

    }

    private static ObjectPool GetObjectPool(RecycleGameObject reference)
    {
        ObjectPool pool = null;

        if (pools.ContainsKey(reference))
        {
            pool = pools[reference];
        }
        else
        {
            var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = reference;
            pools.Add(reference, pool);
        }
        return pool;
    }

}
