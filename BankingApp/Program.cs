class Account
{

    private double _balance;

    protected double Balance
    {
        get
        {
            return this._balance;
        }

        // Check before setting the balance
        set
        {
            if (value >= 0)
                this._balance = value;
        }
    }

    // Constructor
    public Account(double balance)
    {
        this.Balance = balance;
    }

    //Virtual Methods
    public virtual bool Deposit(double amount)
    {

        return false;
    }

    public virtual bool Withdraw(double amount)
    {

        return false;
    }

    public virtual void PrintBalance()
    {

        Console.WriteLine("The balance is: " + Balance);
    }

}

class SavingsAccount : Account
{

    private double _interestRate;

    // Constructor
    public SavingsAccount(double balance)
        : base(balance)
    {
        // It's always preferable to initialize fields inside a constructor
        this._interestRate = 0.8;
    }

    // Overridden Methods
    public override bool Deposit(double amount)
    {
        if (amount > 0)
        {
            // Check if amount is non-zero and non-negative
            // Adding to balance with interest rate
            Balance += amount + (amount * this._interestRate);
            return true;
        }
        return false;
    }


    public override bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            // Check if amount is non-zero and less than equal to balance
            // Deducting from balance with interest rate
            Balance -= amount + (amount * this._interestRate);
            return true;
        }
        return false;
    }


    public override void PrintBalance()
    {
        Console.WriteLine("The saving account balance is: " + base.Balance);
    }

}

class CheckingAccount : Account
{
    // Constructor
    public CheckingAccount(double balance)
        : base(balance) { }

    // Overridden Methods
    public override bool Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            return true;
        }
        return false;
    }


    public override bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }


    public override void PrintBalance()
    {

        Console.WriteLine("The checking account balance is: " + base.Balance);
    }

}

class Demo
{

    public static void Main(string[] args)
    {

        Account SAccount = new SavingsAccount(5000);

        // Creating saving account object
        SAccount.Deposit(1000);
        SAccount.PrintBalance();

        SAccount.Withdraw(3000);
        SAccount.PrintBalance();

        Console.WriteLine();

        // Creating checking account object
        Account CAccount = new CheckingAccount(5000);
        CAccount.Deposit(1000);
        CAccount.PrintBalance();

        CAccount.Withdraw(3000);
        CAccount.PrintBalance();

    }

}