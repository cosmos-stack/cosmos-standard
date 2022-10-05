using Cosmos.Exceptions;

namespace CosmosStandardUT.ExceptionUT;

[Trait("ExceptionUT", "TryCreatingValueTests")]
public class TryCreatingValueTests
{
    [Fact]
    public void CreatingValueAndShouldBeSuccessTest()
    {
        var @try0 = Try.Create(() => 1);
        var @try1 = Try.Create((a) => 1, 1);
        var @try2 = Try.Create((a, b) => 1, 1, 2);
        var @try3 = Try.Create((a, b, c) => 1, 1, 2, 3);
        var @try4 = Try.Create((a, b, c, d) => 1, 1, 2, 3, 4);
        var @try5 = Try.Create((a, b, c, d, e) => 1, 1, 2, 3, 4, 5);
        var @try6 = Try.Create((a, b, c, d, e, f) => 1, 1, 2, 3, 4, 5, 6);
        var @try7 = Try.Create((a, b, c, d, e, f, g) => 1, 1, 2, 3, 4, 5, 6, 7);
        var @try8 = Try.Create((a, b, c, d, e, f, g, h) => 1, 1, 2, 3, 4, 5, 6, 7, 8);
        var @try9 = Try.Create((a, b, c, d, e, f, g, h, i) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9);
        var @try10 = Try.Create((a, b, c, d, e, f, g, h, i, j) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var @try11 = Try.Create((a, b, c, d, e, f, g, h, i, j, k) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
        var @try12 = Try.Create((a, b, c, d, e, f, g, h, i, j, k, l) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
        var @try13 = Try.Create((a, b, c, d, e, f, g, h, i, j, k, l, m) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
        var @try14 = Try.Create((a, b, c, d, e, f, g, h, i, j, k, l, m, n) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
        var @try15 = Try.Create((a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        var @try16 = Try.Create((a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        @try0.IsSuccess.ShouldBeTrue();
        @try1.IsSuccess.ShouldBeTrue();
        @try2.IsSuccess.ShouldBeTrue();
        @try3.IsSuccess.ShouldBeTrue();
        @try4.IsSuccess.ShouldBeTrue();
        @try5.IsSuccess.ShouldBeTrue();
        @try6.IsSuccess.ShouldBeTrue();
        @try7.IsSuccess.ShouldBeTrue();
        @try8.IsSuccess.ShouldBeTrue();
        @try9.IsSuccess.ShouldBeTrue();
        @try10.IsSuccess.ShouldBeTrue();
        @try11.IsSuccess.ShouldBeTrue();
        @try12.IsSuccess.ShouldBeTrue();
        @try13.IsSuccess.ShouldBeTrue();
        @try14.IsSuccess.ShouldBeTrue();
        @try15.IsSuccess.ShouldBeTrue();
        @try16.IsSuccess.ShouldBeTrue();

        @try0.Exception.ShouldBeNull();
        @try1.Exception.ShouldBeNull();
        @try2.Exception.ShouldBeNull();
        @try3.Exception.ShouldBeNull();
        @try4.Exception.ShouldBeNull();
        @try5.Exception.ShouldBeNull();
        @try6.Exception.ShouldBeNull();
        @try7.Exception.ShouldBeNull();
        @try8.Exception.ShouldBeNull();
        @try9.Exception.ShouldBeNull();
        @try10.Exception.ShouldBeNull();
        @try11.Exception.ShouldBeNull();
        @try12.Exception.ShouldBeNull();
        @try13.Exception.ShouldBeNull();
        @try14.Exception.ShouldBeNull();
        @try15.Exception.ShouldBeNull();
        @try16.Exception.ShouldBeNull();
    }

    [Fact]
    public void CreatingValueAndShouldBeFailureTest()
    {
        var @try0 = Try.Create(FailureFunc0);
        var @try1 = Try.Create(FailureFunc1, 1);
        var @try2 = Try.Create(FailureFunc2, 1, 2);
        var @try3 = Try.Create(FailureFunc3, 1, 2, 3);
        var @try4 = Try.Create(FailureFunc4, 1, 2, 3, 4);
        var @try5 = Try.Create(FailureFunc5, 1, 2, 3, 4, 5);
        var @try6 = Try.Create(FailureFunc6, 1, 2, 3, 4, 5, 6);
        var @try7 = Try.Create(FailureFunc7, 1, 2, 3, 4, 5, 6, 7);
        var @try8 = Try.Create(FailureFunc8, 1, 2, 3, 4, 5, 6, 7, 8);
        var @try9 = Try.Create(FailureFunc9, 1, 2, 3, 4, 5, 6, 7, 8, 9);
        var @try10 = Try.Create(FailureFunc10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var @try11 = Try.Create(FailureFunc11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
        var @try12 = Try.Create(FailureFunc12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
        var @try13 = Try.Create(FailureFunc13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
        var @try14 = Try.Create(FailureFunc14, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
        var @try15 = Try.Create(FailureFunc15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        var @try16 = Try.Create(FailureFunc16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        @try0.IsSuccess.ShouldBeFalse();
        @try1.IsSuccess.ShouldBeFalse();
        @try2.IsSuccess.ShouldBeFalse();
        @try3.IsSuccess.ShouldBeFalse();
        @try4.IsSuccess.ShouldBeFalse();
        @try5.IsSuccess.ShouldBeFalse();
        @try6.IsSuccess.ShouldBeFalse();
        @try7.IsSuccess.ShouldBeFalse();
        @try8.IsSuccess.ShouldBeFalse();
        @try9.IsSuccess.ShouldBeFalse();
        @try10.IsSuccess.ShouldBeFalse();
        @try11.IsSuccess.ShouldBeFalse();
        @try12.IsSuccess.ShouldBeFalse();
        @try13.IsSuccess.ShouldBeFalse();
        @try14.IsSuccess.ShouldBeFalse();
        @try15.IsSuccess.ShouldBeFalse();
        @try16.IsSuccess.ShouldBeFalse();

        @try0.Exception.ShouldNotBeNull();
        @try1.Exception.ShouldNotBeNull();
        @try2.Exception.ShouldNotBeNull();
        @try3.Exception.ShouldNotBeNull();
        @try4.Exception.ShouldNotBeNull();
        @try5.Exception.ShouldNotBeNull();
        @try6.Exception.ShouldNotBeNull();
        @try7.Exception.ShouldNotBeNull();
        @try8.Exception.ShouldNotBeNull();
        @try9.Exception.ShouldNotBeNull();
        @try10.Exception.ShouldNotBeNull();
        @try11.Exception.ShouldNotBeNull();
        @try12.Exception.ShouldNotBeNull();
        @try13.Exception.ShouldNotBeNull();
        @try14.Exception.ShouldNotBeNull();
        @try15.Exception.ShouldNotBeNull();
        @try16.Exception.ShouldNotBeNull();
    }

    [Fact]
    public void CreatingValueWithCauseAndShouldBeFailureTest()
    {
        var cause = "Error!";

        var @try0 = Try.Create(FailureFunc0, cause);
        var @try1 = Try.Create(FailureFunc1, 1, cause);
        var @try2 = Try.Create(FailureFunc2, 1, 2, cause);
        var @try3 = Try.Create(FailureFunc3, 1, 2, 3, cause);
        var @try4 = Try.Create(FailureFunc4, 1, 2, 3, 4, cause);
        var @try5 = Try.Create(FailureFunc5, 1, 2, 3, 4, 5, cause);
        var @try6 = Try.Create(FailureFunc6, 1, 2, 3, 4, 5, 6, cause);
        var @try7 = Try.Create(FailureFunc7, 1, 2, 3, 4, 5, 6, 7, cause);
        var @try8 = Try.Create(FailureFunc8, 1, 2, 3, 4, 5, 6, 7, 8, cause);
        var @try9 = Try.Create(FailureFunc9, 1, 2, 3, 4, 5, 6, 7, 8, 9, cause);
        var @try10 = Try.Create(FailureFunc10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, cause);
        var @try11 = Try.Create(FailureFunc11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, cause);
        var @try12 = Try.Create(FailureFunc12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, cause);
        var @try13 = Try.Create(FailureFunc13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, cause);
        var @try14 = Try.Create(FailureFunc14, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, cause);
        var @try15 = Try.Create(FailureFunc15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, cause);
        var @try16 = Try.Create(FailureFunc16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, cause);

        @try0.IsSuccess.ShouldBeFalse();
        @try1.IsSuccess.ShouldBeFalse();
        @try2.IsSuccess.ShouldBeFalse();
        @try3.IsSuccess.ShouldBeFalse();
        @try4.IsSuccess.ShouldBeFalse();
        @try5.IsSuccess.ShouldBeFalse();
        @try6.IsSuccess.ShouldBeFalse();
        @try7.IsSuccess.ShouldBeFalse();
        @try8.IsSuccess.ShouldBeFalse();
        @try9.IsSuccess.ShouldBeFalse();
        @try10.IsSuccess.ShouldBeFalse();
        @try11.IsSuccess.ShouldBeFalse();
        @try12.IsSuccess.ShouldBeFalse();
        @try13.IsSuccess.ShouldBeFalse();
        @try14.IsSuccess.ShouldBeFalse();
        @try15.IsSuccess.ShouldBeFalse();
        @try16.IsSuccess.ShouldBeFalse();

        @try0.Exception.ShouldNotBeNull();
        @try1.Exception.ShouldNotBeNull();
        @try2.Exception.ShouldNotBeNull();
        @try3.Exception.ShouldNotBeNull();
        @try4.Exception.ShouldNotBeNull();
        @try5.Exception.ShouldNotBeNull();
        @try6.Exception.ShouldNotBeNull();
        @try7.Exception.ShouldNotBeNull();
        @try8.Exception.ShouldNotBeNull();
        @try9.Exception.ShouldNotBeNull();
        @try10.Exception.ShouldNotBeNull();
        @try11.Exception.ShouldNotBeNull();
        @try12.Exception.ShouldNotBeNull();
        @try13.Exception.ShouldNotBeNull();
        @try14.Exception.ShouldNotBeNull();
        @try15.Exception.ShouldNotBeNull();
        @try16.Exception.ShouldNotBeNull();

        @try0.Exception.Cause.ShouldBe("Error!");
        @try1.Exception.Cause.ShouldBe("Error!");
        @try2.Exception.Cause.ShouldBe("Error!");
        @try3.Exception.Cause.ShouldBe("Error!");
        @try4.Exception.Cause.ShouldBe("Error!");
        @try5.Exception.Cause.ShouldBe("Error!");
        @try6.Exception.Cause.ShouldBe("Error!");
        @try7.Exception.Cause.ShouldBe("Error!");
        @try8.Exception.Cause.ShouldBe("Error!");
        @try9.Exception.Cause.ShouldBe("Error!");
        @try10.Exception.Cause.ShouldBe("Error!");
        @try11.Exception.Cause.ShouldBe("Error!");
        @try12.Exception.Cause.ShouldBe("Error!");
        @try13.Exception.Cause.ShouldBe("Error!");
        @try14.Exception.Cause.ShouldBe("Error!");
        @try15.Exception.Cause.ShouldBe("Error!");
        @try16.Exception.Cause.ShouldBe("Error!");
    }

    [Fact]
    public void CreatingValueInTheFutureAndShouldBeSuccessTest()
    {
        var builder0 = Try.CreateFuture<int>(() => 1);
        var builder1 = Try.CreateFuture<int, int>((_) => 1);
        var builder2 = Try.CreateFuture<int, int, int>((_, _) => 1);
        var builder3 = Try.CreateFuture<int, int, int, int>((_, _, _) => 1);
        var builder4 = Try.CreateFuture<int, int, int, int, int>((_, _, _, _) => 1);
        var builder5 = Try.CreateFuture<int, int, int, int, int, int>((_, _, _, _, _) => 1);
        var builder6 = Try.CreateFuture<int, int, int, int, int, int, int>((_, _, _, _, _, _) => 1);
        var builder7 = Try.CreateFuture<int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _) => 1);
        var builder8 = Try.CreateFuture<int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _) => 1);
        var builder9 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _) => 1);
        var builder10 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _) => 1);
        var builder11 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _) => 1);
        var builder12 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _) => 1);
        var builder13 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _) => 1);
        var builder14 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _) => 1);
        var builder15 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => 1);
        var builder16 = Try.CreateFuture<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => 1);

        var @try0 = builder0.Invoke();
        var @try1 = builder1.Invoke(1);
        var @try2 = builder2.Invoke(1, 2);
        var @try3 = builder3.Invoke(1, 2, 3);
        var @try4 = builder4.Invoke(1, 2, 3, 4);
        var @try5 = builder5.Invoke(1, 2, 3, 4, 5);
        var @try6 = builder6.Invoke(1, 2, 3, 4, 5, 6);
        var @try7 = builder7.Invoke(1, 2, 3, 4, 5, 6, 7);
        var @try8 = builder8.Invoke(1, 2, 3, 4, 5, 6, 7, 8);
        var @try9 = builder9.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var @try10 = builder10.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var @try11 = builder11.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
        var @try12 = builder12.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
        var @try13 = builder13.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
        var @try14 = builder14.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
        var @try15 = builder15.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        var @try16 = builder16.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        @try0.IsSuccess.ShouldBeTrue();
        @try1.IsSuccess.ShouldBeTrue();
        @try2.IsSuccess.ShouldBeTrue();
        @try3.IsSuccess.ShouldBeTrue();
        @try4.IsSuccess.ShouldBeTrue();
        @try5.IsSuccess.ShouldBeTrue();
        @try6.IsSuccess.ShouldBeTrue();
        @try7.IsSuccess.ShouldBeTrue();
        @try8.IsSuccess.ShouldBeTrue();
        @try9.IsSuccess.ShouldBeTrue();
        @try10.IsSuccess.ShouldBeTrue();
        @try11.IsSuccess.ShouldBeTrue();
        @try12.IsSuccess.ShouldBeTrue();
        @try13.IsSuccess.ShouldBeTrue();
        @try14.IsSuccess.ShouldBeTrue();
        @try15.IsSuccess.ShouldBeTrue();
        @try16.IsSuccess.ShouldBeTrue();

        @try0.Exception.ShouldBeNull();
        @try1.Exception.ShouldBeNull();
        @try2.Exception.ShouldBeNull();
        @try3.Exception.ShouldBeNull();
        @try4.Exception.ShouldBeNull();
        @try5.Exception.ShouldBeNull();
        @try6.Exception.ShouldBeNull();
        @try7.Exception.ShouldBeNull();
        @try8.Exception.ShouldBeNull();
        @try9.Exception.ShouldBeNull();
        @try10.Exception.ShouldBeNull();
        @try11.Exception.ShouldBeNull();
        @try12.Exception.ShouldBeNull();
        @try13.Exception.ShouldBeNull();
        @try14.Exception.ShouldBeNull();
        @try15.Exception.ShouldBeNull();
        @try16.Exception.ShouldBeNull();
    }

    [Fact]
    public void CreatingValueInTheFutureAndShouldBeFailureTest()
    {
        var builder0 = Try.CreateFuture(FailureFunc0);
        var builder1 = Try.CreateFuture(FailureFunc1);
        var builder2 = Try.CreateFuture(FailureFunc2);
        var builder3 = Try.CreateFuture(FailureFunc3);
        var builder4 = Try.CreateFuture(FailureFunc4);
        var builder5 = Try.CreateFuture(FailureFunc5);
        var builder6 = Try.CreateFuture(FailureFunc6);
        var builder7 = Try.CreateFuture(FailureFunc7);
        var builder8 = Try.CreateFuture(FailureFunc8);
        var builder9 = Try.CreateFuture(FailureFunc9);
        var builder10 = Try.CreateFuture(FailureFunc10);
        var builder11 = Try.CreateFuture(FailureFunc11);
        var builder12 = Try.CreateFuture(FailureFunc12);
        var builder13 = Try.CreateFuture(FailureFunc13);
        var builder14 = Try.CreateFuture(FailureFunc14);
        var builder15 = Try.CreateFuture(FailureFunc15);
        var builder16 = Try.CreateFuture(FailureFunc16);

        var @try0 = builder0.Invoke();
        var @try1 = builder1.Invoke(1);
        var @try2 = builder2.Invoke(1, 2);
        var @try3 = builder3.Invoke(1, 2, 3);
        var @try4 = builder4.Invoke(1, 2, 3, 4);
        var @try5 = builder5.Invoke(1, 2, 3, 4, 5);
        var @try6 = builder6.Invoke(1, 2, 3, 4, 5, 6);
        var @try7 = builder7.Invoke(1, 2, 3, 4, 5, 6, 7);
        var @try8 = builder8.Invoke(1, 2, 3, 4, 5, 6, 7, 8);
        var @try9 = builder9.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var @try10 = builder10.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var @try11 = builder11.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
        var @try12 = builder12.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
        var @try13 = builder13.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
        var @try14 = builder14.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
        var @try15 = builder15.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        var @try16 = builder16.Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        @try0.IsSuccess.ShouldBeFalse();
        @try1.IsSuccess.ShouldBeFalse();
        @try2.IsSuccess.ShouldBeFalse();
        @try3.IsSuccess.ShouldBeFalse();
        @try4.IsSuccess.ShouldBeFalse();
        @try5.IsSuccess.ShouldBeFalse();
        @try6.IsSuccess.ShouldBeFalse();
        @try7.IsSuccess.ShouldBeFalse();
        @try8.IsSuccess.ShouldBeFalse();
        @try9.IsSuccess.ShouldBeFalse();
        @try10.IsSuccess.ShouldBeFalse();
        @try11.IsSuccess.ShouldBeFalse();
        @try12.IsSuccess.ShouldBeFalse();
        @try13.IsSuccess.ShouldBeFalse();
        @try14.IsSuccess.ShouldBeFalse();
        @try15.IsSuccess.ShouldBeFalse();
        @try16.IsSuccess.ShouldBeFalse();

        @try0.Exception.ShouldNotBeNull();
        @try1.Exception.ShouldNotBeNull();
        @try2.Exception.ShouldNotBeNull();
        @try3.Exception.ShouldNotBeNull();
        @try4.Exception.ShouldNotBeNull();
        @try5.Exception.ShouldNotBeNull();
        @try6.Exception.ShouldNotBeNull();
        @try7.Exception.ShouldNotBeNull();
        @try8.Exception.ShouldNotBeNull();
        @try9.Exception.ShouldNotBeNull();
        @try10.Exception.ShouldNotBeNull();
        @try11.Exception.ShouldNotBeNull();
        @try12.Exception.ShouldNotBeNull();
        @try13.Exception.ShouldNotBeNull();
        @try14.Exception.ShouldNotBeNull();
        @try15.Exception.ShouldNotBeNull();
        @try16.Exception.ShouldNotBeNull();
    }

    [Fact]
    public void CreatingValueInTheFutureWithCauseAndShouldBeFailureTest()
    {
        var cause = "Error!";

        var builder0 = Try.CreateFuture(FailureFunc0);
        var builder1 = Try.CreateFuture(FailureFunc1);
        var builder2 = Try.CreateFuture(FailureFunc2);
        var builder3 = Try.CreateFuture(FailureFunc3);
        var builder4 = Try.CreateFuture(FailureFunc4);
        var builder5 = Try.CreateFuture(FailureFunc5);
        var builder6 = Try.CreateFuture(FailureFunc6);
        var builder7 = Try.CreateFuture(FailureFunc7);
        var builder8 = Try.CreateFuture(FailureFunc8);
        var builder9 = Try.CreateFuture(FailureFunc9);
        var builder10 = Try.CreateFuture(FailureFunc10);
        var builder11 = Try.CreateFuture(FailureFunc11);
        var builder12 = Try.CreateFuture(FailureFunc12);
        var builder13 = Try.CreateFuture(FailureFunc13);
        var builder14 = Try.CreateFuture(FailureFunc14);
        var builder15 = Try.CreateFuture(FailureFunc15);
        var builder16 = Try.CreateFuture(FailureFunc16);

        var @try0 = builder0.WithCause(cause).Invoke();
        var @try1 = builder1.WithCause(cause).Invoke(1);
        var @try2 = builder2.WithCause(cause).Invoke(1, 2);
        var @try3 = builder3.WithCause(cause).Invoke(1, 2, 3);
        var @try4 = builder4.WithCause(cause).Invoke(1, 2, 3, 4);
        var @try5 = builder5.WithCause(cause).Invoke(1, 2, 3, 4, 5);
        var @try6 = builder6.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6);
        var @try7 = builder7.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7);
        var @try8 = builder8.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8);
        var @try9 = builder9.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var @try10 = builder10.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var @try11 = builder11.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
        var @try12 = builder12.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
        var @try13 = builder13.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
        var @try14 = builder14.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
        var @try15 = builder15.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        var @try16 = builder16.WithCause(cause).Invoke(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        @try0.IsSuccess.ShouldBeFalse();
        @try1.IsSuccess.ShouldBeFalse();
        @try2.IsSuccess.ShouldBeFalse();
        @try3.IsSuccess.ShouldBeFalse();
        @try4.IsSuccess.ShouldBeFalse();
        @try5.IsSuccess.ShouldBeFalse();
        @try6.IsSuccess.ShouldBeFalse();
        @try7.IsSuccess.ShouldBeFalse();
        @try8.IsSuccess.ShouldBeFalse();
        @try9.IsSuccess.ShouldBeFalse();
        @try10.IsSuccess.ShouldBeFalse();
        @try11.IsSuccess.ShouldBeFalse();
        @try12.IsSuccess.ShouldBeFalse();
        @try13.IsSuccess.ShouldBeFalse();
        @try14.IsSuccess.ShouldBeFalse();
        @try15.IsSuccess.ShouldBeFalse();
        @try16.IsSuccess.ShouldBeFalse();

        @try0.Exception.ShouldNotBeNull();
        @try1.Exception.ShouldNotBeNull();
        @try2.Exception.ShouldNotBeNull();
        @try3.Exception.ShouldNotBeNull();
        @try4.Exception.ShouldNotBeNull();
        @try5.Exception.ShouldNotBeNull();
        @try6.Exception.ShouldNotBeNull();
        @try7.Exception.ShouldNotBeNull();
        @try8.Exception.ShouldNotBeNull();
        @try9.Exception.ShouldNotBeNull();
        @try10.Exception.ShouldNotBeNull();
        @try11.Exception.ShouldNotBeNull();
        @try12.Exception.ShouldNotBeNull();
        @try13.Exception.ShouldNotBeNull();
        @try14.Exception.ShouldNotBeNull();
        @try15.Exception.ShouldNotBeNull();
        @try16.Exception.ShouldNotBeNull();

        @try0.Exception.Cause.ShouldBe("Error!");
        @try1.Exception.Cause.ShouldBe("Error!");
        @try2.Exception.Cause.ShouldBe("Error!");
        @try3.Exception.Cause.ShouldBe("Error!");
        @try4.Exception.Cause.ShouldBe("Error!");
        @try5.Exception.Cause.ShouldBe("Error!");
        @try6.Exception.Cause.ShouldBe("Error!");
        @try7.Exception.Cause.ShouldBe("Error!");
        @try8.Exception.Cause.ShouldBe("Error!");
        @try9.Exception.Cause.ShouldBe("Error!");
        @try10.Exception.Cause.ShouldBe("Error!");
        @try11.Exception.Cause.ShouldBe("Error!");
        @try12.Exception.Cause.ShouldBe("Error!");
        @try13.Exception.Cause.ShouldBe("Error!");
        @try14.Exception.Cause.ShouldBe("Error!");
        @try15.Exception.Cause.ShouldBe("Error!");
        @try16.Exception.Cause.ShouldBe("Error!");
    }


    Func<int> FailureFunc0 = () => throw new ArgumentException();

    Func<int, int> FailureFunc1 = a => throw new ArgumentException();

    Func<int, int, int> FailureFunc2 = (a, b) => throw new ArgumentException();

    Func<int, int, int, int> FailureFunc3 = (a, b, c) => throw new ArgumentException();

    Func<int, int, int, int, int> FailureFunc4 = (a, b, c, d) => throw new ArgumentException();

    Func<int, int, int, int, int, int> FailureFunc5 = (a, b, c, d, e) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int> FailureFunc6 = (a, b, c, d, e, f) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int> FailureFunc7 = (a, b, c, d, e, f, g) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int> FailureFunc8 = (a, b, c, d, e, f, g, h) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int> FailureFunc9 = (a, b, c, d, e, f, g, h, i) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int, int> FailureFunc10 = (a, b, c, d, e, f, g, h, i, j) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int, int, int> FailureFunc11 = (a, b, c, d, e, f, g, h, i, j, k) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int, int, int, int> FailureFunc12 = (a, b, c, d, e, f, g, h, i, j, k, l) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int> FailureFunc13 = (a, b, c, d, e, f, g, h, i, j, k, l, m) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> FailureFunc14 = (a, b, c, d, e, f, g, h, i, j, k, l, m, n) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> FailureFunc15 = (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => throw new ArgumentException();

    Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> FailureFunc16 = (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => throw new ArgumentException();
}