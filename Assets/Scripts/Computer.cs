using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] GameObject gif;

    public void ActivateGif()
    {
        if (!gif.activeInHierarchy)
            gif.SetActive(true);
        else
            gif.SetActive(false);
    }
}
