using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsFirstPerson : MonoBehaviour {

    private static FirstPartLevelManager instance;
    public static FirstPartLevelManager Instance
    {
        get
        {
            return instance;
        }
    }
}
