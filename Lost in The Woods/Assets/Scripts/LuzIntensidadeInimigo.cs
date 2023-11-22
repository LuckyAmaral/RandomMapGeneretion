using UnityEngine;

public class LuzIntensidadeInimigo : MonoBehaviour
{
    public Transform inimigo;  // Referência ao objeto do inimigo
    public float intensidadeMinima = 1.0f;  // Intensidade mínima da luz
    public float intensidadeMaxima = 5.0f;  // Intensidade máxima da luz
    public float distanciaMaxima = 10.0f;   // Distância máxima para atingir a intensidade máxima
    private Light luz;

    void Start()
    {
        luz = GetComponent<Light>();
    }

    void Update()
    {
        if (inimigo == null)
            return;

        // Calcula a distância entre a luz e o inimigo
        float distancia = Vector3.Distance(transform.position, inimigo.position);

        // Calcula a intensidade com base na distância
        float intensidade = Mathf.Lerp(intensidadeMaxima, intensidadeMinima, distancia / distanciaMaxima);

        // Define a intensidade da luz
        luz.intensity = intensidade;
    }
}