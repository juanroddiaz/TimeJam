using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, IInputListener
{
    [SerializeField] private EntityMovement _movement = default;

    public void Subscribe()
    {
        InputController.Instance.DirPushed += OnDirPushed;
    }

    private void OnDirPushed(Direction dir)
    {
        switch(dir)
        {
            case Direction.Up:
                _movement.Move(Vector3.forward);
                break;
            case Direction.Down:
                _movement.Move(Vector3.back);
                break;
            case Direction.Left:
                _movement.Move(Vector3.left);
                break;
            case Direction.Right:
                _movement.Move(Vector3.right);
                break;
        }
    }

}
