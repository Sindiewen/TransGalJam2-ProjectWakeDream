using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    [TextArea]
    public string roomDescription;
    public string roomName;
    public Exit[] exits;
    public InteractableObject[] interactableObjects;
}

