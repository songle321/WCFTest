using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceTest.Code
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        double Divide(double a, double b);
        [OperationContract]
        int DivideInt(int a, int b);
    }
    public class CalculatorService : ICalculatorService
    {
        public double Divide(double a, double b)
        {
            return a / b;
        }

        public int DivideInt(int a, int b)
        {
            return a / b;
        }
    }
}
