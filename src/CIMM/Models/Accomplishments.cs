using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Models
{
    public class Accomplishments
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public bool HasUnitTesting { get; set; }
        public bool HasUnitTestCodeCoverageEnabled { get; set; }
        public bool HasStaticAnalysis { get; set; }

        public bool HasFunctionalTests { get; set; }

        public bool HasOpsCodeInSourceControl { get; set; }

    }
}
