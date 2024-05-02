namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Gestore Eventi v1.0");
            Console.Write("Inserire il nome dell'evento: ");
            string titolo = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Inserire la data dell'evento (gg/mm/yyyy): ");
            string dataInput = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Inserire il numero di posti totali: ");
            int capienza = int.Parse(Console.ReadLine());

            Evento e = new(titolo, dataInput, capienza);
            Console.WriteLine("");
            Console.Write("Quanti posti desideri prenotare? ");
            int posti = int.Parse(Console.ReadLine());
            e.PrenotaPosti(posti);



                

 


            bool richiesta = true;
            while (richiesta)
            {
                Console.Write("Vuoi disdire dei posti (si/no)? "); 
                string useChoice = Console.ReadLine();
                if(useChoice == "si")
                {
                    try
                    {
                        Console.Write("Indicare il numero dei posti da disdire: ");
                        int postiDaDisdire = int.Parse(Console.ReadLine());
                        e.DisdiciPosti(postiDaDisdire);
                        Console.WriteLine($"Numero di posti prenotati = {e.NumeroPostiPrenotati}");
                        Console.WriteLine($"Numero di posti disponibili = {e.CapienzaMassima}");
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine(s.Message);
                    }

                }
                else if(useChoice == "no")
                {
                    Console.WriteLine("Va bene!");
                    Console.WriteLine($"Numero di posti prenotati = {e.NumeroPostiPrenotati}");
                    Console.WriteLine($"Numero di posti disponibili = {e.CapienzaMassima}");
                    richiesta =false;
                }
                
            }
        }
    }
}
