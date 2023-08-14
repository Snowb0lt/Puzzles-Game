using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalArea : MonoBehaviour
{
    public PushButton button;
    public TextMeshProUGUI buttonText;
    public Door door;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Friend")) 
        {
            door.UnlockDoor();
            buttonText.text = "UNLOCKED";
            buttonText.color = Color.green;
        }
    }
}
