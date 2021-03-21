using Commander.Application.Handlers;
using Commander.Data.Interfaces;
using Commander.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Commander.Tests.Application
{
    /*
     * TODO
     * validar criacao do handler
     * Criar handler para Update e Command para Update
     */
    class CreateCommanderBuilderHandlerTest
    {
        private IRepository _repo;
        private CreateCommandBuilderHandler _createHandler;

        [SetUp]
        public void Setup()
        {
            _repo = new MemoryRepository();
            _createHandler = new CreateCommandBuilderHandler(_repo);
        }

        [TestCase]
        public void CreateHandler()
        {
            
            _createHandler.Handle(a, CancellationToken.None);
            //_repo.GetAll();
            //Assert.IsNotNull()
            //Assert.True(result.Count > 0);
        }
    }
}
