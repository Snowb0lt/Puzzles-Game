using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class TargetDoorControls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] target;
    public GameObject targetlight;
    public bool _targetDestroyed;
    [SerializeField] private Material GreenGo;
    [SerializeField] private bool isDoorOpen = false;
    public int numberOfTargets;
    public Door door;
    public PushButton button;
    public TextMeshProUGUI buttonText;
    private void Start()
    {
        numberOfTargets = target.Length;
    }
    private void Update()
    {
        CheckforTargets();
        TargetUnlockDoor();
    }

    private void TargetUnlockDoor()
    {
        if (isDoorOpen == true)
        {
            targetlight.GetComponent<Renderer>().material = GreenGo;
            door.UnlockDoor();
            buttonText.text = "UNLOCKED";
            buttonText.color = Color.green;
        }
    }

    private void CheckforTargets()
    {
        if (numberOfTargets == 0)
        {
            isDoorOpen = true;
        }
    }

    public void TargetControls()
    {
        numberOfTargets--;
    }
}
