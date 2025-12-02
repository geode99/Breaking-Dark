using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class interactable : MonoBehaviour
{
    [Flags]
    public enum PlayerType
    {
        Wizard=1,
        Firefly=2
    }

    public UnityEvent onInteract;
    public PlayerType type;
}
