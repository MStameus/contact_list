namespace dtp6_contacts
{
    class MainClass
    {
        static Person[] contactList = new Person[100];
        class Person
        {
            public string persname, surname, phone, address, birthdate;
        }
        public static void Main(string[] args)
        {
            string lastFileName = "address.lis";
            string[] commandLine;
            Console.WriteLine("Hello and welcome to the contact list");
            Console.WriteLine("Avaliable commands: ");
            Console.WriteLine("  load        - load contact list data from the file address.lis");
            Console.WriteLine("  load /file/ - load contact list data from the file");
            Console.WriteLine("  new        - create new person");
            Console.WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
            Console.WriteLine("  quit        - quit the program");
            Console.WriteLine("  save         - save contact list data to the file previously loaded");
            Console.WriteLine("  save /file/ - save contact list data to the file");
            Console.WriteLine();
            do
            {
                Console.Write($"> ");
                commandLine = Console.ReadLine().Split(' ');
                if (commandLine[0] == "quit")
                {
                    // NYI!
                    Console.WriteLine("Not yet implemented: safe quit");
                }
                else if (commandLine[0] == "load")
                {
                    if (commandLine.Length < 2)
                    {
                        lastFileName = "address.lis";
                        LoadFile(lastFileName);
                    }
                    else
                    {
                        lastFileName = commandLine[1];
                        LoadFile(lastFileName);
                    }
                }
                else if (commandLine[0] == "save")
                {
                    if (commandLine.Length < 2)
                    {
                        SavePerson(lastFileName);
                    }
                    else
                    {
                        // NYI!
                        Console.WriteLine("Not yet implemented: save /file/");
                    }
                }
                else if (commandLine[0] == "new")
                {
                    if (commandLine.Length < 2)
                    {
                        Console.Write("personal name: ");
                        string persname = Console.ReadLine();
                        Console.Write("surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("phone: ");
                        string phone = Console.ReadLine();
                    }
                    else
                    {
                        // NYI!
                        Console.WriteLine("Not yet implemented: new /person/");
                    }
                }
                else if (commandLine[0] == "help")
                {
                    Console.WriteLine("Avaliable commands: ");
                    Console.WriteLine("  delete       - emtpy the contact list");
                    Console.WriteLine("  delete /persname/ /surname/ - delete a person");
                    Console.WriteLine("  load        - load contact list data from the file address.lis");
                    Console.WriteLine("  load /file/ - load contact list data from the file");
                    Console.WriteLine("  new        - create new person");
                    Console.WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
                    Console.WriteLine("  quit        - quit the program");
                    Console.WriteLine("  save         - save contact list data to the file previously loaded");
                    Console.WriteLine("  save /file/ - save contact list data to the file");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{commandLine[0]}'");
                }
            } while (commandLine[0] != "quit");
        }

        private static void SavePerson(string lastFileName)
        {
            using (StreamWriter outfile = new StreamWriter(lastFileName))
            {
                foreach (Person p in contactList)
                {
                    if (p != null)
                        outfile.WriteLine($"{p.persname}|{p.surname}|{p.phone}|{p.address}|{p.birthdate}");
                }
            }
        }

        private static void LoadFile(string lastFileName)
        {
            using (StreamReader infile = new StreamReader(lastFileName))
            {
                string line;
                while ((line = infile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] attrs = line.Split('|'); // gör array för attribut på varje line i filen för att användeas till ny person p
                    Person p = new Person();
                    p.persname = attrs[0];
                    p.surname = attrs[1];
                    string[] phones = attrs[2].Split(';'); //delar upp om det finns flera telefonnummer i en egen array av nummer för varje 
                    p.phone = phones[0];  //gör index 0 i telefon arrayen till nummret i new p personen
                    string[] addresses = attrs[3].Split(';'); // gör samma med addres som telefonnummer
                    p.address = addresses[0];
                    for (int ix = 0; ix < contactList.Length; ix++)
                    {
                        if (contactList[ix] == null)        //loopar contactlist arrayen och lägger till nya objektet som skapats om index är null /bryter.
                        {
                            contactList[ix] = p;
                            break;
                        }
                    }
                }
            }
        }
    }
}
