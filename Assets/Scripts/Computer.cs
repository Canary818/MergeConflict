using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] GameObject gif;

    public void ActivateGif()
    {
        gif.SetActive(true);
    }
}
