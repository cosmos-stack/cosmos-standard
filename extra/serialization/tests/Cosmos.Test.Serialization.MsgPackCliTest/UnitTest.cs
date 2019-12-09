using System;
using System.IO;
using Cosmos.Serialization.MessagePack;
using Xunit;

namespace Cosmos.Test.Serialization.MsgPackCliTest {
    public class UnitTest {
        [Fact]
        public void BytesTest() {
            var model = CreateNiceModel();
            var bytes = model.ToMsgPack();
            var backs = bytes.FromMsgPack<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void NonGenericBytesTest() {
            var model = CreateNiceModel();
            var bytes = model.ToMsgPack();
            var backs = (NiceModel) bytes.FromMsgPack(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void StreamTest() {
            var model = CreateNiceModel();
            var stream1 = model.ToMsgPackStream();
            var stream2 = new MemoryStream();
            model.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(model);

            var back1 = stream1.Unpack<NiceModel>();
            var back2 = stream2.Unpack<NiceModel>();
            var back3 = stream3.Unpack<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back2.Id, back2.Name, back2.NiceType, back2.Count, back2.CreatedTime, back2.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back3.Id, back3.Name, back3.NiceType, back3.Count, back3.CreatedTime, back3.IsValid));
        }

        [Fact]
        public void NonGenericStreamTest() {
            var model = CreateNiceModel();
            var stream1 = model.ToMsgPackStream();
            var stream2 = new MemoryStream();
            model.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(model);

            var back1 = (NiceModel) stream1.Unpack(typeof(NiceModel));
            var back2 = (NiceModel) stream2.Unpack(typeof(NiceModel));
            var back3 = (NiceModel) stream3.Unpack(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back2.Id, back2.Name, back2.NiceType, back2.Count, back2.CreatedTime, back2.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back3.Id, back3.Name, back3.NiceType, back3.Count, back3.CreatedTime, back3.IsValid));
        }

        private static NiceModel CreateNiceModel() {
            return new NiceModel {
                Id = Guid.NewGuid(),
                Name = "nice",
                NiceType = NiceType.Yes,
                Count = new Random().Next(0, 100),
                CreatedTime = new DateTime(2019, 10, 1).ToUniversalTime(),
                IsValid = true
            };
        }
    }
}