using System;
using System.Threading.Tasks;
using CosmosStack.Exceptions;
using Shouldly;
using Xunit;
using Try = CosmosStack.Exceptions.Try;

namespace CosmosStandardUT.ConditionUT
{
    [Trait("ConditionUT", "Try")]
    public class TryTests
    {
        [Fact(DisplayName = "Create a try wrapper with success body test")]
        public void TryShouldBeTrueTest()
        {
            var try0 = Try.Create(() => "nice");
            var try1 = Try.CreateFromTask(async () => await Task.FromResult("nice"));
            var try2 = Try.LiftValue("nice");

            try0.ShouldNotBeNull();
            try1.ShouldNotBeNull();
            try2.ShouldNotBeNull();

            try0.IsSuccess.ShouldBeTrue();
            try1.IsSuccess.ShouldBeTrue();
            try2.IsSuccess.ShouldBeTrue();

            try0.IsFailure.ShouldBeFalse();
            try1.IsFailure.ShouldBeFalse();
            try2.IsFailure.ShouldBeFalse();

            try0.Value.ShouldBe("nice");
            try1.Value.ShouldBe("nice");
            try2.Value.ShouldBe("nice");

            try0.GetValue().ShouldBe("nice");
            try1.GetValue().ShouldBe("nice");
            try2.GetValue().ShouldBe("nice");

            try0.Exception.ShouldBeNull();
            try1.Exception.ShouldBeNull();
            try2.Exception.ShouldBeNull();

            try0.ExceptionAs<ArgumentException>().ShouldBeNull();
            try1.ExceptionAs<ArgumentException>().ShouldBeNull();
            try2.ExceptionAs<ArgumentException>().ShouldBeNull();

            try0.ExceptionAs<ArgumentNullException>().ShouldBeNull();
            try1.ExceptionAs<ArgumentNullException>().ShouldBeNull();
            try2.ExceptionAs<ArgumentNullException>().ShouldBeNull();

            try0.GetSafeValue().ShouldBe("nice");
            try0.GetSafeValue("good").ShouldBe("nice");
            try0.GetSafeValue(() => "good").ShouldBe("nice");
            try0.GetSafeValue(e => "good").ShouldBe("nice");

            try0.Deconstruct(out var v1, out var v2);
            v1.ShouldBe("nice");
            v2.ShouldBeNull();

            var tryA = try0.Recover(e => "good");
            Assert.Equal(try0, tryA);

            var tryB = Try.Create(() => "good");
            var tryC = try0.RecoverWith(e => tryB);
            Assert.Equal(try0, tryC);
            Assert.NotEqual(tryB, tryC);

            var v3 = try0.Match(val => 1, e => 2);
            v3.ShouldBe(1);

            var v4 = 0;
            try0.Tap(val => v4 = 1, e => v4 = 2);
            v4.ShouldBe(1);
        }

        [Fact(DisplayName = "Create a try wrapper with failure body test")]
        public void TryShouldBeFalseTest()
        {
            var exception = new ArgumentException();
            Func<string> errorFunc = () => throw exception;
            var try0 = Try.Create(errorFunc);
            var try1 = Try.CreateFromTask(async () => await Task.Run(errorFunc));
            var try2 = Try.LiftException<string>(exception);

            try0.ShouldNotBeNull();
            try1.ShouldNotBeNull();
            try2.ShouldNotBeNull();

            try0.IsSuccess.ShouldBeFalse();
            try1.IsSuccess.ShouldBeFalse();
            try2.IsSuccess.ShouldBeFalse();

            try0.IsFailure.ShouldBeTrue();
            try1.IsFailure.ShouldBeTrue();
            try2.IsFailure.ShouldBeTrue();

            Assert.Throws<ArgumentException>(() => try0.Value);
            Assert.Throws<ArgumentException>(() => try1.Value);
            Assert.Throws<ArgumentException>(() => try2.Value);

            Assert.Throws<ArgumentException>(() => try0.GetValue());
            Assert.Throws<ArgumentException>(() => try1.GetValue());
            Assert.Throws<ArgumentException>(() => try2.GetValue());

            try0.Exception.ShouldNotBeNull();
            try1.Exception.ShouldNotBeNull();
            try2.Exception.ShouldNotBeNull();

            try0.ExceptionAs<ArgumentException>().ShouldNotBeNull();
            try1.ExceptionAs<ArgumentException>().ShouldNotBeNull();
            try2.ExceptionAs<ArgumentException>().ShouldNotBeNull();

            try0.ExceptionAs<ArgumentNullException>().ShouldBeNull();
            try1.ExceptionAs<ArgumentNullException>().ShouldBeNull();
            try2.ExceptionAs<ArgumentNullException>().ShouldBeNull();

            try0.GetSafeValue().ShouldBeNull();
            try0.GetSafeValue("good").ShouldBe("good");
            try0.GetSafeValue(() => "good").ShouldBe("good");
            try0.GetSafeValue(e => "good").ShouldBe("good");

            try0.Deconstruct(out var v1, out var v2);
            v1.ShouldBeNull();
            v2.ShouldNotBeNull();

            var tryA = try0.Recover(e => "good");
            Assert.NotEqual(try0, tryA);

            var tryB = Try.Create(() => "good");
            var tryC = try0.RecoverWith(e => tryB);
            Assert.Equal(tryB, tryC);
            Assert.NotEqual(try0, tryC);

            var v3 = try0.Match(val => 1, e => 2);
            v3.ShouldBe(2);

            var v4 = 0;
            try0.Tap(val => v4 = 1, e => v4 = 2);
            v4.ShouldBe(2);
        }

        [Fact(DisplayName = "Try select test")]
        public void TrySelectTest()
        {
            var try0 = Try.Create(() => "nice");
            var try1 = Try.Create<string>(() => throw new ArgumentException());

            var tryA = try0.Select(val => $"{val} boat");
            var tryB = try1.Select(val => $"{val} boat");

            tryA.IsSuccess.ShouldBeTrue();
            tryB.IsFailure.ShouldBeTrue();

            tryA.Value.ShouldBe("nice boat");
            tryB.Exception.ShouldNotBeNull();

            var tryC = try0.SelectMany(val => Try.Create(() => $"{val} boat"));
            var tryD = try1.SelectMany(val => Try.Create(() => $"{val} boat"));

            tryC.IsSuccess.ShouldBeTrue();
            tryD.IsFailure.ShouldBeTrue();

            tryC.Value.ShouldBe("nice boat");
            tryD.Exception.ShouldNotBeNull();

            var tryE = try0.SelectMany(val => Try.Create(() => val.Length + 10000), (val, num) => $"{val} {num}");
            var tryF = try1.SelectMany(val => Try.Create(() => val.Length + 10000), (val, num) => $"{val} {num}");

            tryE.IsSuccess.ShouldBeTrue();
            tryF.IsFailure.ShouldBeTrue();

            tryE.Value.ShouldBe("nice 10004");
            tryF.Exception.ShouldNotBeNull();
        }

        [Fact(DisplayName = "Try where test")]
        public void TryWhereTest()
        {
            var try0 = Try.Create(() => "nice");
            var try1 = Try.Create<string>(() => throw new ArgumentException());

            var tryA = try0.Where(val => val.Length == 4);
            var tryB = try1.Where(val => val.Length == 4);

            tryA.IsSuccess.ShouldBeTrue();
            tryB.IsFailure.ShouldBeTrue();

            tryA.Value.ShouldBe("nice");
            tryB.Exception.ShouldNotBeNull();

            var tryC = try0.Where(val => val.Length == 5);
            var tryD = try1.Where(val => val.Length == 5);

            tryC.IsFailure.ShouldBeTrue();
            tryD.IsFailure.ShouldBeTrue();

            tryC.Exception.ShouldNotBeNull();
            tryD.Exception.ShouldNotBeNull();
            
            tryC.ExceptionAs<InvalidOperationException>().ShouldNotBeNull();
            tryD.ExceptionAs<ArgumentException>().ShouldNotBeNull();
        }
    }
}