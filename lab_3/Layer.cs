using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class Layer
    {
        public List<Neuron> neurons;

        public Layer(int countNeurons, int countInputs)
        {
            neurons = new List<Neuron>();
            for (int i = 0; i < countNeurons; i++)
            {
                neurons.Add(new Neuron(countInputs));
            }
        }

        public List<int> input(List<int> values)
        {
            List<int> results = new List<int>();
            foreach (Neuron n in neurons)
            {
                results.Add(n.Input(values));
            }
            return results;
        }

        public void adjust(List<int> inputs, List<int> expected)
        {
            for (int i = 0; i < expected.Count; i++)
            {
                neurons.ElementAt(i).AdjustWeights(inputs, expected.ElementAt(i));
            }
        }
    }
}
