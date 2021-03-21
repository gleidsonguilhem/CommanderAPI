using Commander.Domain;
using NUnit.Framework;
using System;
using Commander.Data.Repositories;

namespace Commander.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        private CommandBuilder CreateCommand(string command, string function, string platform, string application, string user, DateTime created, bool adminRequired)
        {
            CommandBuilder commmandBuilder = CommandBuilder.Create(command, function, platform, application, user, created, adminRequired);

            return commmandBuilder;
        }
        private CommandBuilder CreateCommand()
        {
            var command = "docker run";
            var function = "Creates a Container from a given image";
            var platform = "WINDOWS";
            var application = "Docker";
            var user = "gleidson";
            DateTime created = DateTime.Now;
            var adminRequired = true;

            return CommandBuilder.Create(command, function, platform, application, user, created, adminRequired);
        }
        private MemoryRepository CreateRepository()
        {
            return new MemoryRepository();
        }
        
        [Test]
        public void CreateCommandBuilder()
        {
            var commandBuilder = CreateCommand();
            //Check if the object s not null
            Assert.IsNotNull(commandBuilder);
            //Compare if application value is equal to commandBuilder application attribute
            Assert.AreEqual(commandBuilder.Application, CreateCommand().Application);
            //Create test to check exceptions
            //Assert.Throws<DivideByZeroException>(() => _operacoes.Divisao(x, y, out msg));
        }

        [Test]
        public void TestArgumentException()
        {
            var command = "";
            var function = "Creates a Container from a given image";
            var platform = "WINDOWS";
            var application = "Docker";
            var user = "gleidson";
            DateTime created = DateTime.Now;
            var adminRequired = true;

           Assert.Throws<ArgumentException>(() => CreateCommand(command, function, platform, application, user, created, adminRequired));
        }

        [Test]
        public void TryToAddNewCommandOnDictionary()
        {
            var commandBuilder = CreateCommand();

            var repository = CreateRepository();
            repository.Add(commandBuilder);

            var result = repository.GetAll();

            Assert.IsNotNull(result);
            Assert.True(result.Count > 0);
            Assert.True(result.TryGetValue(commandBuilder.Id, out var commands));
            Assert.AreEqual(commandBuilder.Id, commands.Id);
            Assert.AreEqual(commandBuilder.Platform, commands.Platform);
            Assert.AreEqual(commandBuilder.Command, commands.Command);
        }

        [Test]
        public void RemoveItemFromDictionary()
        {
            var commandBuilder = CreateCommand();
            var repository = CreateRepository();

            //Add the data to the dictionary
            repository.Add(commandBuilder);
            //Check if the data was added
            var result = repository.GetAll();
            Assert.IsNotNull(result);
            Assert.True(result.Count > 0);
            Assert.True(result.TryGetValue(commandBuilder.Id, out var command));
            //Remove the data
            repository.Delete(command.Id);
            //Check if data was removed properly
            result = repository.GetAll();
            Assert.True(result.Count == 0);
            Assert.IsEmpty(result);
        }

        [Test]
        public void TryToAddAnExistingItem()
        {
            var commandBuilder = CreateCommand();
            var repository = CreateRepository();

            //Add commandBuilder
            repository.Add(commandBuilder);
            var result = repository.GetAll();
            Assert.IsNotNull(result);

            var dataAdded = commandBuilder;
            //Try to add the same object
            repository.Add(dataAdded);
            result = repository.GetAll();

            Assert.IsNotNull(result);
            Assert.True(result.Count == 1);
        }

        [Test]
        public void TryGetCommandsById()
        {
            var commandBuilder = CreateCommand();
            var repository = CreateRepository();

            repository.Add(commandBuilder);
            var newId = repository.GetCommandsById(commandBuilder.Id);
            Assert.AreEqual(commandBuilder.Id, newId.Id);
            Assert.AreEqual(commandBuilder.Command, newId.Command);
            Assert.AreEqual(commandBuilder.Platform, newId.Platform);
            Assert.AreEqual(commandBuilder.User, newId.User);
            Assert.AreEqual(commandBuilder.Created, newId.Created);
            Assert.AreEqual(commandBuilder.AdminRequired, newId.AdminRequired);
            Assert.IsNotNull(newId.Id);
        }

        [Test]
        public void UpdateExistingItemFromDictionary()
        {
            var commandBuilder = CreateCommand();
            var repository = CreateRepository();
            repository.Add(commandBuilder);

            commandBuilder.UpdateCommand("dotnet run");

            repository.Update(commandBuilder);
            Assert.AreEqual("dotnet run", commandBuilder.Command);
        }

    }
}