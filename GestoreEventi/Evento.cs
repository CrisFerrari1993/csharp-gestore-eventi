using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestoreEventi
{
    public class Evento
    {
        private string _titolo;
        private DateTime _data;
        private int _capienzaMassima;
        private int _numeroPostiPrenotati;

        public string Titolo 
        { 
            get 
            { 
                return _titolo; 
            } 
            set 
            { 
                if (value.Length <= 1) 
                    throw new Exception("Il titolo non può essere vuoto"); 
                _titolo = value; 
            } 
        }
        public int CapienzaMassima 
        { get 
            { 
                return _capienzaMassima; 
            } 
            private set 
            { 
                if (value <= 0) 
                    throw new Exception("La capienza dell'evento non puo essere negativa o 0"); 
                else _capienzaMassima = value; 
            } 
        }

        public string Data
        {
            get
            {
                return _data.ToString("dd/MM/yyyy");
            }
            set
            {
                if (DateTime.TryParseExact(value, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _data)) ;
                    
            }
        }
        public int NumeroPostiPrenotati 
        { 
            get 
            { 
                return _numeroPostiPrenotati; 
            } 
            private set 
            { 
                if (value < 0) 
                    throw new Exception("Il numero di posti da riservare non puo essere negativo o 0"); 
                else 
                    _numeroPostiPrenotati = value; 
            } 
        }

        public Evento(string titolo, string dataInput, int capienza)
        {
            
            Data = dataInput;
            Titolo = titolo;
            CapienzaMassima = capienza;
            NumeroPostiPrenotati = 0;
        }

        public void PrenotaPosti(int posti)
        {
            if(posti > _capienzaMassima)
            {
                throw new Exception("Non puoi prenotare più posti oltre la capienza massima");
            }
            if(_data <  DateTime.Now)
            {
                throw new Exception("Non puoi prenotare dei posti per un evento già passato");
            }
            _numeroPostiPrenotati += posti;
            _capienzaMassima -= posti;
        }
        public void DisdiciPosti(int posti)
        {
            if(posti > _numeroPostiPrenotati)
            {
                throw new Exception("Non puoi disdire più posti di quelli prenotati");
            }
            if(posti <= 0)
            {
                throw new Exception("Non puoi disdire numero di posti negativo o 0");
            }
            if(_data < DateTime.Now)
            {
                throw new Exception("Non puoi disdire dei posti per un evento già passato");
            }
            _capienzaMassima += posti;
            _numeroPostiPrenotati -= posti;
        }

        public override string ToString()
        {
            return $"{_data.ToString("dd/MM/yyyy")} - {_titolo}";
        }
        
    }
}
