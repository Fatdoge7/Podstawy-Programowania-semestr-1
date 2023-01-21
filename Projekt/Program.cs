using System;
using System.Data.SQLite;

namespace Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String cs = "Data Source=sqliteDB.db";
            using var con = new SQLiteConnection(cs);
            con.Open();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("[1] Zaloguj jaku student");
                Console.WriteLine("[2] Zaloguj jaku administrator");
                Console.WriteLine("[3] Zamknij program");
                Console.Write(": ");

                Int32 answer;
                Int32.TryParse(Console.ReadLine(), out answer);

                if (answer == 1) // student
                {
                    Console.Clear();
                    Console.WriteLine("Podaj numer albumu:");
                    Int32 login;
                    Int32.TryParse(Console.ReadLine(), out login);
                    Console.WriteLine("Podaj hasło:");
                    String haslo = Console.ReadLine();
                    String spr_haslo = "";
                    using var cmd1 = new SQLiteCommand("SELECT haslo FROM student WHERE nr_albumu =" + login, con);
                    using SQLiteDataReader reader = cmd1.ExecuteReader();
                    while (reader.Read())
                        {
                            spr_haslo = reader.GetString(0);
                            break;
                        }
                    if (spr_haslo == haslo && haslo != "")
                    {
                        Console.Clear();
                        Console.WriteLine("Zalogowano Poprawnie");
                        Console.ReadKey(true);
                        while(true)
                        {
                            Console.Clear();
                            Console.WriteLine("Menu");
                            Console.WriteLine("[1] Dane studenta");
                            Console.WriteLine("[2] Oceny");
                            Console.WriteLine("[3] Plan Zajęć");
                            Console.WriteLine("[4] Wiadomość do administratora");
                            Console.WriteLine("[5] Wyloguj");
                            Console.Write(": ");

                            Int32 answer_ucz;
                            Int32.TryParse(Console.ReadLine(), out answer_ucz);

                            if (answer_ucz == 1) // dane
                            {
                                while(true)
                                {
                                    Console.Clear();
                                    String imie = "", nazwisko = "", grupa = "";
                                    using var cmd2 = new SQLiteCommand("SELECT imie, nazwisko, grupa FROM student WHERE nr_albumu =" + login, con);
                                    using SQLiteDataReader reader2 = cmd2.ExecuteReader();
                                    while (reader2.Read())
                                    {
                                        imie = reader2.GetString(0);
                                        nazwisko = reader2.GetString(1);
                                        grupa = reader2.GetString(2);
                                        break;
                                    }
                                    Console.WriteLine("Dane:");
                                    Console.WriteLine("Imię: "+ imie);
                                    Console.WriteLine("Nazwisko: "+ nazwisko);
                                    Console.WriteLine("Grupa: " + grupa);
                                    Console.WriteLine("[1] Wyjście");
                                    Console.Write(": ");

                                    Int32 answer_ucz_dane;
                                    Int32.TryParse(Console.ReadLine(), out answer_ucz_dane);

                                    if (answer_ucz_dane == 1) // break
                                    {
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                        Console.ReadLine();
                                    }
                                }
                            }

                            else if (answer_ucz == 2) // oceny
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Int32 mat = 0, fiz = 0, inf = 0, ang = 0, elektr = 0;
                                    using var cmd3 = new SQLiteCommand("SELECT mat, fiz, inf, ang, elektr FROM student WHERE nr_albumu =" + login, con);
                                    using SQLiteDataReader reader3 = cmd3.ExecuteReader();
                                    while (reader3.Read())
                                    {
                                        mat = reader3.GetInt32(0);
                                        fiz = reader3.GetInt32(1);
                                        inf = reader3.GetInt32(2);
                                        ang = reader3.GetInt32(3);
                                        elektr = reader3.GetInt32(4);
                                        break;
                                    }
                                    Console.WriteLine("Oceny:");
                                    Console.WriteLine("Matematyka: " + mat);
                                    Console.WriteLine("Fizyka: " + fiz);
                                    Console.WriteLine("Informatyka: " + inf);
                                    Console.WriteLine("Język Angielski: " + ang);
                                    Console.WriteLine("Elektronika: " + elektr);
                                    Console.WriteLine("[1] Wyjście");
                                    Console.Write(": ");

                                    Int32 answer_ucz_oceny;
                                    Int32.TryParse(Console.ReadLine(), out answer_ucz_oceny);

                                    if (answer_ucz_oceny == 1) // break
                                    {
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                        Console.ReadLine();
                                    }
                                }
                            }

                            else if (answer_ucz == 3) // plan
                            {
                                while(true)
                                {
                                    Console.Clear();
                                    String grupa = "";
                                    using var cmd4 = new SQLiteCommand("SELECT grupa FROM student WHERE nr_albumu =" + login, con);
                                    using SQLiteDataReader reader4 = cmd4.ExecuteReader();
                                    while (reader4.Read())
                                    {
                                        grupa = reader4.GetString(0);
                                        break;
                                    }

                                    if (grupa == "inf_1")
                                    {
                                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                                        Console.WriteLine("|Lp.|Poniedziałek\t|Wtorek\t\t|Środa\t\t|Czwartek\t|Piątek\t\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|1  |Matematyka\t\t|Fizyka\t\t|Informatyka\t|J.Angielski\t|Elektronika\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|2  |Matematyka\t\t|Fizyka\t\t|Informatyka\t|J.Angielski\t|Elektronika\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|3  |Matematyka\t\t|Fizyka\t\t|Informatyka\t|J.Angielski\t|Elektronika\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|4  |Matematyka\t\t|Fizyka\t\t|Informatyka\t|J.Angielski\t|Elektronika\t|");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                                        Console.WriteLine("Grupa: "+grupa);
                                        Console.WriteLine("");
                                    }

                                    else if (grupa == "inf_2")
                                    {
                                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                                        Console.WriteLine("|Lp.|Poniedziałek\t|Wtorek\t\t|Środa\t\t|Czwartek\t|Piątek\t\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|1  |Fizyka\t\t|Matematyka\t|Elektronika\t|Informatyka\t|J.Angielski\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|2  |Fizyka\t\t|Matematyka\t|Elektronika\t|Informatyka\t|J.Angielski\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|3  |Fizyka\t\t|Matematyka\t|Elektronika\t|Informatyka\t|J.Angielski\t|");
                                        Console.WriteLine("|---------------------------------------------------------------------------------------|");
                                        Console.WriteLine("|4  |Fizyka\t\t|Matematyka\t|Elektronika\t|Informatyka\t|J.Angielski\t|");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------");
                                        Console.WriteLine("Grupa: "+grupa);
                                        Console.WriteLine("");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Brak planu");
                                    }
                                    Console.WriteLine("[1] Wyjście");
                                    Console.Write(": ");

                                    Int32 answer_ucz_plan;
                                    Int32.TryParse(Console.ReadLine(), out answer_ucz_plan);

                                    if (answer_ucz_plan == 1) //break
                                    {
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                        Console.ReadLine();
                                    }
                                }
                            }

                            else if (answer_ucz == 4) // wiadomosc
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Menu");
                                    Console.WriteLine("[1] Wyślij wiadomość do Administaratora");
                                    Console.WriteLine("[2] Zobacz wiadomości od Administartora");
                                    Console.WriteLine("[3] Wyjście");
                                    Console.Write(": ");
                                    Int32 answer_ucz_wiad;
                                    Int32.TryParse(Console.ReadLine(), out answer_ucz_wiad);
                                    if (answer_ucz_wiad == 1) // wysli do admina
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Treść wiadomości: ");
                                        String text = Console.ReadLine();
                                        using var cmd5 = new SQLiteCommand(con);
                                        cmd5.CommandText = "INSERT INTO wiad_admin (nr_albumu, tekst) VALUES (@login, @text)";
                                        cmd5.Parameters.AddWithValue("@login", login);
                                        cmd5.Parameters.AddWithValue("@text", text);
                                        cmd5.Prepare();
                                        cmd5.ExecuteNonQuery();
                                        Console.WriteLine("Wiadomość została wysłana");
                                        Console.ReadLine();
                                    }
                                    else if (answer_ucz_wiad == 2) // zobacz odadmina
                                    {
                                        Console.Clear();
                                        String text = " ";
                                        using var cmd6 = new SQLiteCommand("SELECT tekst FROM wiad_ucz WHERE EXISTS(SELECT tekst FROM wiad_ucz where nr_albumu = "+ login + ") and nr_albumu = " + login + " ORDER BY ID DESC LIMIT 1", con);
                                        using SQLiteDataReader reader5 = cmd6.ExecuteReader();
                                        while (reader5.Read())
                                        {
                                            text = reader5.GetString(0);
                                            break;
                                        }
                                        if(text != " ")
                                        {
                                            Console.WriteLine("Ostania wiadomość: ");
                                            Console.WriteLine(text);
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Brak Wiadomości");
                                            Console.ReadLine();
                                        } 
                                    }
                                    else if (answer_ucz_wiad == 3) //break
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                        Console.ReadLine();
                                    }
                                }
                            }

                            else if (answer_ucz == 5) //break
                            {
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                Console.ReadLine();
                            }

                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Błędny numer albumu lub hasło");
                        Console.ReadKey(true);
                    }

                }

                else if (answer == 2) // admin
                {
                    Console.Clear();
                    Int32 id_spr = 123;
                    String haslo_spr = "admin";
                    Console.WriteLine("Podaj identyfikator:");
                    Int32 id;
                    Int32.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine("Podaj hasło:");
                    String haslo = Console.ReadLine();
                    if (id == id_spr && haslo == haslo_spr)
                    {
                        Console.Clear();
                        Console.WriteLine("Zalogowano Poprawnie");
                        Console.ReadKey(true);
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Menu");
                            Console.WriteLine("[1] Dodaj studenta");
                            Console.WriteLine("[2] Dodaj oceny");
                            Console.WriteLine("[3] Zmiana hasła studenta");
                            Console.WriteLine("[4] Wiadomości do studentów");
                            Console.WriteLine("[5] Wyloguj");
                            Console.Write(": ");

                            Int32 answer_admin;
                            Int32.TryParse(Console.ReadLine(), out answer_admin);

                            if (answer_admin == 1) // dodaj studenta
                            {
                                Console.Clear();
                                Console.WriteLine("Dodaj Studenta: ");
                                Console.WriteLine("Podaj numer albumu Studenta:");
                                Int32 nr_alb;
                                Int32.TryParse(Console.ReadLine(), out nr_alb);
                                Console.WriteLine("Podaj hasło Studenta:");
                                String haslo_u = Console.ReadLine();
                                Console.WriteLine("Podaj imię Studenta:");
                                String imie = Console.ReadLine();
                                Console.WriteLine("Podaj nazwisko Studenta:");
                                String nazwisko = Console.ReadLine();
                                Console.WriteLine("Podaj grupę Studenta:");
                                String grupa = Console.ReadLine();
                                using var cmd11 = new SQLiteCommand(con);
                                cmd11.CommandText = "INSERT INTO student (nr_albumu, haslo, imie, nazwisko, grupa, mat, fiz, inf, ang, elektr) VALUES (@nr_alb, @haslo, @imie ,@nazwisko, @grupa, 0, 0, 0, 0, 0)";
                                cmd11.Parameters.AddWithValue("@nr_alb", nr_alb);
                                cmd11.Parameters.AddWithValue("@haslo", haslo_u); 
                                cmd11.Parameters.AddWithValue("@imie", imie);
                                cmd11.Parameters.AddWithValue("@nazwisko", nazwisko);
                                cmd11.Parameters.AddWithValue("@grupa", grupa);
                                cmd11.Prepare();
                                cmd11.ExecuteNonQuery();
                                Console.WriteLine("Student " + imie + " " + nazwisko + " dodany");
                                Console.ReadLine();
                            }

                            else if (answer_admin == 2) // dodaj oceny
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Dodaj ocenę Studenta: ");
                                    Console.WriteLine("[1] Matematyka");
                                    Console.WriteLine("[2] Fizyka");
                                    Console.WriteLine("[3] Informatyka");
                                    Console.WriteLine("[4] Język Angielski");
                                    Console.WriteLine("[5] Elektronika");
                                    Console.WriteLine("====================");
                                    Console.WriteLine("[6] Wyjście");
                                    Console.Write(": ");
                                    Int32 answer_admin_oc;
                                    Int32.TryParse(Console.ReadLine(), out answer_admin_oc);
                                    if (answer_admin_oc == 6) //break
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Podaj ocenę: ");
                                    Int32 oc;
                                    Int32.TryParse(Console.ReadLine(), out oc);
                                    Console.WriteLine("Podaj numer albumu Studenta:");
                                    Int32 nr_alb;
                                    Int32.TryParse(Console.ReadLine(), out nr_alb);
                                    Int32 spr_id = Int32.MaxValue;
                                    using var cmd12 = new SQLiteCommand("SELECT ID FROM student WHERE nr_albumu =" + nr_alb, con);
                                    using SQLiteDataReader reader11 = cmd12.ExecuteReader();
                                    while (reader11.Read())
                                    {
                                        spr_id = reader11.GetInt32(0);
                                        break;
                                    }
                                    if(spr_id == Int32.MaxValue)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Błąd! Nieistnieje dany studnet");
                                        Console.ReadKey(true);
                                        break;
                                    }
                                    String Cmd="";
                                    if (answer_admin_oc == 1)
                                    {
                                        Cmd = "UPDATE Student SET mat = "+ oc +" WHERE nr_albumu = "+ nr_alb;
                                    }
                                    else if (answer_admin_oc == 2)
                                    {
                                        Cmd = "UPDATE Student SET fiz = " + oc + " WHERE nr_albumu = " + nr_alb;
                                    }
                                    else if (answer_admin_oc == 3)
                                    {
                                        Cmd = "UPDATE Student SET inf = " + oc + " WHERE nr_albumu = " + nr_alb;
                                    }
                                    else if (answer_admin_oc == 4)
                                    {
                                        Cmd = "UPDATE Student SET ang = " + oc + " WHERE nr_albumu = " + nr_alb;
                                    }
                                    else if (answer_admin_oc == 5)
                                    {
                                        Cmd = "UPDATE Student SET elektr = " + oc + " WHERE nr_albumu = " + nr_alb;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Błąd! Wybrany zły przedmiot");
                                        Console.ReadKey(true);
                                        break;
                                    }
                                    using var cmd13 = new SQLiteCommand(con);
                                    cmd13.CommandText = Cmd;
                                    cmd13.Prepare();
                                    cmd13.ExecuteNonQuery();
                                    Console.WriteLine("Dodano ocenę "+ oc +" dla przedmiotu [" + answer_admin_oc + "] dla studneta " + nr_alb);
                                    Console.ReadKey(true);
                                }
                            }

                            else if (answer_admin == 3) // zmiana hasła
                            {
                                Console.Clear();
                                Console.WriteLine("Zmień hasło Studenta: ");
                                Console.WriteLine("Podaj numer albumu Studenta:");
                                Int32 nr_alb;
                                Int32.TryParse(Console.ReadLine(), out nr_alb);
                                Int32 spr_id = Int32.MaxValue;
                                using var cmd14 = new SQLiteCommand("SELECT ID FROM student WHERE nr_albumu =" + nr_alb, con);
                                using SQLiteDataReader reader12 = cmd14.ExecuteReader();
                                while (reader12.Read())
                                {
                                    spr_id = reader12.GetInt32(0);
                                    break;
                                }
                                if (spr_id == Int32.MaxValue)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Błąd! Nieistnieje dany studnet");
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    Console.WriteLine("Podaj nowe hasło Studenta: ");
                                    String nowe_haslo = Console.ReadLine();
                                    using var cmd13 = new SQLiteCommand(con);
                                    cmd13.CommandText = "UPDATE Student SET haslo = " + nowe_haslo + " WHERE nr_albumu = " + nr_alb;
                                    cmd13.Prepare();
                                    cmd13.ExecuteNonQuery();
                                    Console.WriteLine("Zmieniono hało Studenta " + nr_alb + " na " + nowe_haslo);
                                    Console.ReadKey(true);
                                }
                            }

                            else if (answer_admin == 4) // wiadomosci
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Menu");
                                    Console.WriteLine("[1] Wyślij wiadomość do Studenta");
                                    Console.WriteLine("[2] Zobacz wiadomości od Studenta");
                                    Console.WriteLine("[3] Wyjście");
                                    Console.Write(": ");
                                    Int32 answer_admin_wiad;
                                    Int32.TryParse(Console.ReadLine(), out answer_admin_wiad);
                                    if (answer_admin_wiad == 1) // wiadomosc do student
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Treść wiadomości: ");
                                        String text = Console.ReadLine();
                                        Console.WriteLine("Numer albumu: ");
                                        Int32 nr_alb;
                                        Int32.TryParse(Console.ReadLine(), out nr_alb);
                                        using var cmd14 = new SQLiteCommand(con);
                                        cmd14.CommandText = "INSERT INTO wiad_ucz (nr_albumu, tekst) VALUES (@login, @text)";
                                        cmd14.Parameters.AddWithValue("@login", nr_alb);
                                        cmd14.Parameters.AddWithValue("@text", text);
                                        cmd14.Prepare();
                                        cmd14.ExecuteNonQuery();
                                        Console.WriteLine("Wiadomość została wysłana");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else if (answer_admin_wiad == 2) // wiadomosc odstudent
                                    {
                                        Console.Clear();
                                        Int32 nr_alb = 0;
                                        String text = " ";
                                        using var cmd15 = new SQLiteCommand("SELECT nr_albumu, tekst FROM wiad_admin WHERE EXISTS(SELECT tekst FROM wiad_admin) ORDER BY ID DESC LIMIT 1", con);
                                        using SQLiteDataReader reader13 = cmd15.ExecuteReader();
                                        while (reader13.Read())
                                        {
                                            nr_alb = reader13.GetInt32(0);
                                            text = reader13.GetString(1);
                                            break;
                                        }
                                        if (text != " ")
                                        {
                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ostatnia Wiadomość od "+ nr_alb + ":");
                                                Console.WriteLine(text);
                                                Console.WriteLine("Menu: ");
                                                Console.WriteLine("[1] Wyślij odpowiedź do Studenta");
                                                Console.WriteLine("[2] Wyjście");
                                                Console.Write(": ");
                                                Int32 answer_admin_wiad_odp;
                                                Int32.TryParse(Console.ReadLine(), out answer_admin_wiad_odp);
                                                if (answer_admin_wiad_odp == 1) // odpowiedz
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Treść wiadomości: ");
                                                    String text2 = Console.ReadLine();
                                                    using var cmd16 = new SQLiteCommand(con);
                                                    cmd16.CommandText = "INSERT INTO wiad_ucz (nr_albumu, tekst) VALUES (@login, @text)";
                                                    cmd16.Parameters.AddWithValue("@login", nr_alb);
                                                    cmd16.Parameters.AddWithValue("@text", text2);
                                                    cmd16.Prepare();
                                                    cmd16.ExecuteNonQuery();
                                                    Console.WriteLine("Wiadomość została wysłana");
                                                    Console.ReadLine();
                                                    break;
                                                }
                                                else if (answer_admin_wiad_odp == 2) // break
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                                    Console.ReadLine();
                                                }
                                                Console.ReadLine();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Brak Wiadomości");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }
                                    else if (answer_admin_wiad == 3) //break
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                        Console.ReadLine();
                                    }
                                }
                            }

                            else if (answer_admin == 5) //break
                            {
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                                Console.ReadLine();
                            }
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Błędny indentyfikator lub hasło");
                        Console.ReadKey(true);
                    }
                }

                else if (answer == 3) //exit
                {
                    Environment.Exit(0);
                }      

                else
                {
                    Console.WriteLine("Wystąpił błąd,spróbuj ponownie");
                    Console.ReadLine();
                }
            }
        }
    }
}