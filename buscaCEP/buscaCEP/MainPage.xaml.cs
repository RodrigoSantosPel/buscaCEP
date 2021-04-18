using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using buscaCEP.Servico.Modelo;
using buscaCEP.Servico;

namespace buscaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;

        }
        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
         
            if(isValidCEP(cep))
            { 
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3}, {0}-{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }

                    
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
                
            }
            
        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            
            if(cep.Length!= 8)
            {
                //ERRO
                DisplayAlert("ERRO", "CEP Invalido!  O CEP DEVE CONTER 8 CARACTERES", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                //ERRO
                DisplayAlert("ERRO", "CEP Invalido!  O CEP DEVE CONTER APENAS NÚMEROS E SEM CARACTERES ESPECIAIS", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
