using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.Serialization.ProtoBuf;
using ProtoBuf.Meta;
using Xunit;

namespace Cosmos.Test.Serialization.ProtobufTest
{
    public class UnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var model = CreateNiceModel();
            var bytes = model.ToProtoBytes();
            var backs = bytes.FromProtoBytes<NiceModel>();

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void NonGenericBytesTest()
        {
            var model = CreateNiceModel();
            var bytes = model.ToProtoBytes();
            var backs = (NiceModel) bytes.FromProtoBytes(typeof(NiceModel));

            Assert.Equal(
                Tuple.Create(model.Id, model.Name, model.NiceType, model.Count, model.CreatedTime, model.IsValid),
                Tuple.Create(backs.Id, backs.Name, backs.NiceType, backs.Count, backs.CreatedTime, backs.IsValid));
        }

        [Fact]
        public void StreamTest()
        {
            var model = CreateNiceModel();
            var stream1 = model.ToProtoStream();
            var stream2 = new MemoryStream();
            model.ProtoPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.ProtoPackBy(model);

            var back1 = stream1.ProtoUnpack<NiceModel>();
            var back2 = stream2.ProtoUnpack<NiceModel>();
            var back3 = stream3.ProtoUnpack<NiceModel>();

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
            var stream1 = model.ToProtoStream();
            var stream2 = new MemoryStream();
            model.ProtoPackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.ProtoPackBy(model);

            var back1 = (NiceModel) stream1.ProtoUnpack(typeof(NiceModel));
            var back2 = (NiceModel) stream2.ProtoUnpack(typeof(NiceModel));
            var back3 = (NiceModel) stream3.ProtoUnpack(typeof(NiceModel));

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

        private static NiceModel CreateNiceModel()
        {
            return new NiceModel
            {
                Id = Guid.NewGuid(),
                Name = "nice",
                NiceType = NiceType.Yes,
                Count = new Random().Next(0, 100),
                CreatedTime = new DateTime(2019, 10, 1),
                IsValid = true
            };
        }

        [Fact]
        public void SerializerBuilderTest()
        {
            var model = CreateNiceModel2();

            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            SerializerBuilder.Build<SubModel>(typeModel);

            var ms = new MemoryStream();
            typeModel.Serialize(ms, model);
            var bytes = ms.ToArray();

            var backs = (SubModel) typeModel.Deserialize(new MemoryStream(bytes), null, typeof(SubModel));

            Assert.Equal(backs.Id, model.Id);
            Assert.Equal(backs.Name, model.Name);
            Assert.Equal(backs.NiceType, model.NiceType);
            Assert.Equal(backs.Count, model.Count);
            Assert.Equal(backs.CreatedTime, model.CreatedTime);
            Assert.Equal(backs.IsValid, model.IsValid);
            Assert.Equal(backs.Kids.Count, model.Kids.Count);
            Assert.True(backs.Kids.Keys.All(p => model.Kids.Keys.Any(q => q == p)));
            Assert.True(backs.Kids.Values.All(p => model.Kids.Values.Any(q =>
                q.Id == p.Id && q.Name == p.Name && q.CreatedTime == p.CreatedTime && q.Count == p.Count &&
                q.NiceType == p.NiceType && q.IsValid == p.IsValid)));
        }

        private static SubModel CreateNiceModel2()
        {
            return new SubModel
            {
                Id = Guid.NewGuid(),
                Name = "nice",
                NiceType = NiceType.Yes,
                Count = new Random().Next(0, 100),
                CreatedTime = new DateTime(2019, 10, 1).ToUniversalTime(),
                Kids = new Dictionary<Guid, NiceModel2>
                {
                    {
                        Guid.NewGuid(),
                        new SubModel
                        {
                            Id = Guid.NewGuid(),
                            Name = "nice",
                            NiceType = NiceType.Yes,
                            Count = new Random().Next(0, 100),
                            CreatedTime = new DateTime(2019, 10, 1).ToUniversalTime(),
                            IsValid = true,
                            SayId = int.MaxValue
                        }
                    },
                    {
                        Guid.NewGuid(),
                        new SubModel
                        {
                            Id = Guid.NewGuid(),
                            Name = "nice",
                            NiceType = NiceType.Yes,
                            Count = new Random().Next(0, 100),
                            CreatedTime = new DateTime(2019, 10, 1).ToUniversalTime(),
                            IsValid = true,
                            SayId = int.MaxValue
                        }
                    },
                    {
                        Guid.NewGuid(),
                        new SubModel
                        {
                            Id = Guid.NewGuid(),
                            Name = "nice",
                            NiceType = NiceType.Yes,
                            Count = new Random().Next(0, 100),
                            CreatedTime = new DateTime(2019, 10, 1).ToUniversalTime(),
                            IsValid = true,
                            SayId = int.MaxValue
                        }
                    },
                },
                IsValid = true,
                SayId = int.MaxValue
            };
        }
    }
}