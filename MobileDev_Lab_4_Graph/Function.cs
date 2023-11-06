using System.Text.Json.Serialization;

namespace MobileDev_Lab_4_Graph
{
    public class Function
    {
        [JsonInclude]
        public double StartInterval {  get; set; }

        [JsonInclude]
        public double EndInterval { get; set; }

        [JsonInclude]
        public double Step {  get; set; }

        [JsonInclude]
        public double Result {  get; set; }

        public Function(double startInterval, double endInterval, double step)
        {
            StartInterval = startInterval;
            EndInterval = endInterval;
            Step = step;
        }

        public Function()
        {
            StartInterval = 0;
            EndInterval = 0;
            Step = 0;
        }

        public double FunctionCalculate()
        {
            double y = 0, z = 0, c = 0;
            for (double i = StartInterval; i <= EndInterval; i += Step)
            {
                Result =+ (Math.Tan(Math.Pow(i, 4) - 6) - Math.Pow(Math.Cos(z + i * y), 3))
                    / (Math.Pow(Math.Cos(Math.Pow(c, 2) * Math.Pow(i, 3)), 4));
            }
            return Result;
        }
    }
}
