using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterCloneApp.Core.Abstracts
{
    public interface IUpdatedAt
    {
        DateTime? UpdatedAt { get; set; }
    }
}
