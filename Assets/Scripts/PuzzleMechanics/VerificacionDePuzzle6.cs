using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VerificacionDePuzzle6 : MonoBehaviour
{
    public List<GameObject> objetos; 
    public UnityEvent action; 

    void Update()
    {
        CheckActiveObjects();
    }

    void CheckActiveObjects()
    {
        int activeCount = 0;

        foreach (var obj in objetos)
        {
            if (obj.activeSelf)
            {
                activeCount++;
            }
        }

        if (activeCount >= 3)
        {
            action.Invoke();
        }
    }
}
