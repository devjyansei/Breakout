using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject breakablePrefab;
    [SerializeField] Vector2Int size;
    [SerializeField] Vector2 offset;


    [SerializeField] List<GameObject> breakables;
    public bool CheckWin()
    {
        foreach (var item in breakables)
        {
            if (item.activeSelf)
            {
                return false;
            }
            
        }

        return true;
    }


    [ContextMenu(nameof(Create))]
    void Create()   // We will adjust and use in Unity Editor
    {
        List<GameObject> breakablesList = new List<GameObject>();

        GameObject parentObj = new GameObject{ transform ={name="ParentGameObject"}}; // ? Learn this

        for (int i = 0; i < size.x; i++)
        {
            for (int k = 0; k < size.y; k++)
            {
                float x = i * offset.x;
                float y = k * offset.y;
                Vector3 spawnPosition = new Vector3(x, y, 0);

                GameObject spawnedBreakable = Instantiate(breakablePrefab, spawnPosition, Quaternion.identity);
                breakablesList.Add(spawnedBreakable);
            }
        }
        // ADJUST ORIGIN
        Vector3 origin = Vector3.zero;
        foreach (var item in breakablesList)
        {
            origin += item.transform.position;
        }
        origin /= breakablesList.Count;

        parentObj.transform.position = origin;          // parenti objelerin tam ortasýna yerlestirdik.
        foreach (var item in breakablesList)
        {
            item.transform.SetParent(parentObj.transform);
        }

        parentObj.transform.position = Vector3.zero;    // objelere ortalanmis parenti tam 0 noktasýna konumlandýrdýk.
        Debug.Log(origin);
    }
}
