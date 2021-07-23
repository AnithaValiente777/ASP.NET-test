using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancolombiaTest.Models
{
    public class Cliente
    {
		public int Id { get; set; }
		public string NitCliente { get; set; }
		public string NomCliente { get; set; }
		public string Item { get; set; }
		public string Gerenciado { get; set; }
		public string NumOficina { get; set; }
		public string Fecha_Afil { get; set; }
		public string PeriodoMed { get; set; }
		public int Condic { get; set; }
		public int CtaCamp { get; set; }
		public string CodVentas_FK { get; set; }
		public string CodSegmento_FK { get; set; }
	}
}
