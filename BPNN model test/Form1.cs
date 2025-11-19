using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;


namespace BPNN_model_test
{
    public partial class Form1 : Form
    {
        NeuralNet nn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Create BPNN button
        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4,1,1);
        }

        // Traint the Neural Net
        private void button2_Click(object sender, EventArgs e)
        {
            for (int epoch = 0; epoch < 1200; epoch++)
            {
                train(0.0, 0.0, 0.0, 0.0, 0.0);
                train(0.0, 0.0, 0.0, 1.0, 0.0);
                train(0.0, 0.0, 1.0, 0.0, 0.0);
                train(0.0, 0.0, 1.0, 1.0, 0.0);

                train(0.0, 1.0, 0.0, 0.0, 0.0);
                train(0.0, 1.0, 0.0, 1.0, 0.0);
                train(0.0, 1.0, 1.0, 0.0, 0.0);
                train(0.0, 1.0, 1.0, 1.0, 0.0);

                train(1.0, 0.0, 0.0, 0.0, 0.0);
                train(1.0, 0.0, 0.0, 1.0, 0.0);
                train(1.0, 0.0, 1.0, 0.0, 0.0);
                train(1.0, 0.0, 1.0, 1.0, 0.0);

                train(1.0, 1.0, 0.0, 0.0, 0.0);
                train(1.0, 1.0, 0.0, 1.0, 0.0);
                train(1.0, 1.0, 1.0, 0.0, 0.0);
                train(1.0, 1.0, 1.0, 1.0, 1.0);


            }

        }

        // Helper function
        private void train(double a, double b, double c, double d, double desiredOutput)
        {
            nn.setInputs(0, a);
            nn.setInputs(1, b);
            nn.setInputs(2, c);
            nn.setInputs(3, d);
            nn.setDesiredOutput(0, desiredOutput);
            nn.learn();
        }

        // Test Button
        private void button3_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.setInputs(2, Convert.ToDouble(textBox3.Text));
            nn.setInputs(3, Convert.ToDouble(textBox4.Text));
            nn.run();
            textBox5.Text = "" + nn.getOuputData(0);

        }
    }
}
