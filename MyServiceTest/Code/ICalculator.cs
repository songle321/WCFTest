using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceTest.Code
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Deive(double a, double b);
    }
    public class Calculator : ICalculator
    {
        public double Deive(double a, double b)
        {
            return a / b;
        }
    }
}
