using Microsoft.AspNetCore.Components;
using MeuLembrete.Core.Model;
using MeuLembrete.Shared.LembreteComponents;

namespace MeuLembrete.Shared.LembreteComponents
{
    public partial class ConfiguracaoAlerta
    {
        private TipoIntervalo IntervaloSelecionado
        {
            get
            {
                return Alerta.IntervaloRepeticao;
            }

            set
            {
                Alerta.IntervaloRepeticao = value;
                ocultarCamposIntervalo();
            }
        }

        protected bool exibeDataCompleta = true;
        protected bool exibeDia = false;
        protected bool exibeMes = false;
        protected bool exibeDiaSemana = false;
        protected bool exibeIntervaloMeses = false;

        private void ocultarCamposIntervalo()
        {
            exibeDataCompleta = IntervaloSelecionado == TipoIntervalo.NaoRepetir;
            exibeDia = IntervaloSelecionado == TipoIntervalo.Mensal || IntervaloSelecionado == TipoIntervalo.Meses || IntervaloSelecionado == TipoIntervalo.Anual;
            exibeMes = IntervaloSelecionado == TipoIntervalo.Anual;
            exibeIntervaloMeses = IntervaloSelecionado == TipoIntervalo.Meses;
            exibeDiaSemana = IntervaloSelecionado == TipoIntervalo.Semanal;
        }

        [Parameter]
        public Alerta Alerta { get; set; }

        protected override void OnParametersSet()
        {
            ocultarCamposIntervalo();
        }
    }
}