using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json;
using Jil;
using Kooboo.Json;
using Xunit;

namespace Cosmos.Test.Serializaion.KoobooTest
{
    public class JsonTestAsync
    {
        [Fact]
        public async Task BasicJsonTest()
        {
            var model = CreateNiceModel();
            var json1 = await model.ToKoobooJsonAsync();
            var back1 = await json1.FromKoobooJsonAsync<NiceModel>();
            var back2 = (NiceModel) await json1.FromKoobooJsonAsync(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back2.Id, back2.Name, back2.NiceType, back2.Count, back2.CreatedTime, back2.IsValid));
        }

        [Fact]
        public async Task OptionalJsonTest()
        {
            var model = CreateNiceModel();

            var setting1 = new JsonSerializerOption
            {
                DatetimeFormat = DatetimeFormatEnum.ISO8601,
            };

            var json1 = await model.ToKoobooJsonAsync(setting1);
            var back1 = await json1.FromKoobooJsonAsync<NiceModel>();
            var back2 = (NiceModel) await json1.FromKoobooJsonAsync(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back2.Id, back2.Name, back2.NiceType, back2.Count, back2.CreatedTime, back2.IsValid));
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