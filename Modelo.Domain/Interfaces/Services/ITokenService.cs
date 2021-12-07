using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Interfaces.Services
{
    public interface ITokenService <T> where T :class
    {
        string GenerateToken(T entity);
    }
}