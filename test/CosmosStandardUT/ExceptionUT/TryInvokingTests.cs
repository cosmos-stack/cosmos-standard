using Cosmos.Exceptions;

namespace CosmosStandardUT.ExceptionUT
{
    [Trait("ExceptionUT", "TryInvokingTests")]
    public class TryInvokingTests
    {
        [Fact]
        public void InvokeAndShouldBeSuccessTest()
        {
            var @try0 = Try.Invoke(() => { });
            var @try1 = Try.Invoke<int>((_) => { }, 1);
            var @try2 = Try.Invoke<int, int>((_, _) => { }, 1, 2);
            var @try3 = Try.Invoke<int, int, int>((_, _, _) => { }, 1, 2, 3);
            var @try4 = Try.Invoke<int, int, int, int>((_, _, _, _) => { }, 1, 2, 3, 4);
            var @try5 = Try.Invoke<int, int, int, int, int>((_, _, _, _, _) => { }, 1, 2, 3, 4, 5);
            var @try6 = Try.Invoke<int, int, int, int, int, int>((_, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6);
            var @try7 = Try.Invoke<int, int, int, int, int, int, int>((_, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7);
            var @try8 = Try.Invoke<int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8);
            var @try9 = Try.Invoke<int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var @try10 = Try.Invoke<int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var @try11 = Try.Invoke<int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            var @try12 = Try.Invoke<int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            var @try13 = Try.Invoke<int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            var @try14 = Try.Invoke<int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            var @try15 = Try.Invoke<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            var @try16 = Try.Invoke<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => { }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

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
        public void InvokeAndShouldBeFailureTest()
        {
            var @try0 = Try.Invoke(FailureAct0);
            var @try1 = Try.Invoke(FailureAct1, 1);
            var @try2 = Try.Invoke(FailureAct2, 1, 2);
            var @try3 = Try.Invoke(FailureAct3, 1, 2, 3);
            var @try4 = Try.Invoke(FailureAct4, 1, 2, 3, 4);
            var @try5 = Try.Invoke(FailureAct5, 1, 2, 3, 4, 5);
            var @try6 = Try.Invoke(FailureAct6, 1, 2, 3, 4, 5, 6);
            var @try7 = Try.Invoke(FailureAct7, 1, 2, 3, 4, 5, 6, 7);
            var @try8 = Try.Invoke(FailureAct8, 1, 2, 3, 4, 5, 6, 7, 8);
            var @try9 = Try.Invoke(FailureAct9, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var @try10 = Try.Invoke(FailureAct10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var @try11 = Try.Invoke(FailureAct11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            var @try12 = Try.Invoke(FailureAct12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            var @try13 = Try.Invoke(FailureAct13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            var @try14 = Try.Invoke(FailureAct14, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            var @try15 = Try.Invoke(FailureAct15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            var @try16 = Try.Invoke(FailureAct16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

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
        public void InvokeWithCauseAndShouldBeFailureTest()
        {
            var cause = "Error!";

            var @try0 = Try.Invoke(FailureAct0, cause);
            var @try1 = Try.Invoke(FailureAct1, 1, cause);
            var @try2 = Try.Invoke(FailureAct2, 1, 2, cause);
            var @try3 = Try.Invoke(FailureAct3, 1, 2, 3, cause);
            var @try4 = Try.Invoke(FailureAct4, 1, 2, 3, 4, cause);
            var @try5 = Try.Invoke(FailureAct5, 1, 2, 3, 4, 5, cause);
            var @try6 = Try.Invoke(FailureAct6, 1, 2, 3, 4, 5, 6, cause);
            var @try7 = Try.Invoke(FailureAct7, 1, 2, 3, 4, 5, 6, 7, cause);
            var @try8 = Try.Invoke(FailureAct8, 1, 2, 3, 4, 5, 6, 7, 8, cause);
            var @try9 = Try.Invoke(FailureAct9, 1, 2, 3, 4, 5, 6, 7, 8, 9, cause);
            var @try10 = Try.Invoke(FailureAct10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, cause);
            var @try11 = Try.Invoke(FailureAct11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, cause);
            var @try12 = Try.Invoke(FailureAct12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, cause);
            var @try13 = Try.Invoke(FailureAct13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, cause);
            var @try14 = Try.Invoke(FailureAct14, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, cause);
            var @try15 = Try.Invoke(FailureAct15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, cause);
            var @try16 = Try.Invoke(FailureAct16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, cause);

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
        public void InvokeInTheFutureAndShouldBeSuccessTest()
        {
            var builder0 = Try.Future(() => { });
            var builder1 = Try.Future<int>((_) => { });
            var builder2 = Try.Future<int, int>((_, _) => { });
            var builder3 = Try.Future<int, int, int>((_, _, _) => { });
            var builder4 = Try.Future<int, int, int, int>((_, _, _, _) => { });
            var builder5 = Try.Future<int, int, int, int, int>((_, _, _, _, _) => { });
            var builder6 = Try.Future<int, int, int, int, int, int>((_, _, _, _, _, _) => { });
            var builder7 = Try.Future<int, int, int, int, int, int, int>((_, _, _, _, _, _, _) => { });
            var builder8 = Try.Future<int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _) => { });
            var builder9 = Try.Future<int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _) => { });
            var builder10 = Try.Future<int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _) => { });
            var builder11 = Try.Future<int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _) => { });
            var builder12 = Try.Future<int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _) => { });
            var builder13 = Try.Future<int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _) => { });
            var builder14 = Try.Future<int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _) => { });
            var builder15 = Try.Future<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => { });
            var builder16 = Try.Future<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => { });

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
        public void InvokeInTheFutureAndShouldBeFailureTest()
        {
            var builder0 = Try.Future(FailureAct0);
            var builder1 = Try.Future(FailureAct1);
            var builder2 = Try.Future(FailureAct2);
            var builder3 = Try.Future(FailureAct3);
            var builder4 = Try.Future(FailureAct4);
            var builder5 = Try.Future(FailureAct5);
            var builder6 = Try.Future(FailureAct6);
            var builder7 = Try.Future(FailureAct7);
            var builder8 = Try.Future(FailureAct8);
            var builder9 = Try.Future(FailureAct9);
            var builder10 = Try.Future(FailureAct10);
            var builder11 = Try.Future(FailureAct11);
            var builder12 = Try.Future(FailureAct12);
            var builder13 = Try.Future(FailureAct13);
            var builder14 = Try.Future(FailureAct14);
            var builder15 = Try.Future(FailureAct15);
            var builder16 = Try.Future(FailureAct16);

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
        public void InvokeInTheFutureWithCauseAndShouldBeFailureTest()
        {
            var cause = "Error!";

            var builder0 = Try.Future(FailureAct0);
            var builder1 = Try.Future(FailureAct1);
            var builder2 = Try.Future(FailureAct2);
            var builder3 = Try.Future(FailureAct3);
            var builder4 = Try.Future(FailureAct4);
            var builder5 = Try.Future(FailureAct5);
            var builder6 = Try.Future(FailureAct6);
            var builder7 = Try.Future(FailureAct7);
            var builder8 = Try.Future(FailureAct8);
            var builder9 = Try.Future(FailureAct9);
            var builder10 = Try.Future(FailureAct10);
            var builder11 = Try.Future(FailureAct11);
            var builder12 = Try.Future(FailureAct12);
            var builder13 = Try.Future(FailureAct13);
            var builder14 = Try.Future(FailureAct14);
            var builder15 = Try.Future(FailureAct15);
            var builder16 = Try.Future(FailureAct16);

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

        Action FailureAct0 = () => throw new ArgumentException();

        Action<int> FailureAct1 = a => throw new ArgumentException();

        Action<int, int> FailureAct2 = (a, b) => throw new ArgumentException();

        Action<int, int, int> FailureAct3 = (a, b, c) => throw new ArgumentException();

        Action<int, int, int, int> FailureAct4 = (a, b, c, d) => throw new ArgumentException();

        Action<int, int, int, int, int> FailureAct5 = (a, b, c, d, e) => throw new ArgumentException();

        Action<int, int, int, int, int, int> FailureAct6 = (a, b, c, d, e, f) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int> FailureAct7 = (a, b, c, d, e, f, g) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int> FailureAct8 = (a, b, c, d, e, f, g, h) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int> FailureAct9 = (a, b, c, d, e, f, g, h, i) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int, int> FailureAct10 = (a, b, c, d, e, f, g, h, i, j) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int, int, int> FailureAct11 = (a, b, c, d, e, f, g, h, i, j, k) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int, int, int, int> FailureAct12 = (a, b, c, d, e, f, g, h, i, j, k, l) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int, int, int, int, int> FailureAct13 = (a, b, c, d, e, f, g, h, i, j, k, l, m) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int> FailureAct14 = (a, b, c, d, e, f, g, h, i, j, k, l, m, n) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> FailureAct15 = (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => throw new ArgumentException();

        Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> FailureAct16 = (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => throw new ArgumentException();
    }
}