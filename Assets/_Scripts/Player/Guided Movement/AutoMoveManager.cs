using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveManager : MonoBehaviour
{
    [SerializeField] private AutoMoveSO autoMoveSO;
    [SerializeField] private bool enableAutoMove;

    //Instance
    public static AutoMoveManager Instance;

    private void Awake()
    {
        enableAutoMove = true;
        Instance = this;
    }

    public void Move()
    {
        if (enableAutoMove)
            autoMoveSO.Move(Boots.Instance);
    }
}
