using UnityEngine;
using UnityEngine.UI;

namespace uOSC
{

[RequireComponent(typeof(uOscServer))]
public class ServerTest : MonoBehaviour
{

    public Text txt;

    void Start()
    {
        var server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
    }

    void OnDataReceived(Message message)
    {
        // address
        var msg = message.address + ": ";

        // timestamp
        msg += "(" + message.timestamp.ToLocalTime() + ") ";

        // values
        foreach (var value in message.values)
        {
            msg += value.GetString() + " ";
        }

        txt.text = msg;

        Debug.Log(msg);
    }
}

}