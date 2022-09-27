using Cosmos.Date;
using Cosmos.Validation;

namespace CosmosStandardUT.DateTimeUT;

[Trait("DateTimeUT", "DateGuard")]
public class DateGuardTests
{
    [Fact(DisplayName = "Valid date test")]
    public void ValidDateTest()
    {
        var date1 = DateTime.Now;
        DateTime? date2 = date1;
        DateGuard.ShouldBeValid(date1, "date1");
        DateGuard.ShouldBeValid(date2, "date2");
    }
        
    [Fact(DisplayName = "Date should be in the past test")]
    public void DateInThePastTest()
    {
        var date1 = DateTime.Now;
        DateTime? date2 = date1.AddDays(-1);
        DateTime? date3 = date1.AddDays(1);
            
        DateGuard.ShouldBeInThePast(date1.AddDays(-1),"date1");
        Assert.Throws<ValidationException>(() => DateGuard.ShouldBeInThePast(date1.AddDays(1), "date1"));
        DateGuard.ShouldBeInThePast(date2,"date2");
        Assert.Throws<ValidationException>(() => DateGuard.ShouldBeInThePast(date3, "date3"));
    }
        
    [Fact(DisplayName = "Date should be in the future test")]
    public void DateInTheFutureTest()
    {
        var date1 = DateTime.Now;
        DateTime? date2 = date1.AddDays(-1);
        DateTime? date3 = date1.AddDays(1);
            
        DateGuard.ShouldBeInTheFuture(date1.AddDays(1),"date1");
        Assert.Throws<ValidationException>(() => DateGuard.ShouldBeInTheFuture(date1.AddDays(-1), "date1"));
        DateGuard.ShouldBeInTheFuture(date3,"date3");
        Assert.Throws<ValidationException>(() => DateGuard.ShouldBeInTheFuture(date2, "date2"));
    }

}