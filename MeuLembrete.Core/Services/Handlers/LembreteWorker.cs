using MeuLembrete.Core.CalculadoraStrategy;
using MeuLembrete.Core.Model;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MeuLembrete.Core.Services.Handlers;

public class LembreteWorker :ILembreteWorker
{

	static Timer timer;
	private readonly LembreteCachedRepository lembreteCache;
	private readonly INotificationService notificationService;

	private readonly CalculadoraAlertas calculadoraAlertas;

	public LembreteWorker(LembreteCachedRepository lembreteService, 
						  INotificationService notificationService, 
						  CalculadoraAlertas calculadoraAlertas)
	{
		this.lembreteCache = lembreteService;
		this.notificationService = notificationService;
		this.calculadoraAlertas = calculadoraAlertas;
	}

	public void Setup()
	{
		if (timer != null)
			return;

		timer = new Timer()
		{
			Interval = GetInterval(),
			Enabled = false,
		};
		timer.Elapsed += TimerElapsed;
	}

	public void Start()
	{
		if (!timer.Enabled)
			timer.Start();
	}

	public void Stop()
	{
		timer.Stop();
	}

	private void SetTimerToDefault(object? sender, ElapsedEventArgs e)
	{
		timer.Interval = 60000;
	}

	public void TimerElapsed(object? sender, ElapsedEventArgs e)
	{
		SetTimerToDefault(sender, e);	
		IEnumerable<Lembrete> lembretesNoHorario = calculadoraAlertas.RetornarLembretesNaDataReferencia(lembreteCache.LembretesCache, DateTime.Now);
		if (lembretesNoHorario?.Count() == 0)
			return;

		var lembrete = lembretesNoHorario.First();

		notificationService.ShowNotification(lembrete);
	}

	static double GetInterval()
	{
		DateTime now = DateTime.Now;
		return ((60 - now.Second) * 1000 - now.Millisecond);
	}
}

