using Infoware.SensitiveDataLogger.Attributes;
using Infoware.SensitiveDataLogger.JsonSerializer;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestProject1
{
    public class UnitTest1
    {
        public class Data
        {
            public string? Name { get; set; }
            [SensitiveData]
            public int Id { get; set; }
        }

        public class Group
        {
            public Data? Data { get; set; }
        }
        public class Group2
        {
            [SensitiveData]
            public Data? Data { get; set; }
        }

        [Fact]
        public void Test_id_int_sensitive()
        {
            var data = new Data()
            {
                Name = "hello",
                Id = 1//"1",
            };

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = false
            };

            var jsonString = JsonSerializer.Serialize(data, serializeOptions);
            Assert.Equal(@"{""Name"":""hello"",""Id"":""***Sensitive data***""}", jsonString);
        }

        [Fact]
        public void Test_id_int_sensitive_LogJsonSerializer()
        {
            var data = new Data()
            {
                Name = "hello",
                Id = 1//"1",
            };

            var serializer = new LogJsonSerializer();

            var jsonString = serializer.Serialize(data);
            Assert.Equal(@"{""Name"":""hello"",""Id"":""***Sensitive data***""}", jsonString);
        }

        [Fact]
        public void Test_id_int_sensitive_LogJsonSerializer_nodefault()
        {
            var data = new Data()
            {
                Name = "hello",
                Id = 1//"1",
            };

            var serializer = new LogJsonSerializer();
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
            };

            var jsonString = serializer.Serialize(data, serializeOptions);
            Assert.Equal(@"{""name"":""hello"",""id"":""***Sensitive data***""}", jsonString);
        }

        [Fact]
        public void Test_subtype()
        {
            var data = new Data()
            {
                Name = "hello",
                Id = 1//"1",
            };
            var group = new Group()
            {
                Data = data
            };

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = false
            };

            var jsonString = JsonSerializer.Serialize(group, serializeOptions);
            Assert.Equal(@"{""Data"":{""Name"":""hello"",""Id"":""***Sensitive data***""}}", jsonString);
        }

        [Fact]
        public void Test_subtype_sensitive()
        {
            var data = new Data()
            {
                Name = "hello",
                Id = 1//"1",
            };
            var group = new Group2()
            {
                Data = data
            };

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = false
            };

            var jsonString = JsonSerializer.Serialize(group, serializeOptions);
            Assert.Equal(@"{""Data"":""***Sensitive data***""}", jsonString);
        }
    }
}