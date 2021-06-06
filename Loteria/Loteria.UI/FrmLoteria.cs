using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loteria.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void CalculaSorteios(List<int> numerosJogados)
        {
            int sorteio = 1;

            int arcertou1 = 1;
            int arcertou2 = 1;
            int arcertou3 = 1;
            int arcertou4 = 1;
            int arcertou5 = 1;
            bool arcertou6 = false;


            List<int> numerosSorteados = new List<int>();

            while (!arcertou6)
            {

                Random r = new Random();

                for(int i=0;i<6;i++)
                {
                    int num = r.Next(1, 60);
                    if (!numerosSorteados.Contains(num))
                        numerosSorteados.Add(num);
                    else
                        i--;
                }

                IEnumerable<int> acertos = numerosJogados.Intersect(numerosSorteados);

                if (arcertou1 == 1 && acertos.Count() == 1)
                    arcertou1 = sorteio;

                if (arcertou2 == 1 && acertos.Count() == 2)
                    arcertou2 = sorteio;

                if (arcertou3 == 1 && acertos.Count() == 3)
                    arcertou3 = sorteio;

                if (arcertou4 == 1 && acertos.Count() == 4)
                    arcertou4 = sorteio;

                if (arcertou5 == 1 && acertos.Count() == 5)
                    arcertou5 = sorteio;


                if (acertos.Count() == 6)
                {
                    arcertou6 = true;
                    TxtSorteios.Text = sorteio.ToString();
                    Application.DoEvents();
                }
                else
                {
                    sorteio++;
                    numerosSorteados = new List<int>();
                }
            }
        }

        private void CmdCalcular_Click(object sender, EventArgs e)
        {
            List<int> numeros = new List<int>() { 7, 12, 33, 44, 35, 6, 15,21 };

            CalculaSorteios(numeros);
        }
    }
}
