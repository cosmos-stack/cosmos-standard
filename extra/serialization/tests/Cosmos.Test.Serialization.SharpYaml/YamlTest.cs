using System;
using Cosmos.Serialization.Yaml;
using Xunit;

namespace Cosmos.Test.Serialization.SharpYaml {
    public class YamlTest {
        [Fact]
        public void BasicYamlTest() {
            var model = CreateNiceModel();
            var json1 = model.ToSharpYaml();
            var back1 = json1.FromSharpYaml<NiceModel>();
            var back2 = (NiceModel) json1.FromSharpYaml(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back1.Id, back1.Name, back1.NiceType, back1.Count, back1.CreatedTime, back1.IsValid));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(back2.Id, back2.Name, back2.NiceType, back2.Count, back2.CreatedTime, back2.IsValid));
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