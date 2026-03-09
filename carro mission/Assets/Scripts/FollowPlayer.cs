using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;     // veículo a seguir
    public Vector3 offset = new Vector3(0, 5, -10); // distância atrás e acima

    void LateUpdate()
    {
        // Segue a posição do jogador com o deslocamento
        transform.position = player.transform.position + offset;
    }
}
