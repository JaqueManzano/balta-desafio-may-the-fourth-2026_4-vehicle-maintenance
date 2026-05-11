namespace AutoCareAI.Core.Models
{
    public class VehicleTelemetryRecord
    {
        /// <summary>
        /// Data em que os dados do veículo foram coletados.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Quilometragem atual do veículo em quilômetros.
        /// Utilizado para prever revisões, troca de óleo e desgaste geral.
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// Consumo médio de combustível do veículo.
        /// Exemplo: km por litro.
        /// Pode indicar problemas mecânicos quando o consumo piora.
        /// </summary>
        public decimal FuelConsumption { get; set; }

        /// <summary>
        /// Pressão média dos pneus em PSI.
        /// Utilizado para identificar necessidade de calibragem ou desgaste irregular.
        /// </summary>
        public decimal TirePressure { get; set; }

        /// <summary>
        /// Percentual restante da vida útil do óleo do motor.
        /// Exemplo:
        /// 100 = óleo novo
        /// 0 = troca urgente
        /// </summary>
        public decimal OilLifePercentage { get; set; }

        /// <summary>
        /// Indica se a luz de alerta do motor está acesa.
        /// Pode representar falhas mecânicas ou necessidade de manutenção.
        /// </summary>
        public bool EngineWarningLight { get; set; }

        /// <summary>
        /// Voltagem atual da bateria do veículo.
        /// Utilizado para prever falhas ou necessidade de substituição da bateria.
        /// </summary>
        public decimal BatteryVoltage { get; set; }

        /// <summary>
        /// Percentual estimado de desgaste das pastilhas de freio.
        /// Exemplo:
        /// 0 = novas
        /// 100 = totalmente desgastadas
        /// </summary>
        public decimal BrakePadWearPercentage { get; set; }
    }
}
