using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30.0f;         // velocidade do carro
    public float turnSpeed = 50.0f;     // velocidade de viragem
    private float horizontalInput;      // entrada horizontal (setas esquerda/direita)
    private float forwardInput;         // entrada vertical (setas cima/baixo)

    void Update()
    {
        // Ler inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Movimento para a frente/trás (metros por segundo)
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Virar o carro (apenas se estiver a mover-se)
        if (forwardInput != 0)
        {
            float direction = forwardInput > 0 ? 1 : -1;
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput * direction);
        }

        // Nitro Boost (pressionar N)
        if (Input.GetKey(KeyCode.N))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (speed * 2) * forwardInput);
        }

        // Mudança de cor (pressionar C)
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }

        // Salto simples (pressionar Espaço)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(0, 1, 0);
        }

        // Aumentar/diminuir tamanho (+ / -)
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
