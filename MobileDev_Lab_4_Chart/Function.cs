using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MobileDev_Lab_4_Chart
{
    public class Function
    {
        public double XRatio { get; set; }
        public double StartInterval { get; set; }
        public double EndInterval { get; set; }
        public double Step { get; set; }
        public double Result { get; set; }

        public Function(double startInterval, double endInterval, double step)
        {
            StartInterval = startInterval;
            EndInterval = endInterval;
            Step = step;
        }
        public Function(double xRatio,double startInterval, double endInterval, double step)
        {
            XRatio = xRatio;
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
        public Function(Function function)
        {
            XRatio = function.XRatio;
            StartInterval = function.StartInterval;
            EndInterval = function.EndInterval;
            Step = function.Step;
            Result = function.Result;
        }

        public double FunctionCalculate()
        {
            double y = 0, z = 0, c = 0;
            for (double i = StartInterval; i <= EndInterval; i += Step)
            {
                Result += (Math.Tan(Math.Pow(XRatio, 4) - 6) - Math.Pow(Math.Cos(z + XRatio * y), 3))
                    / (Math.Pow(Math.Cos(Math.Pow(c, 2) * Math.Pow(XRatio, 3)), 4));
            }
            return Result;
        }
        public override string ToString()
        {
            return $"XRatio: {XRatio}\nStartInterval: {StartInterval}\nEndInterval: {EndInterval}\nStep: {Step}\nResult: {Result}";
        }
    }

    public static class Reciever
    {
        public static Function staticFunction { get; set; }

    }
}
