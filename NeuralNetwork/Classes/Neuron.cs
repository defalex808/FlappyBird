﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Neural_Network
{
    class Neuron
    {
        public double Data { get; set; }
        public List<Sinaps> Sinapses { get; set; }

        public Neuron()
        {
            Sinapses = new List<Sinaps>();
        }

        public Neuron(Layer previousLayer) : this()
        {
            foreach (Neuron neuron in previousLayer.Neurons)
                Sinapses.Add(new Sinaps(neuron));
        }

        public Neuron(Layer previousLayer, List<double> genome) : this()
        {
            for (int i = 0; i < previousLayer.Neurons.Count; i++)
                Sinapses.Add(new Sinaps(previousLayer.Neurons[i], genome[i]));
        }

        public void Activation()
        {
            double sum = 0;
            foreach (Sinaps sinaps in Sinapses)
                sum += sinaps.GetData();
            Data = (Math.Exp(2 * sum) - 1) / (Math.Exp(2 * sum) + 1);
        }
    }
}
