using UnityEngine;

public class AlterarOpacidade : MonoBehaviour
{
    public Material material; // Arraste o material desejado para esta variável no Inspector
    public float novaOpacidade = 0.5f; // Defina a opacidade desejada (0 a 1)

    void Start()
    {
        // Certifique-se de que você tem um material atribuído
        if (material != null)
        {
            // Obtenha a cor atual do material
            Color corDoMaterial = material.color;

            // Defina o novo valor de opacidade (alpha)
            corDoMaterial.a = novaOpacidade;

            // Atribua a cor modificada de volta ao material
            material.color = corDoMaterial;
        }
        else
        {
            Debug.LogError("Nenhum material atribuído. Arraste um material no Inspector.");
        }
    }
}