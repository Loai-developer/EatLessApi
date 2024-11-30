using EatLess.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Abstractions.Messaging
{
    //Here we have two types of commands : one that does not return a response and
    //other one returns a response -- but both return a Result object wrapper
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
