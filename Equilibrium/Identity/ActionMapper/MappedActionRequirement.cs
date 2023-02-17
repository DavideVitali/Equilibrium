using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Identity.ActionMapper
{
    /// <summary>
    /// Authorization requirement to access a mapped action
    /// </summary>
    public class MappedActionRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// General configuration for the access rule to actions
        /// </summary>
        public bool MustBeMapped { get; set; }

        /// <summary>
        /// Default ctor
        /// </summary>
        public MappedActionRequirement(bool mustBeMapped)
        {
            MustBeMapped = mustBeMapped;
        }
    }
}
