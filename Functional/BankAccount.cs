using System.Runtime.CompilerServices;
using static Functional.BankAccount;

namespace Functional;
public abstract record BankAccount
{     
    public decimal Balance { get; set; }
    public decimal InterestRate { get; set; }

    public sealed record SuperBankAccount : BankAccount
    {
        public decimal BonusIntrestRate { get; set; }
    }

    public sealed record DodgyAsFuckBankAccount : BankAccount
    {
        public decimal BrownPaperBag { get; set; }
    }
}

public static class InterestCalculator
{
    public static BankAccount CaluclateInterest(BankAccount ba) =>
        ba switch
        {
            DodgyAsFuckBankAccount dba => dba with { Balance = (dba.Balance * dba.InterestRate) + dba.BrownPaperBag },
            { Balance: <= 1000 } sba => sba with { Balance = sba.Balance * sba.InterestRate },
            SuperBankAccount sba => sba with { Balance = sba.Balance * (sba.InterestRate + sba.BonusIntrestRate) },            
            _ => throw new ArgumentOutOfRangeException()
        };  
}