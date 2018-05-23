using UnityEngine;
using TouchControlsKit;

public class ControlKitManager : MonoBehaviour
{
    private GameObject kisora;

    void Start()
    {
        kisora = GameObject.Find("Kisora");
    }

    void Update()
    {
        Vector2 move = TCKInput.GetAxis("Joystick0");
        Debug.Log(move);

        //kisora.SendMessage("Run", "");

        if (TCKInput.GetAction("Button0", EActionEvent.Down))
        {
            kisora.SendMessage("Attack", "");
        }

        if (TCKInput.GetAction("Button1", EActionEvent.Down))
        {
            kisora.SendMessage("Jump", "");
        }
    }
}