using EatLess.Domain.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Application.Users.Commands.Login
{
    public sealed record LoginCommand(string Email, string Password) : ICommand<string>;
}
