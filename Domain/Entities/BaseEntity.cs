using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class BaseEntity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
