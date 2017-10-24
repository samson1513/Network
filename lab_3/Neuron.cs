using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class Neuron
    {
        public int[] weights;

        public Neuron(int count)
        {
            weights = new int[count];
            for (int i = 0; i < weights.Count(); i++)
            {
                weights[i] = 0;
            }
        }

        public void AdjustWeights(List<int> input, int output)
        {
            for (int i = 0; i < weights.Count(); i++)
            {
                weights[i] += input.ElementAt(i) * output;
            }
        }

        public int Input(List<int> inputs)
        {
            int sum = 0;
            for (int i = 0; i < weights.Count(); i++)
            {
                sum += weights[i] * inputs.ElementAt(i);
            }
            return Math.Sign(sum);
        }
    }
}
