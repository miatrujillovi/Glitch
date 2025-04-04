using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class VerificacionDePuzzle : MonoBehaviour
{
    [Header("Referencias")]
    public List<GameObject> ordenSecuencia; 
    private List<GameObject> secuenciaActual = new List<GameObject>();

    [Header("Accion")]
    public UnityEvent action;

    public void RegisterTrigger(GameObject triggeredObject)
    {
        secuenciaActual.Add(triggeredObject);
        CheckSequence();
    }

    private void CheckSequence()
    {
        for (int i = 0; i < secuenciaActual.Count; i++)
        {
            if (i >= ordenSecuencia.Count || secuenciaActual[i] != ordenSecuencia[i])
            {
                Debug.Log("Secuencia incorrecta. Reiniciando...");
                secuenciaActual.Clear();
                return;
            }
        }

        if (secuenciaActual.Count == ordenSecuencia.Count)
        {
            Debug.Log("¡Secuencia completada correctamente!");
            action.Invoke();
            secuenciaActual.Clear(); 
        }
    }
}
