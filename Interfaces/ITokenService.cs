using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fractionalized.Models;

namespace fractionalized.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Subscriber subscriber);
    }
}