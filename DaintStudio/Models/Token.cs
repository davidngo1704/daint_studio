
namespace DaintStudio.Models;

public class EmbeddingVector
{
    public string Token { get; set; } = "";
    public float[]? Values { get; set; }
    public int Dimensions { get; set; }
}
