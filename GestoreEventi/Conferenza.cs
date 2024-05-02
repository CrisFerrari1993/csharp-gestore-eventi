using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Conferenza : Evento
    {
        private string _relatore;
        private double _prezzo;
        public string Relatore
        {
            get
            {
                return _relatore;
            }
            set
            {
                if (value.Length <= 1)
                    throw new Exception("Il nome del relatore non puo essere vuoto o con un carattere");
                else
                    _relatore = value;
            }
        }
        public double Prezzo { 
            get
            { 
                return _prezzo;
            } 
            set 
            {
                if (value < 0)
                    throw new Exception("Il prezzo non può essere negativo");
                else 
                    _prezzo = value;
            } 
        }
        public Conferenza(string titolo, string dataInput, int capienza, string relatore, double prezzo) : base(titolo, dataInput, capienza)
        {
            _relatore = relatore;
            Prezzo = prezzo;
        }

        public override string ToString()
        {
            return $"{Data} - {Titolo} - {Relatore} - {Prezzo.ToString("0.00")} euro"; ;
        }
    }
}
