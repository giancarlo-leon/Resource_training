using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    public class ProblemLogic
    {
        private int OutputRandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 10000);
        }
        public string CreateRandomNumber(int threadNumber)
        {
            Task<int> handleCreation;
            if (threadNumber < 0) return "the number should be greater than zero...";

            handleCreation = Task.Run(() => OutputRandomNumber());
            handleCreation.Wait();

            return $"The created random number is {handleCreation.Result}";
        }
    }
}
