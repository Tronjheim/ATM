using System;

    public class cardHolder
{
    String cardNum;
    String firstName;
    String lastName;
    int pin;
    double balance;

    public cardHolder(string cardNum, string firstName, string lastName, int pin, double balance)
    {
        this.cardNum = cardNum;
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLasttName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options... ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("thank you for your $$. Your new balance is: " + currentUser.getBalance);
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("thank you!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("45327785423644", "Mike", "Smith", 1111,150.32));
        cardHolders.Add(new cardHolder("45327785423645", "Jhon", "Snow", 2222, 200));
        cardHolders.Add(new cardHolder("45327785423646", "Alice", "Jhonson", 3333, 700.77));
        cardHolders.Add(new cardHolder("45327785423647", "Joaquin", "Gonzales", 4444, 536.25));
        cardHolders.Add(new cardHolder("45327785423648", "Lionel", "Mesi", 5555, 5300));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //checking
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.Write("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.Write("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter yopur pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.Write("Incorrect pin. Please try again");
                }
            }
            catch
            {
                Console.Write("Incorrect pin. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }
            if(option == 1)
            {
                deposit(currentUser);
            }
            else if(option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if(option==4)
            { break;}
            else { option=0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! have a nice day!");
    }


}