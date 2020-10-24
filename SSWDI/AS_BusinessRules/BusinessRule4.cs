using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AS_BusinessRules
{
    /// <summary>
    /// Specific Treatments require comments
    /// </summary>
    public class BusinessRule4
    {
        [Fact]
        public void VaccinationTreatmentShouldHaveDescription() { }

        [Fact]
        public void ChippingTreatmentShouldHaveDescription() { }

        [Fact]
        public void OperationTreatmentShouldHaveDescription() { }

        [Fact]
        public void EuthanasiaTreatmentShouldHaveDescription() { }
    }
}
