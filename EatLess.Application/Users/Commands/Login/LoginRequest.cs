﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Application.Users.Commands.Login
{
    public sealed record LoginRequest(string Email, string Password);
}
