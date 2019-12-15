using System;
using Cosmos.Serialization.Json;
using Jil;
using Xunit;

namespace Cosmos.Test.Serialization.JilTest {
    public class JsonTest {
        [Fact]
        public void BasicJsonTest() {
            var model = CreateNiceModel();
            var json1 = model.ToJil();
            var back1 = json1.FromJil<NiceModel>();
            var back2 = (NiceModel) json1.FromJil(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back2.Id, back2.Name, back2.NiceType, back2.Count, back2.CreatedTime, back2.IsValid));
        }

        [Fact]
        public void OptionalJsonTest() {
            var model = CreateNiceModel();

            var options = new Options(dateFormat: DateTimeFormat.ISO8601,
                excludeNulls: true, includeInherited: true,
                serializationNameFormat: SerializationNameFormat.CamelCase);

            var json1 = model.ToJil(options);
            var back1 = json1.FromJil<NiceModel>(options);
            var back2 = (NiceModel) json1.FromJil(typeof(NiceModel), options);

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back2.Id, back2.Name, back2.NiceType, back2.Count, back2.CreatedTime, back2.IsValid));
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