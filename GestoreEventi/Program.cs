using System.Globalization;

namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Millestone 1 & 2
            // decommentare per fare il test

            //Console.WriteLine("Gestore Eventi v1.0");
            //Console.Write("Inserire il nome dell'evento: ");
            //string titolo = Console.ReadLine();
            //Console.WriteLine("");
            //Console.Write("Inserire la data dell'evento (gg/mm/yyyy): ");
            //string dataInput = Console.ReadLine();
            //Console.WriteLine("");
            //Console.Write("Inserire il numero di posti totali: ");
            //int capienza = int.Parse(Console.ReadLine());

            //Evento e = new(titolo, dataInput, capienza);
            //Console.WriteLine("");
            //Console.Write("Quanti posti desideri prenotare? ");
            //int posti = int.Parse(Console.ReadLine());
            //e.PrenotaPosti(posti);

            //Console.WriteLine(e.Data);
            //bool richiesta = true;
            //while (richiesta)
            //{
            //    Console.Write("Vuoi disdire dei posti (si/no)? "); 
            //    string useChoice = Console.ReadLine();
            //    if(useChoice == "si")
            //    {
            //        try
            //        {
            //            Console.Write("Indicare il numero dei posti da disdire: ");
            //            int postiDaDisdire = int.Parse(Console.ReadLine());
            //            e.DisdiciPosti(postiDaDisdire);
            //            Console.WriteLine($"Numero di posti prenotati = {e.NumeroPostiPrenotati}");
            //            Console.WriteLine($"Numero di posti disponibili = {e.CapienzaMassima}");
            //        }
            //        catch (Exception s)
            //        {
            //            Console.WriteLine(s.Message);
            //        }

            //    }
            //    else if(useChoice == "no")
            //    {
            //        Console.WriteLine("Va bene!");
            //        Console.WriteLine($"Numero di posti prenotati = {e.NumeroPostiPrenotati}");
            //        Console.WriteLine($"Numero di posti disponibili = {e.CapienzaMassima}");
            //        richiesta =false;
            //   }

            //}
            // Millestone 3 && 4
            Console.WriteLine("Gestore Eventi v1.0");
            bool programmaInFunzione = true;
            while (programmaInFunzione)
            {
                try
                {
                    Console.Write("Inserisci il nome del tuo programma Eventi: ");
                    string titolo = Console.ReadLine();
                    ProgrammaEventi programmaEventi = new(titolo);
                    Console.Write("Indica il numero di eventi da inserire: ");
                    int numeroEventi = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    for (int i = 0; i < numeroEventi; i++)
                    {
                        try
                        {
                            Console.Write($"Inserisci il nome del {i + 1}° evento: ");
                            string titoloEvento = Console.ReadLine();
                            Console.Write($"Inserisci la data dell'evento (gg/mm/yyyy): ");
                            string dataEvento = Console.ReadLine();
                            Console.Write("Inserisci il numero di posti totali: ");
                            int postiTotali = int.Parse(Console.ReadLine());
                            Console.WriteLine("");


                            Evento e = new(titoloEvento, dataEvento, postiTotali);
                            programmaEventi.AggiungiEvento(e);

                        } catch (Exception ex)
                        {
                            bool erroreCreato = true;
                            Console.WriteLine($"Errore: " + ex.Message + " all'evento:  " + (i + 1));
                            string titoloEvento = "";
                            string dataEvento = "";
                            int postiTotali = 0;
                            while (erroreCreato) 
                            {
                                Console.Write($"Inserisci il nome del {i + 1}° evento: ");
                                titoloEvento = Console.ReadLine();
                                Console.Write($"Inserisci la data dell'evento (gg/mm/yyyy): ");
                                dataEvento = Console.ReadLine();
                                Console.Write("Inserisci il numero di posti totali: ");
                                postiTotali = int.Parse(Console.ReadLine());
                                Console.WriteLine("");
                                
                                Evento e = new(titoloEvento, dataEvento, postiTotali);
                                programmaEventi.AggiungiEvento(e);
                                erroreCreato = false;

                            }


                        }
                    }

                    Console.WriteLine($"Il numero di eventi nel programma è: {programmaEventi.StampaEventi()}");
                    Console.WriteLine("Ecco il tuo programma eventi: ");
                
                    string listaEventi = programmaEventi.CostruisciStringaEventi(programmaEventi.ListaEventi);
                    Console.WriteLine(listaEventi);

                    Console.WriteLine("");
                    Console.Write("Inserisci una data per sapere che eventi ci saranno in programma(gg-mm-yyyy): ");
                    string userData = Console.ReadLine();
                    List<Evento> eventiInData = programmaEventi.EventiPresenti(userData);
                    foreach(var e in eventiInData)
                    {
                        Console.WriteLine(e.ToString());
                    }

                    programmaEventi.SvuotaLista();
                    programmaInFunzione = false;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
