using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.Services
{
	public class LembreteCachedRepository
	{
		static SemaphoreSlim semaphoreSlim = new(1, 1);
		private readonly ILembreteService lembreteService;

		public LembreteCachedRepository(ILembreteService lembreteService)
		{
			this.lembreteService = lembreteService;
		}

		private static IEnumerable<Lembrete> lembretesCache = new List<Lembrete>();
		public IEnumerable<Lembrete> LembretesCache 
		{ 
			get 
			{
				return lembretesCache;
			}
			private set 
			{
				lembretesCache = value;
			}
		} 

		public async void UpdateCache() 
		{
			await semaphoreSlim.WaitAsync();
			try
			{
				LembretesCache = await lembreteService.GetLembretes();
			}
			finally { semaphoreSlim.Release(); }
		}
	}
}
