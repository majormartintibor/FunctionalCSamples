using Functional;
using static Functional.BankAccount;

namespace Tests;
public class PatternMatchingTests
{

    [Fact]
    public void DodgyBankAccount()
    {
        var dba = new DodgyAsFuckBankAccount { Balance = 100, BrownPaperBag = 200, InterestRate = 2 };

        InterestCalculator.CaluclateInterest(dba)
            .Balance
            .Should().Be(400);
    }


    [Fact]
    public void SuperBankAccountWithLowBalance()
    {
        var sba = new SuperBankAccount { Balance = 100, InterestRate = 2, BonusIntrestRate = 3 };

        InterestCalculator.CaluclateInterest(sba)
            .Balance
            .Should().Be(200);
    }

    [Fact]
    public void SuperBankAccountWithShittonOfMoney()
    {
        var sba = new SuperBankAccount { Balance = 1001, InterestRate = 2, BonusIntrestRate = 3 };

        InterestCalculator.CaluclateInterest(sba)
            .Balance
            .Should().Be(5005);
    }
}
