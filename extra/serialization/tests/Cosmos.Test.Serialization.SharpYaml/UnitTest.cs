using System;
using System.IO;
using Cosmos.Serialization.Yaml;
using Xunit;

namespace Cosmos.Test.Serialization.SharpYaml {
    public class UnitTest {
        [Fact]
        public void BytesTest() {
            var model = CreateNiceModel();
            var bytes = model.ToSharpYamlBytes();
            var backs = bytes.FromSharpYamlBytes<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void NonGenericBytesTest() {
            var model = CreateNiceModel();
            var bytes = model.ToSharpYamlBytes();
            var backs = (NiceModel) bytes.FromSharpYamlBytes(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void StreamTest() {
            var model = CreateNiceModel();
            var stream1 = model.SharpYamlPack();
            var stream2 = new MemoryStream();
            model.SharpYamlPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.SharpYamlPackBy(model);

            Assert.NotNull(stream1);
            Assert.NotNull(stream2);
            Assert.NotNull(stream3);
            Assert.True(stream1.Length > 0);
            Assert.True(stream2.Length > 0);
            Assert.True(stream3.Length > 0);

            var back1 = stream1.SharpYamlUnpack<NiceModel>();
            var back2 = stream2.SharpYamlUnpack<NiceModel>();
            var back3 = stream3.SharpYamlUnpack<NiceModel>();
            
            Assert.NotNull(back1);
            Assert.NotNull(back2);
            Assert.NotNull(back3);

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
            var stream1 = model.SharpYamlPack();
            var stream2 = new MemoryStream();
            model.SharpYamlPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.SharpYamlPackBy(model);

            var back1 = (NiceModel) stream1.SharpYamlUnpack(typeof(NiceModel));
            var back2 = (NiceModel) stream2.SharpYamlUnpack(typeof(NiceModel));
            var back3 = (NiceModel) stream3.SharpYamlUnpack(typeof(NiceModel));

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
            var json1 = model.ToSharpYaml();
            var back1 = json1.FromSharpYaml<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));
        }

        [Fact]
        public void NonGenericStringTest() {
            var model = CreateNiceModel();
            var json1 = model.ToSharpYaml();
            var back1 = (NiceModel) json1.FromSharpYaml(typeof(NiceModel));

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