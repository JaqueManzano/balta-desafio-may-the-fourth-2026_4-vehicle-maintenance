namespace AutoCareAI.Core.Models;

public class VehicleInformation
{
    /// <summary>
    /// Marca do veículo.
    /// Exemplo: Toyota, Honda, Ford.
    /// </summary>
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    /// Modelo do veículo.
    /// Exemplo: Corolla, Civic, Onix.
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// Ano de fabricação/modelo do veículo.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Motorização do veículo.
    /// Exemplo: 1.0 Turbo, 2.0 Flex.
    /// </summary>
    public string Engine { get; set; } = string.Empty;
}