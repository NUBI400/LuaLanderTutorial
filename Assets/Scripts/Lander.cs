using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour {
   private void Update()
    {
       if (Keyboard.current.upArrowKey.isPressed)
        {
            Debug.Log("FOIIII");
        }
        
    }
}
