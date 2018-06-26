using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject {

    // The key word for the action
    public string Keyword;

    // Abstarct classes. Base classes to base off of
    public abstract void RespondToInput(TxtAdvController controller, string[] separatedInputWords);
	
}
