using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Entidades
{
    public class Entity
    {
        public ValidationResult ValidationResult { get; protected set; }
    }
}
