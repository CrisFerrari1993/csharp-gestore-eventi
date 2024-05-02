using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        public string Titolo { get; set; }

        public List<Evento> ListaEventi { get; set; }

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            ListaEventi = new();
        }

        public void AggiungiEvento(Evento e)
        {
            ListaEventi.Add(e);
        }

        public List<Evento> EventiPresenti(string data)
        {
            List<Evento> NuovaListaEventi = new();
            foreach (Evento e in ListaEventi)
            {
                if(e.Data == data)
                {
                    NuovaListaEventi.Add(e);
                }

            }
            return NuovaListaEventi;
        }

        public string CostruisciStringaEventi(List<Evento> listaEventi)
        {
            string str = $"{Titolo}{Environment.NewLine}";
            foreach(var elem in ListaEventi)
            {
                str += $"   {elem}{Environment.NewLine}";
            }
            return str ;
        }

        public void SvuotaLista()
        {
            ListaEventi.Clear();
        }

        public void StampaLista()
        {
            CostruisciStringaEventi(ListaEventi);
        }
        public int StampaEventi()
        {
            return ListaEventi.Count;
        }
    }
}
