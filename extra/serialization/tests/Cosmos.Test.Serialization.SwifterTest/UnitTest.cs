using System;
using System.IO;
using Cosmos.Serialization.Json;
using Xunit;

namespace Cosmos.Test.Serialization.SwifterTest
{
    public class UnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var model = CreateNiceModel();
            var bytes = model.ToSwifterBytes();
            var backs = bytes.FromSwifterBytes<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void NonGenericBytesTest()
        {
            var model = CreateNiceModel();
            var bytes = model.ToSwifterBytes();
            var backs = (NiceModel) bytes.FromSwifterBytes(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void StreamTest()
        {
            var model = CreateNiceModel();
            var stream1 = model.SwifterPack();
            var stream2 = new MemoryStream();
            model.SwifterPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.SwifterPackBy(model);

            var back1 = stream1.SwifterUnpack<NiceModel>();
            var back2 = stream2.SwifterUnpack<NiceModel>();
            var back3 = stream3.SwifterUnpack<NiceModel>();

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
        public void NonGenericStreamTest()
        {
            var model = CreateNiceModel();
            var stream1 = model.SwifterPack();
            var stream2 = new MemoryStream();
            model.SwifterPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.SwifterPackBy(model);

            var back1 = (NiceModel) stream1.SwifterUnpack(typeof(NiceModel));
            var back2 = (NiceModel) stream2.SwifterUnpack(typeof(NiceModel));
            var back3 = (NiceModel) stream3.SwifterUnpack(typeof(NiceModel));

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
        public void StringTest()
        {
            var model = CreateNiceModel();
            var json1 = model.ToSwifterJson();
            var back1 = json1.FromSwifterJson<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));
        }

        [Fact]
        public void NonGenericStringTest()
        {
            var model = CreateNiceModel();
            var json1 = model.ToSwifterJson();
            var back1 = (NiceModel) json1.FromSwifterJson(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));
        }
        
        private static NiceModel CreateNiceModel()
        {
            return new NiceModel
            {
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