using System;
using System.IO;
using Cosmos.Serialization.Yaml;
using Xunit;

namespace Cosmos.Test.Serialization.YamlDotNet {
    public class UnitTest {
        [Fact]
        public void BytesTest() {
            var model = CreateNiceModel();
            var bytes = model.ToYamlBytes();
            var backs = bytes.FromYamlBytes<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void NonGenericBytesTest() {
            var model = CreateNiceModel();
            var bytes = model.ToYamlBytes();
            var backs = (NiceModel) bytes.FromYamlBytes(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void StreamTest() {
            var model = CreateNiceModel();
            var stream1 = model.YamlPack();
            var stream2 = new MemoryStream();
            model.YamlPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.YamlPackBy(model);

            var back1 = stream1.YamlUnpack<NiceModel>();
            var back2 = stream2.YamlUnpack<NiceModel>();
            var back3 = stream3.YamlUnpack<NiceModel>();

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
            var stream1 = model.YamlPack();
            var stream2 = new MemoryStream();
            model.YamlPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.YamlPackBy(model);

            var back1 = (NiceModel) stream1.YamlUnpack(typeof(NiceModel));
            var back2 = (NiceModel) stream2.YamlUnpack(typeof(NiceModel));
            var back3 = (NiceModel) stream3.YamlUnpack(typeof(NiceModel));

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
        public void StringTest() {
            var model = CreateNiceModel();
            var json1 = model.ToYaml();
            var back1 = json1.FromYaml<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));
        }

        [Fact]
        public void NonGenericStringTest() {
            var model = CreateNiceModel();
            var json1 = model.ToYaml();
            var back1 = (NiceModel) json1.FromYaml(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));
        }

        private static NiceModel CreateNiceModel() {
            return new NiceModel {
                Id = "123",
                Name = "nice",
                NiceType = NiceType.Yes,
                Count = new Random().Next(0, 100),
                CreatedTime = new DateTime(2019, 10, 1),
                IsValid = true
            };
        }
    }
}