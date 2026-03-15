using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static Vector3 respawnPosition;

    public static void SetRespawn(Vector3 pos)
    {
        respawnPosition = pos;
    }
}