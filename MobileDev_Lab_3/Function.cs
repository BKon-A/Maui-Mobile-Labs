using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobileDev_Lab_3
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
            double G = 0, y = 0, z = 0, c = 0;
            for (double i = StartInterval; i <= EndInterval; i += Step)
            {
                Result =+ (Math.Tan(Math.Pow(i, 4) - 6) - Math.Pow(Math.Cos(z + i * y), 3))
                    / (Math.Pow(Math.Cos(Math.Pow(c, 2) * Math.Pow(i, 3)), 4));
            }
            return Result;
        }
    }
}
