using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionResponse : ScriptableObject
{
    // The required string to run action
    public string requiredString;

    public abstract bool doActionResponse(TxtAdvController controller);
	
}
