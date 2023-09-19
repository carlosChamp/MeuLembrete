using global::Microsoft.AspNetCore.Components;
using MeuLembrete.Model;

namespace MeuLembrete.Shared
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

        private bool exibeDataCompleta = true;
        private bool exibeDia = false;
        private bool exibeMes = false;
        private bool exibeDiaSemana = false;
        private bool exibeIntervaloMeses = false;

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