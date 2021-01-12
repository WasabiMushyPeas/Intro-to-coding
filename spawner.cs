using UnityEngine;

public class spawner : MonoBehaviour
{
    private GameObject blackHole;

    private void Awake()
    {
        blackHole = (GameObject) Resources.Load("Assets/Prefabs/Black-Hole-Parent", typeof(GameObject));
    }

    private void Start()
    {
        Instantiate(blackHole, transform);
    }

}