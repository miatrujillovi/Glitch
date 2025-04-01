using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TransformTarget
{
    public Transform objectToMove;
    public Vector3 newObjectPosition;
}

public class NextSceneCollider : MonoBehaviour
{
    [Header("Objects to Modify")]
    public List<TransformTarget> transformTarget = new List<TransformTarget>();
    public UnityEvent actions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            foreach (TransformTarget tt in transformTarget)
            {
                if (tt.objectToMove != null)
                {
                    tt.objectToMove.position = tt.newObjectPosition;
                }
            }
            actions.Invoke();
        }
    }
}
