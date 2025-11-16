using UnityEngine;
using Unity.Netcode;

namespace K02.Board
{
    public class PlayerPiece : NetworkBehaviour
    {
        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }
    }
}