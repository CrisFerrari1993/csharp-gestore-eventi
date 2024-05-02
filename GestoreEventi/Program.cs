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
            // Millestone 3 && 4 && bonus

            //stampo versione app
            Console.WriteLine("Gestore Eventi v1.0");
            //Setto var per controllare ciclo while
            bool programmaInFunzione = true;
            while (programmaInFunzione)
            {
                try
                {
                    //Prova di inserimento dei dati (Se errati, ritenta l'inserimento)
                    Console.Write("Inserisci il nome del tuo programma Eventi: ");
                    string titolo = Console.ReadLine();
                    ProgrammaEventi programmaEventi = new(titolo);
                    Console.Write("Indica il numero di eventi da inserire: ");
                    int numeroEventi = int.Parse(Console.ReadLine());
                    Console.WriteLine("");

                    //Ciclo per inserire gli eventi in base al numero di eventi fornito
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

                        }
                        catch (Exception ex)
                        {
                            //In caso di incoerenza dei dati, il sistema cerca di reinserirli in modo corretto facendo ricompilare i campi all'utente
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
                                //in caso di successo, esci dal ciclo
                                erroreCreato = false;

                            }


                        }
                    }
                    //stampo quanti eventi sono presenti attualmente nella lista degli eventi
                    Console.WriteLine($"Il numero di eventi nel programma è: {programmaEventi.StampaEventi()}");
                    Console.WriteLine("Ecco il tuo programma eventi: ");
                    //assegno alla variabile una funzione che ritorna una stringa di eventi concatenati al nome della Lista degli eventi e tutti gli eventi
                    string listaEventi = programmaEventi.CostruisciStringaEventi(programmaEventi.ListaEventi);
                    // stampo il risultato
                    Console.WriteLine(listaEventi);

                    Console.WriteLine("");

                    Console.Write("Inserisci una data per sapere che eventi ci saranno in programma(gg-mm-yyyy): ");
                    string userData = Console.ReadLine();
                    //creo lista che come valore contiene una lista di eventi che hanno la stessa data della ricerca
                    List<Evento> eventiInData = programmaEventi.EventiPresenti(userData);
                    // e stampo gli eventi
                    foreach (var e in eventiInData)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    //BONUS
                    Console.WriteLine("");
                    Console.WriteLine("----- BONUS -----");
                    Console.WriteLine("");
                    Console.WriteLine("Aggiungiamo anche una conferenza!");
                    try
                    {
                        Console.Write("Inserisci il nome della conferenza: ");
                        string nomeConferenza = Console.ReadLine();
                        Console.Write("Inserisci la data della conferenza (gg/mm/yyyy): ");
                        string dataConferenza = Console.ReadLine();
                        Console.Write("Inserisci il numero di posti della conferenza: ");
                        int posti = int.Parse(Console.ReadLine());
                        Console.Write("Inserisci il relatore (Nome, Cognome) della conferenza: ");
                        string nomeRelatore = Console.ReadLine();
                        Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
                        double prezzoConferenza = double.Parse(Console.ReadLine());
                        programmaEventi.AggiungiEvento(new Conferenza(nomeConferenza, dataConferenza, posti, nomeRelatore, prezzoConferenza));

                    }
                    catch (Exception e)
                    {
                        bool erroreCreato = true;
                        Console.WriteLine($"Errore: " + e.Message);
                        string nomeConferenza = "";
                        string dataConferenza = "";
                        int posti = 0;
                        string nomeRelatore = "";
                        double prezzoConferenza = 0;
                        while (erroreCreato)
                        {
                            Console.WriteLine("Errore: " + e.Message);
                            Console.Write("Inserisci il nome della conferenza: ");
                            nomeConferenza = Console.ReadLine();
                            Console.Write("Inserisci la data della conferenza (gg/mm/yyyy): ");
                            dataConferenza = Console.ReadLine();
                            Console.Write("Inserisci il numero di posti della conferenza: ");
                            posti = int.Parse(Console.ReadLine());
                            Console.Write("Inserisci il relatore (Nome, Cognome) della conferenza: ");
                            nomeRelatore = Console.ReadLine();
                            Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
                            prezzoConferenza = double.Parse(Console.ReadLine());
                            programmaEventi.AggiungiEvento(new Conferenza(nomeConferenza, dataConferenza, posti, nomeRelatore, prezzoConferenza));
                            erroreCreato = false;
                        }

                    }
                    listaEventi = programmaEventi.CostruisciStringaEventi(programmaEventi.ListaEventi);
                    Console.WriteLine(listaEventi.ToString());
                    programmaInFunzione = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Errore: " + e.Message);
                }
                
            }
        }
    }
}
