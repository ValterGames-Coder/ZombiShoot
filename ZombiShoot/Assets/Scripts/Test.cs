using UnityEngine;

public class Test : MonoBehaviour
{
    public bool DoorIsOpen;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Button")) DoorIsOpen = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        DoorIsOpen = false;
    }
}
