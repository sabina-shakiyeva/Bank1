
using Bank_exception;
using System.Reflection.Metadata.Ecma335;

class Program
{

    int balance = 5000;
    int pin = 1234;
    public void showBalance()
    {
        Console.WriteLine("Balance:" + balance);
    }
    public void CashOut(int inputt)
    {

        if (balance >= inputt)
        {
            balance -= inputt;
            Console.WriteLine("Balansdan pul cekildi");
        }
        else
        {
            throw new LowBalance("Balansda kifayet qeder mebleg yoxdur!");
        }
    }
    public void CashIn(int inputt)
    {
        balance += inputt;
        Console.WriteLine("Balans artirildi!");
    }
    public void changePin(int pinn)
    {

        pin = pinn;
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        int inputBalance = 0;
        int pinn = 0;
     
        int check = 3;
        while (check >= 0)
        {
            try
            {
                int pin_input = 0;
                Console.Write("Zehmet olmasa pin-i daxil edin:");
                pin_input = int.Parse(Console.ReadLine());
                if (program.pin == pin_input)
                {
                    while (true)
                    {
                        Console.WriteLine("1) balansi goster");
                        Console.WriteLine("2)balansdan pul cixart");
                        Console.WriteLine("3)balansa pul elave et");
                        Console.WriteLine("4)Pin-i deyisdir");
                        short choice = 0;
                        Console.Write("Seciminizi daxil edin:");
                        choice = short.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            program.showBalance();
                        }
                        else if (choice == 2)
                        {

                            try
                            {
                                Console.Write("Balansi daxil edin:");
                                inputBalance = int.Parse(Console.ReadLine());
                                program.CashOut(inputBalance);
                            }
                            catch (LowBalance ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (choice == 3)
                        {
                            Console.Write("Balansi daxil edin:");
                            inputBalance = int.Parse(Console.ReadLine());
                            program.CashIn(inputBalance);
                        }
                        else if (choice == 4)
                        {
                            int oldPin = 0;
                            Console.Write("Kohne pini daxil edin:");
                            oldPin = int.Parse(Console.ReadLine());
                            if (program.pin == oldPin)
                            {
                                Console.Write("Yeni pin-i daxil edin:");
                                pinn = int.Parse(Console.ReadLine());
                                program.changePin(pinn);
                                continue;

                            }
                            else
                            {
                                throw new Exception("Kohne pin sehvdir");
                            }

                        }

                    }



                }
                else
                {
                    check--;
                    if(check>0)
                    {
                        Console.WriteLine("Yanlis pin");
                    }
                    else
                    {
                        throw new BlockedAccountException("Siz bloklandiniz!");
                    }
                }
            }
            catch(BlockedAccountException ex)
            {
                Console.WriteLine(ex.Message);
                break;
            }
          
        }
        







    }
}