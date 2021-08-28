using UnityEngine;

public class Resolution_Controller : MonoBehaviour
{
    public void SetResolution480p()
    {
        Screen.SetResolution(640, 480, true, 60);
    }

    public void SetResolution720p()
    {
        Screen.SetResolution(1280, 720, true, 60);
    }

    public void SetResolution1080p()
    {
        Screen.SetResolution(1920, 1080, true, 60);
    }
}
