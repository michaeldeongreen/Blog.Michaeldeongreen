﻿using NUnit.Framework;
using FluentAssertions;
using Blog.Michaeldeongreen.CLI.Core.Services.Interfaces;
using Blog.Michaeldeongreen.CLI.Core.Services;
using Blog.Michaeldeongreen.CLI.Core.Domain;
using System.Collections.Generic;

namespace Blog.Michaeldeongreen.CLI.Core.Unit.Tests
{
    [TestFixture]
    public class CommandLineArgumentValidationServiceTests
    {
        [Test]
        public void IsValid_When_No_Arguments_Then_ReturnsFalse_Test()
        {
            //given
            IList<CommandLineArgument> commandLineArguments = new List<CommandLineArgument>();
            ICommandLineArgumentValidationService service = new CommandLineArgumentValidationService();
            //when
            bool result = service.IsValid(commandLineArguments);
            //then
            result.Should().BeFalse();
        }
    }
}
