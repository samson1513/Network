using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class Network
    {
        Dictionary<List<int>, List<int>> pairs;
        List<string> symbols;
        Layer layer;

        public Network()
        {
            pairs = new Dictionary<List<int>, List<int>>();
            symbols = new List<string>();
        }

        public void AddPair(List<int> input, List<int> output, string symbol)
        {
            input.Insert(0, 1);
            pairs.Add(input, output);
            symbols.Add(symbol);
            if (layer == null)
                layer = new Layer(output.Count, input.Count);
        }

        public bool Learn()
        {
            bool isLearned;
            int iteration = 0;
            do
            {
                ++iteration;
                //adjust weights
                foreach (KeyValuePair<List<int>, List<int>> pair in pairs)
                {
                    layer.adjust(pair.Key, pair.Value);
                }

                isLearned = true;
                foreach (KeyValuePair<List<int>, List<int>> pair in pairs)
                {
                    isLearned = isLearned && EqualLists(pair.Value, layer.input(pair.Key));
                }
                if (iteration == 10000)
                    return false;
            } while (!isLearned);

            return true;
        }

        private bool EqualLists(List<int> l1, List<int> l2)
        {
            for (int i = 0; i < l1.Count; i++)
                if (l1.ElementAt(i) != l2.ElementAt(i))
                    return false;

            return true;
        }

        public string Recognize(List<int> input)
        {
            input.Insert(0, 1);

            List<int> result = layer.input(input);
            for (int i = 0; i < pairs.Count; i++)
            {
                if (EqualLists(pairs.ElementAt(i).Value, result))
                    return symbols.ElementAt(i);
            }

            return "Не розпізнало";        }
    }
}
